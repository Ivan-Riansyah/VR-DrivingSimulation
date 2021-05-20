using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Splash : MonoBehaviour
{

    void Start()
    {
        StartCoroutine(streamVideo());
    }

    private IEnumerator streamVideo()
    {
        yield return new WaitForSeconds(7f);
        SceneManager.LoadScene("Select");
    }
}