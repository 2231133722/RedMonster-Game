using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPos : MonoBehaviour
{
    private SavePoint sp;

    private void Start()
    {
        sp = GameObject.FindGameObjectWithTag("SP").GetComponent<SavePoint>();
        transform.position = sp.lastCheckPointPos;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
