/* 
 *  Name  : Arthur
 *  Title :物体信息-Transform
 *  Function:物体信息数据
 *  Time    : 2018.5
 *  Version : 1.0
 *
 */
using System;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
class ObjInfo_Transform:ObjInfoBase
{
    #region MyRegion

    public Vector3 Local_Pos;
    public Vector3 Local_Euler;
    public Vector3 Local_Scale;
    #endregion

    public override void GetInfo(GameObject go) 
    {
        Local_Pos = go.transform.localPosition;
        Local_Euler = go.transform.localEulerAngles;
        Local_Scale = go.transform.localScale;
        this.MainObjID = go.GetComponent<ObjID>().ID;
    }

    public override void LoadInfo()
    {
        GameObject go = mainObj;
        go.transform.localPosition = this.Local_Pos;
        go.transform.localRotation = Quaternion.Euler(this.Local_Euler);
        go.transform.localScale = this.Local_Scale;
    }
}
