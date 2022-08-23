using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gameover : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitForMusic());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator WaitForMusic()
    {
        yield return new WaitForSeconds(8f);
        SceneManager.LoadScene(0);
    }
}
