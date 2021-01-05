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
    public bool isActive;
    public Vector3 Local_Pos;
    public Quaternion local_Rotation;
    public Vector3 Local_Scale;

    public override E_ILSTYPE ILSTYPE => E_ILSTYPE.TransformInfo;
    #endregion

    public override void GetInfo(GameObject go) 
    {
        Local_Pos = go.transform.localPosition;
        local_Rotation = go.transform.localRotation;
        Local_Scale = go.transform.localScale;
        isActive = go.activeSelf;
        this.MainObjID = go.GetComponent<ObjID>().ID;
    }

    public override void loadInfo()
    {
        if (mainObj == null)
        {
            Debug.Log("<Color=red>存储信息方面有错误</Color>");
            return;
        }
        GameObject go = mainObj;
        go.transform.localPosition = this.Local_Pos;
        go.transform.localRotation = this.local_Rotation;
        go.transform.localScale = this.Local_Scale;
        go.SetActive(isActive);
    }
}
