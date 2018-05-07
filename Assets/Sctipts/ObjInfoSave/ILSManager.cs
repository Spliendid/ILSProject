/* 
 *  Name  : Arthur
 *  Title :物体信息
 *  Function:物体信息管理类
 *  Time    : 2018.4
 *  Version : 1.0
 *
 */
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using LitJson;
public class ILSManager : MonoBehaviour {
    public static ILSManager _Instance;
    public bool IsEditor = true;
    public string Path;//文件输出路径
    public System.Action<int> SaveInfoHandler;
    #region MainFunction

    private void Awake()
    {
        _Instance = this;
    }

    //将数据传出到字典当中
    public void SaveInfo(int step)
    {
        if (!IsEditor)
        {
            return;
        }
        if (ILSData.SaveDic == null)
        {
            ILSData.SaveDic = new Dictionary<string, List<JsonTransClass>>();
        }
        if(SaveInfoHandler != null)
            SaveInfoHandler(step);
        Debug.Log("存入字典成功"+step.ToString());
    }


    //将数据写入txt(仅在开发中运行)
    [ContextMenu("保存数据")]
    public void WriteAllTXT()
    {
        if (!IsEditor)
        {
            return;
        }
        string json = JsonMapper.ToJson(ILSData.SaveDic);
        ILSTool.WriteData(Path,json);
        Debug.Log("保存数据成功，将数据写入txt");
    }


    //加载数据(WebPlayer端用Resource.Load加载,实验开始时加载)
    [ContextMenu("加载信息")]
    public void LoadInfo()
    {
        if (ILSData.SaveDic ==null)
        {
            ILSData.SaveDic =JsonMapper.ToObject<Dictionary<string,List<JsonTransClass>>> (ILSTool.ReadData("ILS/txt"));
        }
        Debug.Log("加载数据成功");
    }
   
    [ContextMenu("加载某一步")]
    public void LoadStepInfo(int step)
    {
        string key = step.ToString();
        if (ILSData.SaveDic.ContainsKey(key))
        {
            foreach (JsonTransClass item in ILSData.SaveDic[key])
            {
                item.LoadInfo();
            }
        }
        Debug.Log("加载步骤成功："+step.ToString());
    }
    #endregion
}
