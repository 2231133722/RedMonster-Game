using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Granny : MonoBehaviour
{
    private SavePoint sp;

    public AudioClip aHit1;
    AudioSource audioSource1;

    // Start is called before the first frame update
    void Start()
    {
        audioSource1 = GetComponent<AudioSource>();
        sp = GameObject.FindGameObjectWithTag("SP").GetComponent<SavePoint>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            Vector2 direction = other.GetContact(0).normal;
            if (direction.y == -1 || direction.y == 1)
            {
                Score.Instance.AddHundoPeice();
                GetComponent<Collider2D>().enabled = false;
                audioSource1.PlayOneShot(aHit1, 0.7F);
                Destroy(this.gameObject, 0.15f);
            }
            else
            {
                other.gameObject.transform.position = sp.lastCheckPointPos;
                PlayerPrefs.SetFloat("playerTimerSave", Timer.Instance.timeRemaining);
                PlayerPrefs.Save();
            }
        }

    }
}
