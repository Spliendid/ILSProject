
using System;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
class ObjInfo_Parent : ObjInfoBase
{
    #region MyRegion

    public int ParentID;

    public override E_ILSTYPE ILSTYPE => E_ILSTYPE.Parent;

    #endregion

    public override void GetInfo(GameObject go)
    {

        try
        {
            Transform p = go.transform.parent;
            if (p != null)
            {
                if (p.GetComponent<ObjID>() != null)
                {
                    ParentID = go.transform.parent.GetComponent<ObjID>().ID;
                }
                else
                {
                    Debug.LogError(go + "的父物体没有挂载ObjID！必须挂上该脚本！",go);
                }
            }
        }
        catch (Exception e)
        {
            Debug.LogError(e);
        }
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
        go.transform.SetParent(ObjID.GetObjByID(ParentID) == null ? null : ObjID.GetObjByID(ParentID).transform);
    }
}
