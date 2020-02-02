using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int BrickToLoose = 10;
    public float TimeTowin = 60;

    private static int _brickToLoose;
    public static float _timeTowin;

    private void Start()
    {
        _brickToLoose = BrickToLoose;
        _timeTowin = TimeTowin;
    }

    private void Update()
    {
        TimerForShoot();
    }

    public static void UpdateBrickStatus()
    {
        _brickToLoose -= 1;
        if (_brickToLoose <= 0)
            GameOver();
    }

    private static void Win()
    {
        // Richiamo una schermata di vittoria
        Debug.Log("Win");
        SceneManager.LoadScene("WinScene");
    }

    private static void TimerForShoot()
    {
        _timeTowin -= Time.deltaTime;
        if (_timeTowin < 0)
        {
            Win();
        }
    }

    private static void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }
}
