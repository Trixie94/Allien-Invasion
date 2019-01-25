using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameTeleport : MonoBehaviour
{
    public GameObject endGameUI; // Gameobject that stores Panel from UI.

    public void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")   // Check if object collides with it has proper tag.
        {
            if (GameMaster.gm.keyAcquired == true)
            {
            }
        }
    }
}
