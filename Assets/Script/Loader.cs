using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Loader : MonoBehaviour
{
    public Material[] mat;
    public GameObject car;
    // Start is called before the first frame update
    void Start()
    {
        string json1 = File.ReadAllText(@"D:\data.json");
        MyClass1 hehe = JsonUtility.FromJson<MyClass1>(json1);
        int indeks = hehe.index;
        car.GetComponent<Renderer>().material = mat[indeks];
    }
}

[SerializeField]
public class MyClass1
{
    public string nama;
    public int id;
    public int index;
}