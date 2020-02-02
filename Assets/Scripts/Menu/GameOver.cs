using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public Button btnRestart;
    public Button btnMenu;
    void Start()
    {
        btnRestart = btnRestart.GetComponent<Button>();
        btnRestart.onClick.AddListener(RestartOnClick);

        btnMenu = btnMenu.GetComponent<Button>();
        btnMenu.onClick.AddListener(MenuOnClick);
    }


    private void RestartOnClick()
    {
        SceneManager.LoadScene(FindObjectOfType<LevelManager>().LevelsName[0]);
    }

    private void MenuOnClick()
    {
        SceneManager.LoadScene("StartMenu");
    }
}
