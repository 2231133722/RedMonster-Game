using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private SavePoint sp;

    private void Start()
    {
        sp = GameObject.FindGameObjectWithTag("SP").GetComponent<SavePoint>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            sp.lastCheckPointPos = transform.position;
        }
    }
}
