using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikesScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player")
            other.gameObject.transform.position = new Vector2(82.0f, 0.0f);
    }
}
