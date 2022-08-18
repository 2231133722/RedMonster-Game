using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public static Score Instance { get; private set; }
    public int playerScore;
    private int playerStartScore;

    public TMP_Text scoreText;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        playerStartScore = 0;
        scoreText.text = "Score: " + playerStartScore;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + playerScore;
    }

    public void AddHundoPeice()
    {
        playerScore += 100;
    }
    public void AddPie()
    {
        playerScore += 1000;
    }
}
