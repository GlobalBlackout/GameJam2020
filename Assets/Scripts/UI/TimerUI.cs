using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerUI : MonoBehaviour
{
    private Text _seconds;

    private void Start()
    {
        _seconds = GetComponent<Text>();
    }

    private void Update()
    {
        _seconds.text = (Mathf.Floor((GameManager._timeTowin * 100) / 100) + 1).ToString();
    }
}
