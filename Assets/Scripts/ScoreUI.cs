using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreUI : MonoBehaviour
{
    public Text scoreText;
    public Text highscoreText;
    public int playerScore;
    public Scene scene;
    

    public void Awake()
    {
        scene = SceneManager.GetActiveScene();
        if(scene.name == "Level1")
        {
            PlayerPrefs.SetInt("Score", 0);
        }
    }
    public int Highscore()
    {
            if(playerScore > PlayerPrefs.GetInt("Highscore"))
            {
                PlayerPrefs.SetInt("Highscore", playerScore);
            }
        return PlayerPrefs.GetInt("Highscore");
    }
    // Update is called once per frame
    void Update()
    {
        playerScore = PlayerPrefs.GetInt("Score");
        scoreText.text = "Score: " + playerScore.ToString();
        highscoreText.text = "Highscore: " + Highscore().ToString();
    }
}
