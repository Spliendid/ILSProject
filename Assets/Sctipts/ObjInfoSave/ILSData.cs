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
    Parent = 1<<1,//父物体信息
    MeshRender = 1<<2,//MeshRender开关
    StepItem = 1<<3,//StepItem信息
    MatInfo = 1<<4,//材质信息
    TextMesh = 1<<5,//TextMesh的Text
    Reflection = 1<<6,//类反射
}

public class ILSData
{
  
    //加载物体信息字典[步骤]：[集合]
    //public static Dictionary<int, List<ObjInfoBase>> InfoDic = new Dictionary<int, List<ObjInfoBase>>();

    //保存时的字典
    public static Dictionary<string, List<JsonTransClass>> SaveDic;
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

    //遍历获取信息
    public static List<JsonTransClass> GetAllSaveInfo(E_ILSTYPE iLSTYPE,GameObject go)
    {
        List<JsonTransClass> ls = new List<JsonTransClass>();
        
         //父物体信息存储
        if ((iLSTYPE & E_ILSTYPE.Parent)!=0)
        {
            ObjInfo_Parent objinfo = new ObjInfo_Parent();
            ls.Add(objinfo.SaveInfo<ObjInfo_Parent>(go));
        }

        //TransformInfo信息存储
        if ((iLSTYPE & E_ILSTYPE.TransformInfo)!=0)
        {
            ObjInfo_Transform objinfo = new ObjInfo_Transform();
            ls.Add(objinfo.SaveInfo<ObjInfo_Transform>(go));
        }

        //Mesh显示隐藏
        if ((iLSTYPE & E_ILSTYPE.MeshRender)!=0)
        {
            ObjInfo_MeshRender objinfo = new ObjInfo_MeshRender();
            ls.Add(objinfo.SaveInfo<ObjInfo_MeshRender>(go));
        }

    
        //材质球信息
        if ((iLSTYPE & E_ILSTYPE.MatInfo) != 0)
        {
            ObjInfo_Mat objinfo = new ObjInfo_Mat();
            ls.Add(objinfo.SaveInfo<ObjInfo_Mat>(go));
        }


        //TextMesh信息
        if ((iLSTYPE & E_ILSTYPE.TextMesh) != 0)
        {
            ObjInfo_TextMesh objinfo = new ObjInfo_TextMesh();
            ls.Add(objinfo.SaveInfo<ObjInfo_TextMesh>(go));
        }

          //反射信息
        if ((iLSTYPE & E_ILSTYPE.Reflection) != 0)
        {
            ObjInfo_Reflection objinfo = new ObjInfo_Reflection();
            ls.Add(objinfo.SaveInfo<ObjInfo_Reflection>(go));
        }

        return ls;
    }
}

