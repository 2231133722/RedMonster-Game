using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lives : MonoBehaviour
{
    public static Lives Instance { get; private set; }
    public int playerLives;
    private int playerStartLives;
    private Scene activeScene;

    public TMP_Text LivesText;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        activeScene = SceneManager.GetActiveScene();
        if (activeScene == SceneManager.GetSceneByBuildIndex(2)) 
        { 
            playerStartLives = 5;
            playerLives = playerStartLives;
            PlayerPrefs.SetInt("playerLives", playerStartLives);
            PlayerPrefs.Save();

        }
        else if (activeScene == SceneManager.GetSceneByBuildIndex(4) || (activeScene == SceneManager.GetSceneByBuildIndex(5))) 
        {
            playerLives = PlayerPrefs.GetInt("playerLives");
            LivesText.text = "Lives: " + playerLives;
        }
        else
        {
            LivesText.text = "ERROR";
        }
    }

    // Update is called once per frame
    void Update()
    {
        LivesText.text = "Lives: " + playerLives;
        if(playerLives <= 0)
        {
            SceneManager.LoadScene(6);
        }
    }

    public void ExtraLife()
    {
        playerLives += 1;
        PlayerPrefs.SetInt("playerLives", playerLives);
        PlayerPrefs.Save();
    }
    public void MinusLife()
    {
        playerLives -= 1;
        PlayerPrefs.SetInt("playerLives", playerLives);
        PlayerPrefs.Save();
    }

}
