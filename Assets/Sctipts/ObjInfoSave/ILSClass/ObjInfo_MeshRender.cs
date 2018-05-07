
using System;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
class ObjInfo_MeshRender: ObjInfoBase
{
    #region MyRegion
    public bool IsMeshRender = true;
    #endregion

    public override void GetInfo(GameObject go)
    {
        this.MainObjID = go.GetComponent<ObjID>().ID;
        IsMeshRender = go.GetComponent<MeshRenderer>().enabled;
    }

    public override void LoadInfo()
    {
        GameObject go = mainObj;
        go.GetComponent<MeshRenderer>().enabled = IsMeshRender;
    }
}
