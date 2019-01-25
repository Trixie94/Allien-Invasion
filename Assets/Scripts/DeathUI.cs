using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathUI : MonoBehaviour
{
    public GameObject deathUI;
    public Text yourScoreText;
    public Text highScoreText;
    private int yourScore;
    private int highScore;
    // Update is called once per frame
    private void Start()
    {
        yourScore = PlayerPrefs.GetInt("Score");
        yourScoreText.text = "Your score: " + yourScore.ToString();
        highScoreText.text = "Highscore: " + highScore.ToString();
    }
    void Update()
    {
        if(GameMaster.gm.lifes <= 0)
        {
            //ShowScore();
            deathUI.SetActive(true);
            yourScoreText.text = "Your score: " + PlayerPrefs.GetInt("Score").ToString();
            highScoreText.text = "Highscore: " + PlayerPrefs.GetInt("Highscore").ToString();
        }
    }

    public void ShowScore()
    {
        yourScore = PlayerPrefs.GetInt("Score");
        Debug.Log(yourScore);
        yourScoreText.text = "Your Score: "+ yourScore.ToString();
        highScore = PlayerPrefs.GetInt("Highscore");
        Debug.Log(highScore);
        highScoreText.text = "Highscore: " + highScore.ToString();
    }
}
