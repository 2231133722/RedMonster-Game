using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathZone : MonoBehaviour
{
    public AudioClip aDeathSound;

    private SavePoint sp;
    private Checkpoint checkpoint;

    void Start()
    {
        sp = GameObject.FindGameObjectWithTag("SP").GetComponent<SavePoint>();
        checkpoint = GameObject.FindGameObjectWithTag("Checkpoint").GetComponent<Checkpoint>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player")) {
            AudioSource.PlayClipAtPoint(aDeathSound, Camera.main.transform.position, 0.5F);
            Lives.Instance.MinusLife();
        other.gameObject.transform.position = sp.lastCheckPointPos;
        checkpoint.dead = true;}
    }
}
