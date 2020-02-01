using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static int _brickToLoose = 10;
    private static Brick[] AllBricks;   

    public static void UpdateBrickStatus()
    {
        _brickToLoose -= 1;
        if (_brickToLoose <= 0)
            GameOver();
    }

    private static void GameOver()
    {
        Debug.Log("Game over");
    }
}
