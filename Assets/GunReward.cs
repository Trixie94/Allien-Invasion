using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunReward : MonoBehaviour
{
    public GameObject plasmaGun;
    public GameObject pistol;
    // Start is called before the first frame update

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            gameObject.SetActive(false);
            pistol.gameObject.SetActive(false);
            plasmaGun.gameObject.SetActive(true);
            GlobalControl.Instance.plasmaGunBool = true;
        }
    }
}
