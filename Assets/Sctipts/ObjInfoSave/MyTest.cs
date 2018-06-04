using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using LitJson;
using System.IO;
public class MyTest : MonoBehaviour {
    public string info;
    public string path;
    public int step;
    public GameObject tesobj;
    [ContextMenu("存字典")]
    private void SaveInfo()
    {
       // File.WriteAllText("","");
        ILSManager._Instance.SaveInfo(step);
    }
    [ContextMenu("写信息")]
    private void WriteInfo()
    {
        ILSManager._Instance.WriteAllTXT();
    }
    [ContextMenu("HashCode")]
    private void HashCode()
    {
        Debug.Log(gameObject.GetHashCode());
    }
    [ContextMenu("测试JSON")]
    private void LitJsonTest()
    {

        Dictionary<string, string> testDic = new Dictionary<string, string>();
        testDic.Add("aa", "123");
        testDic.Add("bb", "sss");
        P p = new P();
        p.t = 1;
        p.dic = testDic;
        Debug.Log(JsonMapper.ToJson(p));

        Dictionary<string  , List<TestClass>> dic = new Dictionary<string , List<TestClass>>();
        dic.Add("1",new List<TestClass> { new TestClass("11", 1) });
        //ClassDic _dic = new ClassDic();
        //_dic.dic = dic;
        Debug.Log(JsonMapper.ToJson(dic));
    }
    [ContextMenu("加载步骤")]
    private void LoadStep()
    {
        ILSManager._Instance.LoadInfo();
        ILSManager._Instance.LoadStepInfo(step);
    }
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        tesobj.transform.Rotate(Vector3.one,Time.deltaTime*20);
	}

    private void OnGUI()
    {
        if (GUI.Button(new Rect(0,0,200,80),"加载信息"))
        {
            LoadStep();
        }
    }
}
[System.Serializable]
public class ClassDic
{
    public Dictionary<string, string> dic = new Dictionary<string, string>();
}
[System.Serializable]
public class TestClass
{
    public string Name;
    public int ID;
    public TestClass(string name,int id)
    {
        Name = name;
        ID = id;
    }
}

[System.Serializable]
public class P
{
    public int t;
    public Dictionary<string, string> dic = new Dictionary<string, string>();

}

