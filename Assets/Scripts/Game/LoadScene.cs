using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class LoadScene : MonoBehaviour
{
    public float Timer = 0f;
    public float LoadingTime = 3f;

    public void Update()
    {
        Timer += Time.deltaTime;

        if (Timer > LoadingTime)
        {
            FindObjectOfType<LevelManager>().LevelLoad();
        }
    }
}
