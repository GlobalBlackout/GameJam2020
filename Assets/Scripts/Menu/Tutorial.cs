using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour
{
    public float TimeStunn = 3;

    private static float _timeTowin;

    private void Start()
    {
        _timeTowin = TimeStunn;
    }

    private void Update()
    {
        TimeForStunn();
    }

    private void TimeForStunn()
    {
        _timeTowin -= Time.deltaTime;
        if (_timeTowin < 0)
        {
            SceneManager.LoadScene(FindObjectOfType<LevelManager>().LevelsName[0]);
        }
    }
}
