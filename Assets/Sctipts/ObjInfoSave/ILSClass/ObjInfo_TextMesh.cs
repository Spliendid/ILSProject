using UnityEngine;
using System;
using System.Collections;

public class ObjInfo_TextMesh : ObjInfoBase
{
    public string text;
    public Color color;

    public override E_ILSTYPE ILSTYPE => E_ILSTYPE.TextMesh;

    public override void GetInfo(GameObject go)
    {
        this.MainObjID = go.GetComponent<ObjID>().ID;
        try
        {
            TextMesh tm = go.GetComponent<TextMesh>();
            if (tm != null)
            {
                text = tm.text;
                color = tm.color;
            }
        }
        catch (Exception e)
        {
            Debug.LogError(e);
        }
    }

    public override void loadInfo()
    {
        GameObject go = mainObj;
        try
        {
            TextMesh tm = go.GetComponent<TextMesh>();
            if (tm != null)
            {
                tm.text = text;
                tm.color = color;
            }
        }
        catch (Exception e)
        {
            Debug.LogError(e);
        }
    }




}
