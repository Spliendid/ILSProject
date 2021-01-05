using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using System;
[System.Serializable]
public class ClassReflectInfo 
{
    public string ClassName;//类名字
    public string fieldName;//反射字段属性
    public E_ClassType classType;//反射字段属性类型
    [HideInInspector]
    public string Value;

    public void GetValue(GameObject go)
    {
        var component = go.GetComponent(ClassName);
        Type _type = component.GetType();
        object _obj;
        if (_type.GetField(fieldName)!=null)
        {
            _obj = _type.GetField(fieldName).GetValue(component);
        }
        else if (_type.GetProperty(fieldName)!=null)
        {
            _obj = _type.GetProperty(fieldName).GetValue(component);
        }
        else
        {
            Debug.Log($"{go.name}::{ClassName}-{fieldName} 未找到");
            return;
        }

        switch (classType)
        {
            case E_ClassType.Bool:
            case E_ClassType.Int:
            case E_ClassType.Float:
            case E_ClassType.String:
                Value = _obj.ToString();
                break;
            case E_ClassType.Vector3:
                Value = JsonUtility.ToJson((Vector3)_obj);
                break;
            default:
                break;
        }
    }

    public void SetValue(GameObject go)
    {
        //Debug.Log($"{go.name}::{ClassName}-{fieldName} ");

        var component = go.GetComponent(ClassName);
        Type _type = component.GetType();
        object _value;
        switch (classType)
        {
            case E_ClassType.Bool:
            _value = bool.Parse(Value);
            break;
            case E_ClassType.Float:
            _value = float.Parse(Value);
            break;
            case E_ClassType.Int:
            _value = int.Parse(Value);
            break;
            case E_ClassType.String:
            _value = Value;
            break;
            case E_ClassType.Vector3:
             _value = JsonUtility.FromJson<Vector3>(Value);
               break;
            default:
            _value = Value;
            break;
        }
        if (_type.GetField(fieldName)!=null)
        {
            _type.GetField(fieldName).SetValue(component,_value);
        }else if(_type.GetProperty(fieldName)!=null)
        {
            _type.GetProperty(fieldName).SetValue(component,_value);
        }else{
            Debug.Log($"{go.name}::{ClassName}-{fieldName} 未找到");
        }
    }
}

public enum E_ClassType
{
    Bool = 0,
    Int = 1,
    Float = 2,
    String = 3,
    Vector3 = 4,
}
