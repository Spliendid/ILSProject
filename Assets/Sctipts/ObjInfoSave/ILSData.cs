/* 
 *  Name  : Arthur
 *  Title :物体信息
 *  Function:物体信息数据
 *  Time    : 2018.4
 *  Version : 1.0
 *
 */
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class EnumFlagsAttribute : PropertyAttribute
{
}


[System.Flags]
public enum E_ILSTYPE
{
    TransformInfo = 1,//位置信息
    Parent = 2,//父物体信息
    MeshRender = 4,//MeshRender开关
    StepItem = 8,//StepItem信息
}

public class ILSData
{
  
    //加载物体信息字典[步骤]：[集合]
    //public static Dictionary<int, List<ObjInfoBase>> InfoDic = new Dictionary<int, List<ObjInfoBase>>();

    //保存时的字典
    public static Dictionary<string, List<JsonTransClass>> SaveDic ;
}
//盛放Json数据类
[System.Serializable]
public class JsonTransClass
{
    public string Name;
    public string TypeName;
    public string JsonInfo;
    public void LoadInfo()
    {
        ObjInfoBase objinfo = JsonUtility.FromJson(this.JsonInfo, Type.GetType(this.TypeName)) as ObjInfoBase;
        objinfo.LoadInfo();
    }
}

