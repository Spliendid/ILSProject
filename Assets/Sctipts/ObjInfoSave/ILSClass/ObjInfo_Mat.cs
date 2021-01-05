
using System;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
[Serializable]
class ObjInfo_Mat : ObjInfoBase
{
    #region MyRegion
    public MatInfo[] MatArray;

    public override E_ILSTYPE ILSTYPE => E_ILSTYPE.MatInfo;

    #endregion


    public override void GetInfo(GameObject go)
    {
        this.MainObjID = go.GetComponent<ObjID>().ID;
        try
        {
            MatArray = go.GetComponent<ILSItem>().MatInfoArray;
            foreach (var item in MatArray)
            {
                item.GetValue(go);
            }
        }
        catch (Exception e)
        {
            Debug.Log(MainObjID+":"+e.StackTrace,mainObj);
        }

    }

    public override void loadInfo()
    {
        GameObject go = mainObj;
        try
        {
            foreach (var item in MatArray)
            {
                item.SetValue(mainObj);
            }

        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
        }

    }
}
