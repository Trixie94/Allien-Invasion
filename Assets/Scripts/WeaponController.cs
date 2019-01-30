using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public GameObject pistol;
    public GameObject plasmaGun;

    private void Start()
    {
        if(GameMaster.gm.plasmaGunBool == true)
        {
            pistol.SetActive(false);
            plasmaGun.SetActive(true);
        }
    }
}
