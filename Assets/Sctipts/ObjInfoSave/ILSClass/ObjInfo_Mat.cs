
using System;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
[Serializable]
class ObjInfo_Mat : ObjInfoBase
{
    #region MyRegion
    public string MatArray;
    #endregion

    public override void GetInfo(GameObject go)
    {
        this.MainObjID = go.GetComponent<ObjID>().ID;
        try
        {
            var array = go.GetComponent<ILSItem>().MatInfoArray;
            foreach (var item in array)
            {
                item.GetValue(go);
            }
            MatArray = JsonMapper.ToJson(array);
        }
        catch (Exception)
        {

        }

    }

    public override void LoadInfo()
    {
            GameObject go = mainObj;
        try
        {
            MatInfo[] array = JsonMapper.ToObject<MatInfo[]>(MatArray);
            foreach (var item in array)
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
