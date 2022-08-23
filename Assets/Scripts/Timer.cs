using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public AudioClip aDeathSound;

    private SavePoint sp;

    private PlayerPos pp;

    private Checkpoint checkpoint;

    public TMP_Text clockText;

    public float timeRemaining;

    public float lastTimerValue;




    private void Start()
    {

        sp = GameObject.FindGameObjectWithTag("SP").GetComponent<SavePoint>();
        pp = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerPos>();
        checkpoint = GameObject.FindGameObjectWithTag("Checkpoint").GetComponent<Checkpoint>();


    }
    void Update()
    {
        if (checkpoint.dead)
        {
            timeRemaining = lastTimerValue;
            checkpoint.dead = false;
        }

        if (timeRemaining < 10f)
        {
            clockText.color = Color.red;
        }
        else
        {
            clockText.color = Color.white;
        }
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            DisplayTime(timeRemaining);

        }
        else
        {
            AudioSource.PlayClipAtPoint(aDeathSound, Camera.main.transform.position, 0.5F);
            Lives.Instance.MinusLife();
            timeRemaining = 0;
            GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>().transform.position = sp.lastCheckPointPos;
            checkpoint.dead = true;
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
