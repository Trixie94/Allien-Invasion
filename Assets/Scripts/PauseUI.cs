using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseUI : MonoBehaviour
{
    public GameObject pauseUI;
    private bool paused = false;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("escape") && paused == false)
        {
            paused = true;
            pauseUI.SetActive(true);
            Time.timeScale = 0.0f;
        }
        else if(Input.GetKeyDown("escape") && paused == true)
        {
            ResumeGame();
        }
    }

    public void ResumeGame()
    {
        Time.timeScale = 1.0f;
        pauseUI.SetActive(false);
        paused = false;
    }
}
