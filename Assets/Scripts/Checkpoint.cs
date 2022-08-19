using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    

    private Timer timer;

    private SavePoint sp;

    public bool dead;


    private void Start()
    {
        dead = false;
        sp = GameObject.FindGameObjectWithTag("SP").GetComponent<SavePoint>();
        timer = GameObject.FindGameObjectWithTag("Timer").GetComponent<Timer>();
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            sp.lastCheckPointPos = transform.position;
            timer.lastTimerValue = timer.timeRemaining;
            dead = false;
        }
    }
}
