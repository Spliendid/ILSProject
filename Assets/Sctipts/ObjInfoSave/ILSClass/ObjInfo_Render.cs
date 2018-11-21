
using System;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
class ObjInfo_Render: ObjInfoBase
{
    #region MyRegion
    public bool IsMeshRender = true;
    public bool IsAnimation = true;
    #endregion

    public override void GetInfo(GameObject go)
    {
        this.MainObjID = go.GetComponent<ObjID>().ID;
        try
        {
            IsMeshRender = go.GetComponent<Renderer>().enabled;
            IsAnimation = go.GetComponent<Animation>().enabled;
        }
        catch (Exception)
        {

        }
       
    }

    public override void LoadInfo()
    {
        try
        {
            GameObject go = mainObj;

            go.GetComponent<Renderer>().enabled = IsMeshRender;
            go.GetComponent<Animation>().enabled = IsAnimation;
        }
        catch (Exception)
        {

        }
     
    }
}
