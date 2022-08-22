using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public AudioClip aCoin1;
  
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            Score.Instance.AddHundoPeice();
            AudioSource.PlayClipAtPoint(aCoin1, Camera.main.transform.position, 0.7F);
            Destroy(gameObject);
        }
    }
}
