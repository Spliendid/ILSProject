/* 
 *  Name  : Arthur
 *  Title :物体信息
 *  Function:物体信息mono类
 *  Time    : 2018.4
 *  Version : 1.0
 *
 */
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
[RequireComponent(typeof(ObjID))]
public class ILSItem : MonoBehaviour {

    [EnumFlagsAttribute]
    public E_ILSTYPE _type;//需要存储的类型可多选

    public MatInfo[] MatInfoArray; 

    private List<JsonTransClass> StrInfoList = new List<JsonTransClass>();//该对象需要存储的信息集合

    //获取信息存到StrInfoList里面
    public void GetObjInfo()
    {
        StrInfoList.Clear();
        //父物体信息存储
        if ((_type & E_ILSTYPE.Parent)!=0)
        {
            ObjInfo_Parent objinfo = new ObjInfo_Parent();
            JsonTransClass jsonTrans = new JsonTransClass();
            StrInfoList.Add(objinfo.SaveInfo<ObjInfo_Parent>(gameObject));
        }

        //TransformInfo信息存储
        if ((_type & E_ILSTYPE.TransformInfo)!=0)
        {
            ObjInfo_Transform objinfo = new ObjInfo_Transform();
            JsonTransClass jsonTrans = new JsonTransClass();
            StrInfoList.Add(objinfo.SaveInfo<ObjInfo_Transform>(gameObject));
        }

        //Mesh显示隐藏
        if ((_type & E_ILSTYPE.MeshRender)!=0)
        {
            ObjInfo_Render objinfo = new ObjInfo_Render();
            JsonTransClass jsonTrans = new JsonTransClass();
            StrInfoList.Add(objinfo.SaveInfo<ObjInfo_Render>(gameObject));
        }

    
        //StepItem材质球信息
        if ((_type & E_ILSTYPE.MatInfo) != 0)
        {
            ObjInfo_Mat objinfo = new ObjInfo_Mat();
            JsonTransClass jsonTrans = new JsonTransClass();
            StrInfoList.Add(objinfo.SaveInfo<ObjInfo_Mat>(gameObject));
        }
    }

   
    //将该对象信息存到字典内
    public void SaveInfo(int step)
    {
        if (!ILSManager._Instance.IsEditor)
        {
            return;
        }
        GetObjInfo();
         List<JsonTransClass> listTemp = new List<JsonTransClass>( StrInfoList);
        string key = step.ToString();
        if (ILSData.SaveDic.ContainsKey(key))
        {
            ILSData.SaveDic[key].AddRange(listTemp);
        }
        else
        {
            ILSData.SaveDic.Add(key, listTemp);
        }
    }
    #region Mono

    // Use this for initialization
    void Start () {
        ILSManager._Instance.SaveInfoHandler += SaveInfo;
    }

    // Update is called once per frame
    void Update () {
	
	}
    #endregion

    #region Test
    [ContextMenu("getJson")]
    void GetJson()
    {
        GetObjInfo();
      //  Debug.Log(JsonUtility.ToJson(new Serialization<ObjInfoBase>(new List<ObjInfoBase> { infoList[0] as ObjInfo_Transform })));
    }

    #endregion
}
