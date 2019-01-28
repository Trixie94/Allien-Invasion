using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneOnClick : MonoBehaviour
{
    public void LoadByIndex(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
        Time.timeScale = 1.0f;
    }

    public void LoadEasy()
    {
        GlobalControl.Instance.lifes = 3;
        SceneManager.LoadScene(2);
    }

    public void LoadNormal()
    {
        GlobalControl.Instance.lifes = 2;
        SceneManager.LoadScene(2);
    }

    public void LoadHard()
    {
        GlobalControl.Instance.lifes = 1;
        SceneManager.LoadScene(2);
    }
}
