using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    MYJSON myJSON = new MYJSON();

    private Timer myTimer;

    private SavePoint sp;

    string json;

    private void Start()
    {
        myJSON.timeRemaining = 0;
        json = JsonUtility.ToJson(myJSON);
        myTimer = GameObject.Find("Timer").GetComponent<Timer>();
        sp = GameObject.FindGameObjectWithTag("SP").GetComponent<SavePoint>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            sp.lastCheckPointPos = transform.position;
            myJSON.timeRemaining = myTimer.timeRemaining;
            json = JsonUtility.ToJson(myJSON);
        }
    }
}
