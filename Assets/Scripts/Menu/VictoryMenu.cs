using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VictoryMenu : MonoBehaviour
{
    public Button btnMenu;

    void Start()
    {
        btnMenu = btnMenu.GetComponent<Button>();
        btnMenu.onClick.AddListener(MenuOnClick);
    }

    private void MenuOnClick()
    {
        SceneManager.LoadScene("StartMenu");
    }
}
