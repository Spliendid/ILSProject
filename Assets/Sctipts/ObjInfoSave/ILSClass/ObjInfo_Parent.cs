
using System;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
class ObjInfo_Parent:ObjInfoBase
{
    #region MyRegion

    public int ParentID;

    #endregion

    public override void GetInfo(GameObject go) 
    {
    
        try
        {
            ParentID = go.transform.parent.GetComponent<ObjID>().ID;
        }
        catch (Exception)
        {

            //throw;
        }
        this.MainObjID = go.GetComponent<ObjID>().ID;
    }

    public override void LoadInfo()
    {
        GameObject go = mainObj;
        go.transform.SetParent(ObjID.GetObjByID(ParentID) == null ? null : ObjID.GetObjByID(ParentID).transform);
    }
}
