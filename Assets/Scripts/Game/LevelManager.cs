using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public string[] LevelsName;

    private string _levelName;

    private void Start()
    {
        DontDestroyOnLoad(this);
        _levelName = SceneManager.GetActiveScene().name;
    }

    public void LevelLoad()
    {
        if (_levelName == "StartMenu")
        {
            SceneManager.LoadScene(LevelsName[0]);
            _levelName = LevelsName[0];
        }

        bool levelFlag = false;
        foreach (string levelName in LevelsName)
        {
            if (!levelFlag && levelName == _levelName)
            {
                levelFlag = true;
                continue;
            }

            if (levelFlag)
            {
                _levelName = levelName;
                SceneManager.LoadScene(levelName);
                return;
            }
        }

        SceneManager.LoadScene("VictoryScene");
    }
}
