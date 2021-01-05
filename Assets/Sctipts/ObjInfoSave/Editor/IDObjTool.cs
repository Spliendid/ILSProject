using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEditor;
using UnityEditor.Callbacks;
using System.IO;
using System.Text;
public class IDObjTool {
#if UNITY_EDITOR
    //清空字典
    [MenuItem("Tools/IDManager/CleanDic")]
    public static void ClenDic()
    {
        ObjID.ObjIDDic = new Dictionary<int, GameObject>();
    }
    //打印出字典
    [MenuItem("Tools/IDManager/LogDic")]
    public static void LogDic()
    {
        string info = "";
        var enumerator = ObjID.ObjIDDic.GetEnumerator();
        while (enumerator.MoveNext())
        {
            try
            {
                info += enumerator.Current.Key.ToString() + ":\t" + enumerator.Current.Value.name + "\n";
            }
            catch (System.Exception)
            {
                Debug.Log("<color=red>可能重新加载了场景，请点击Tools/IDManager/CleanDic清空字典，并重新运行</color>");
            }
        }
        Debug.Log(info == "" ? "字典为空" : info);
    }
    
    //检查DIC,将value为Null 的 数据清空
    [MenuItem("Tools/IDManager/CheckDic")]
    public static void Check()
    {
        var enumerator = ObjID.ObjIDDic.GetEnumerator();
        while (enumerator.MoveNext())
        {
            if (enumerator.Current.Value == null)
            {
                ObjID.ObjIDDic.Remove(enumerator.Current.Key);
            }
        }
    }

//   [MenuItem("Tools/IDManager/FindObj")]
//     public static void FindObj()
//     {
//         EditorWindow.GetWindow(typeof(FindObjWindow));
//     }

     [MenuItem("Tools/IDManager/IDDic2Json")]
    public static void IDDic2Json()
    {
        string path = Application.dataPath+"/Editor/DicJson.json";
        // string json = LitJson.JsonMapper.ToJson(ObjID.ObjIDDic);
        StringBuilder sb = new StringBuilder();
        sb.Append("{\n");
        foreach (KeyValuePair<int,GameObject> item in ObjID.ObjIDDic)
        {
            sb.Append($"\"{item.Key}\":\"{item.Value.name}\",\n");
        }
        sb.Remove(sb.Length-2,1);
        sb.Append("}");
        
        string json = sb.ToString();
        Debug.Log(json);
        ILSTool.WriteData(path,json);
    }

      [OnOpenAssetAttribute(1)]
    public static bool step0(int instanceID, int line)
    {
       string path =  AssetDatabase.GetAssetPath(instanceID);
        if (path.EndsWith(".unity"))
        {
            ClenDic();
            Debug.Log("<color=green><size=18>加载场景，ObjID字典清空</size></color>");

        }
        return false; // we did not handle the open
    }

#endif
}
