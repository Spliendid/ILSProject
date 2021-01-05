/* 
 *  Name  : Arthur
 *  Title :物体信息
 *  Function:物体信息mono类
 *  Time    : 2018.4
 *  Version : 1.0
 *
 */
using UnityEngine;
using System.Collections.Generic;
using System.Collections;
//[RequireComponent(typeof(ObjID))]
public class ILSItem : MonoBehaviour {

    public bool isStartActive = true;

    [EnumFlagsAttribute]
    public E_ILSTYPE _type = E_ILSTYPE.TransformInfo;//需要存储的类型可多选


    public MatInfo[] MatInfoArray; 

    public ClassReflectInfo[] ClassReflectArray;

    public List<JsonTransClass> StrInfoList = new List<JsonTransClass>();//该对象需要存储的信息集合

    //获取信息存到StrInfoList里面
    public void GetObjInfo()
    {
       StrInfoList = JsonTransClass.GetAllSaveInfo(_type,gameObject);
    }

   
    //将该对象信息存到字典内
    public void SaveInfo(int step)
    {
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
          StartCoroutine( WaitForEndOfFrame(()=>{
            this.gameObject.SetActive(isStartActive);
        }));
    }

    private IEnumerator WaitForEndOfFrame(System.Action ac)
    {
        yield return new WaitForEndOfFrame();
        ac();
    }
    #endregion

    #region Test
    // [ContextMenu("getJson")]
    // void GetJson()
    // {
    //     GetObjInfo();
    // }

    [ContextMenu("Save")]
    void Save()
    {
        GetObjInfo();
    }

    [ContextMenu("Load")]
    void Load()
    {
        for(int i = 0;i<StrInfoList.Count;i++)
        {
            StrInfoList[i].LoadInfo();
        }
    }

    #endregion
}
