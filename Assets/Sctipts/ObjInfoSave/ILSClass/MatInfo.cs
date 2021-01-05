using UnityEngine;
using System.Collections;
[System.Serializable]
public class MatInfo
{
    public int MatID;

    public E_MatPropertyType propertyType;

    public string PropertyName;

    [HideInInspector]
    public string Value;

    public void SetValue(GameObject go)
    {
        MeshRenderer mr = go.GetComponent<MeshRenderer>();
        if (mr == null)
        {
            return;
        }
        switch (propertyType)
        {
            case E_MatPropertyType.Float:
                mr.materials[MatID].SetFloat(PropertyName,float.Parse(Value));
                break;
            case E_MatPropertyType.Color:
                Color color  = new Color();
                if (ColorUtility.TryParseHtmlString(Value,out color))
                {
                    mr.materials[MatID].SetColor(PropertyName,color);
                }

                break;
            default:
                break;
        }
    }

    public void GetValue(GameObject go)
    {

        MeshRenderer mr = go.GetComponent<MeshRenderer>();
        if (mr == null)
        {
            return;
        }
            
        switch (propertyType)
        {
            case E_MatPropertyType.Float:
                Debug.Log(go.name,go);
                Value = mr.materials[MatID].GetFloat(PropertyName).ToString();
                break;
            case E_MatPropertyType.Color:
             var color = mr.materials[MatID].GetColor(PropertyName);
                Value ="#"+ColorUtility.ToHtmlStringRGBA(color);
                break;
            default:
                break;
        }
      

       
    }
}

public enum E_MatPropertyType
{
    Float = 0,
    Color =1,
}