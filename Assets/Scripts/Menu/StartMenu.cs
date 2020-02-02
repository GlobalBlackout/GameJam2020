using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
	public Button StartBtn;
    public Button QuitBtn;

    void Start()
    {
        StartBtn = StartBtn.GetComponent<Button>();
        StartBtn.onClick.AddListener(StartOnClick);

        QuitBtn = QuitBtn.GetComponent<Button>();
        QuitBtn.onClick.AddListener(QuitOnClick);
    }

    private void StartOnClick()
    {
        SceneManager.LoadScene("Tutorial");
    }

    private void QuitOnClick()
    {
        Application.Quit();
    }
}
