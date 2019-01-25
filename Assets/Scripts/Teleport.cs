using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleport : MonoBehaviour
{
    Scene scene;
    public void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player") 
        {
            scene = SceneManager.GetActiveScene();
            if (scene.name == "Level1")
            {
                SceneManager.LoadScene("Level2");
            }
            if (scene.name == "Level2")
            {
                SceneManager.LoadScene("Level3");
            }
        }
    }
}
