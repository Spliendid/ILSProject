
using System;
using UnityEngine;
[Serializable]
class ObjInfo_MeshRender : ObjInfoBase
{
    #region MyRegion
    public bool IsRender = true;
    public bool IsLight = true;

    public bool IsPower = false;//切割机是否开启

    public override E_ILSTYPE ILSTYPE => E_ILSTYPE.MeshRender;
    #endregion

    public override void GetInfo(GameObject go)
    {
        if (go == null)
        {
            Debug.LogError("go is null");
            return;
        }
        this.MainObjID = go.GetComponent<ObjID>().ID;
        try
        {
            Renderer renderer = go.GetComponent<MeshRenderer>();
            Light light = go.GetComponent<Light>();
            if (renderer != null)
            {
                IsRender = renderer.enabled;
            }
            if (light)
            {
                IsLight = light.enabled;
            }
        }
        catch (Exception e)
        {
            Debug.LogError(e);
        }

    }

    public override void loadInfo()
    {
        if(mainObj == null)
        {
            return;
        }
        GameObject go = mainObj;
        Renderer renderer = go.GetComponent<Renderer>();
        Light light = go.GetComponent<Light>();
        try
        {
            if (renderer != null)
            {
                renderer.enabled = IsRender;
            }
             if (light)
            {
                light.enabled = IsLight;
            }
        }
        catch (Exception e)
        {
            Debug.LogError(e);
        }

    }
}
