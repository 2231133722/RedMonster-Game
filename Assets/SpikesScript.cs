using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikesScript : MonoBehaviour
{
    AudioSource myAudioSource;
    public AudioClip spikeHit;
    // Start is called before the first frame update
    void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player") { 
            myAudioSource.PlayOneShot(spikeHit, 0.7f);
            other.gameObject.transform.position = new Vector2(82.0f, 0.0f);
            }
    }
}
