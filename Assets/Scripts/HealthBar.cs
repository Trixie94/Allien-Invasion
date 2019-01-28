using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;

    private void Update()
    {
        if (GameMaster.gm.lifes == 2)
        {
            heart3.SetActive(false);
        }    
        else if (GameMaster.gm.lifes == 1)
        {
            heart3.SetActive(false);
            heart2.SetActive(false);
        }
        else if(GameMaster.gm.lifes == 0)
        {
            heart1.SetActive(false);
        }
    }
}
