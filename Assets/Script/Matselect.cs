using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
public class Matselect : MonoBehaviour
{
    public Material[] material;
    public GameObject car;

    int selector = 0;
    int counter = 0;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.JoystickButton4))
        {
            counter += 1;
            selector = counter % material.Length;
            car.GetComponent<Renderer>().material = material[Mathf.Abs(selector)];
        }
        else if (Input.GetKeyUp(KeyCode.JoystickButton5))
        {
            counter -= 1;
            selector = counter % material.Length;
            car.GetComponent<Renderer>().material = material[Mathf.Abs(selector)];

        }
        if (Input.GetKeyUp(KeyCode.JoystickButton0))
        {
            Debug.Log("hehe");
            MyClass setMaterial = new MyClass();
            setMaterial.nama = material[Mathf.Abs(selector)].name;
            setMaterial.id = material[Mathf.Abs(selector)].GetInstanceID();
            setMaterial.index = Mathf.Abs(selector);
            string json = JsonUtility.ToJson(setMaterial);
            File.WriteAllText(@"D:\data.json", json);
            SceneManager.LoadScene("RVA");
        }
    }
}

[SerializeField]
public class MyClass
{
    public string nama;
    public int id;
    public int index;
}