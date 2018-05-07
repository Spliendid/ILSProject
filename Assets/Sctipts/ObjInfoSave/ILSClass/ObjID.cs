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
//物体唯一ID
[Serializable]
public class ObjID : MonoBehaviour
{

    #region 静态方法
    //添加到字典
    public static void AddDic(int _ID, GameObject obj)
    {
        if (ObjIDDic.ContainsKey(_ID))
        {
            Debug.Log(obj.name + "<color =red>已存在</color>");
        }
        else
        {
            ObjIDDic.Add(_ID, obj);
        }
    }

    //存储物体的字典
    [NonSerialized]
    public static Dictionary<int, GameObject> ObjIDDic = new Dictionary<int, GameObject>();

    //根据ID找到Object
    public static GameObject GetObjByID(int _id)
    {
        if (_id == 0)
        {
            return null; 
        }
        if (ObjIDDic.ContainsKey(_id))
        {
            return ObjIDDic[_id];
        }
        return null;
    }

    #endregion

    [ContextMenu("自动生成ID")]
    public void CreatID()
    {
        ID = this.gameObject.GetInstanceID();
    }

    public void Start()
    {
//#if UNITY_EDITOR
//        CreatID();
//#endif
        AddDic(ID, this.gameObject);
    }


    public int ID;
}
