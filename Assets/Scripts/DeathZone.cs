using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathZone : MonoBehaviour
{
    private SavePoint sp;

    void Start()
    {
        sp = GameObject.FindGameObjectWithTag("SP").GetComponent<SavePoint>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        other.gameObject.transform.position = sp.lastCheckPointPos;
        PlayerPrefs.SetFloat("playerTimerSave", Timer.Instance.timeRemaining);
        PlayerPrefs.Save();
    }
}
