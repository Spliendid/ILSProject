
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
public class ILSTool  {
    //获取路径
    public static string GetObjPath(GameObject go)
    {
        string path="";
        List<string> strList = new List<string>();
        while (true)
        {
            strList.Add("/" + go.name);
            if (go.transform.parent == null)
            {
                break;
            }
            go = go.transform.parent.gameObject;
        }

        for (int i = strList.Count - 1; i >= 0; i--)
        {
            path += strList[i];
        }

        Debug.Log(path);
        return path;
    }

    //写txt
    public static void  WriteData(string path,string info)
    {
        if (!File.Exists(path))
        {
            File.Create(path);
        }
        FileStream stream = new FileStream(path,FileMode.Create);
        byte[] data = System.Text.Encoding.Default.GetBytes(info);
        stream.Write(data,0,data.Length);
        stream.Close();
     }

    //读取txt
    public static string ReadData(string path)
    {
            return Resources.Load<TextAsset>(path).text;
    }
}
