using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidKill : MonoBehaviour
{
    GameMaster gm;
    Player player;
    // Start is called before the first frame update
    void Update()
    {
        if(player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player.DamagePlayer(9999);
        }
    }
}
