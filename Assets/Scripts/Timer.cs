using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    private SavePoint sp;

    public TMP_Text clockText;

    public float timeRemaining = 1;

    private void Start()
    {
        sp = GameObject.FindGameObjectWithTag("SP").GetComponent<SavePoint>();
    }
    void Update()
    {
        if(timeRemaining < 10f)
        {
            clockText.color = Color.red;
        }
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            DisplayTime(timeRemaining);
        }
        else
        {
            timeRemaining = 0;
            sp.lastCheckPointPos = sp.startCheckPointPos;
            SceneManager.LoadScene(2);
        }
    }
    void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        float milliSeconds = (timeToDisplay % 1) * 1000;
        clockText.text = string.Format("Timer: " + "{0:00}:{1:00}:{2:000}", minutes, seconds, milliSeconds);
    }
}
