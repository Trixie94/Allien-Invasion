using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawKill : MonoBehaviour
{
    GameMaster gm;
    Player player;
    // Start is called before the first frame update
    void Update()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player.DamagePlayer(9999);
        }
    }
}
