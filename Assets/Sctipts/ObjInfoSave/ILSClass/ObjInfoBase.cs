/* 
 *  Name  : Arthur
 *  Title :物体信息
 *  Function:物体信息基类
 *  Time    : 2018.4
 *  Version : 1.0
 *
 */
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
[System.Serializable]
public  abstract class ObjInfoBase{

    /// <summary>
    /// 该信息所属的物体
    /// </summary>
    protected GameObject mainObj {
        get { return ObjID.GetObjByID(MainObjID); }
    }
    public int MainObjID;//主要物体对应ID
    public abstract void GetInfo(GameObject go);//获取info
    public abstract void  LoadInfo(); //加载info

    //保存Json信息
    public virtual JsonTransClass SaveInfo<T>(GameObject go) where T:ObjInfoBase
    {
        GetInfo(go);
        JsonTransClass jsonTrans = new JsonTransClass();
        jsonTrans.Name = go.name;
        jsonTrans.JsonInfo = JsonUtility.ToJson(this);
        jsonTrans.TypeName = typeof(T).ToString();
        return jsonTrans;
    }
}
