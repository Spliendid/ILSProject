
using System;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
[Serializable]
class ObjInfo_Reflection : ObjInfoBase
{
    #region MyRegion
    public ClassReflectInfo[] ReflectArray;

    public override E_ILSTYPE ILSTYPE => E_ILSTYPE.Reflection;

    #endregion


    public override void GetInfo(GameObject go)
    {
        this.MainObjID = go.GetComponent<ObjID>().ID;
        try
        {
            ReflectArray = go.GetComponent<ILSItem>().ClassReflectArray;
            foreach (var item in ReflectArray)
            {
                item.GetValue(go);
            }
        }
        catch (Exception e)
        {
            Debug.Log(e.Message+e.StackTrace);
        }

    }

    public override void loadInfo()
    {
           
        try
        {
            GameObject go = mainObj;
            foreach (var item in ReflectArray)
            {
                item.SetValue(mainObj);
            }
        }
        catch (Exception e)
        {
            Debug.Log(e.Message+e.StackTrace);
        }

    }
}
