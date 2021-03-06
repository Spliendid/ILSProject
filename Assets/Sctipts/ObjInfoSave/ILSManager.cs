﻿/* 
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
public class ILSManager : MonoBehaviour
{
    public static ILSManager _Instance;
    public string Path;
    public Action<int> SaveInfoHandler;
    #region MainFunction

    private void Awake()
    {
        _Instance = this;
        if (Path == "")
        {
            Path = Application.dataPath + "/Resources/ILS/txt.txt";//文件输出路径
        }

        LoadInfo();
    }
    //将数据传出到字典当中
    public void SaveInfo(int step)
    {
#if UNITY_EDITOR
        if (ILSData.SaveDic == null)
        {
            ILSData.SaveDic = new Dictionary<string, List<JsonTransClass>>();
        }

        if (SaveInfoHandler != null)
        {
            if (ILSData.SaveDic.ContainsKey(step.ToString()))
            {
                ILSData.SaveDic.Remove(step.ToString());
            }
            SaveInfoHandler(step);
            Debug.Log("保存字典成功步骤为" + "<color=red>" + step.ToString() + "</color>");
        }
#endif
    }


    //将数据写入txt(仅在开发中运行)
    public void WriteAllTXT()
    {
#if UNITY_EDITOR
        string json = JsonMapper.ToJson(ILSData.SaveDic);
        ILSTool.WriteData(Path, json);
        Debug.Log("数据写入txt成功");
#endif
    }

    //加载数据(WebPlayer端用Resource.Load加载,实验开始时加载)
    public void LoadInfo()
    {
        if (ILSData.SaveDic == null)
        {
            ILSData.SaveDic = JsonMapper.ToObject<Dictionary<string, List<JsonTransClass>>>(ILSTool.ReadData("ILS/txt"));
            
            Debug.Log(string.Format("<Color=green>加载存储信息成功 :\n录制的大步骤总数:{0}</Color>", ILSData.SaveDic.Count));
        }
    }

    [ContextMenu("加载某一步")]
    public static void LoadStepInfo(int step)
    {
        string key = step.ToString();
        if (ILSData.SaveDic.ContainsKey(key))
        {
            foreach (JsonTransClass item in ILSData.SaveDic[key])
            {
                item.LoadInfo();
            }
            Debug.Log("加载步骤成功步骤为" + "<color=Green>" + step.ToString() + "</color>");
        }
        else
        {
            Debug.Log("加载步骤失败步骤为" + "<color=Red>" + step.ToString() + "</color>");
        }
    }
    #endregion
}
