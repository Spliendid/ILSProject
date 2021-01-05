using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class infoTest : MonoBehaviour
{
    public int i;
    public float f;
    public bool b;
    public string s;
    HashSet<string> hs = new HashSet<string>();
    Hashtable ht = new Hashtable();
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 100; i++)
        {
            ht.Add(i,-i);
        }
        hs.Add("5");
        foreach (var item in ht.Keys)
        {
            Debug.Log(item);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
