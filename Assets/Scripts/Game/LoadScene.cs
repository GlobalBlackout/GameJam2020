using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    // Start is called before the first frame update

    private int level = 1;
    public float timer = 0f;
    public float LoadingTime = 3f;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        float seconds = timer % 60;

        Debug.Log(seconds);

        if(seconds > LoadingTime)
        {
            SceneManager.LoadScene("RepairLevel" + level);

            level++;
        }
    }
}
