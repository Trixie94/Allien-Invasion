using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGameUI : MonoBehaviour
{
    [SerializeField]
    private Text yourScoreText; // Field where Score text is Displayed.
    [SerializeField]
    private Text highScoreText; // Field where Highscore text is Displayed.
    private int yourScore;      // Score field.
    private int highScore;      // Highscore field.

    void Start()
    {
        yourScore = PlayerPrefs.GetInt("Score");    // Copy Score from PlayerPrefs.
        yourScoreText.text = "Your score: " + yourScore.ToString(); // Set Score Field with String and value.
        highScoreText.text = "Highscore: " + highScore.ToString();  // Set Highcore Field with String and value.
    }

    // Update is called once per frame
    void Update()
    {
        yourScoreText.text = "Your score: " + PlayerPrefs.GetInt("Score").ToString(); // Copy Score from PlayerPrefs each frame.
        highScoreText.text = "Highscore: " + PlayerPrefs.GetInt("Highscore").ToString(); // Copy Highscore from PlayerPrefs each frame.
    }
}