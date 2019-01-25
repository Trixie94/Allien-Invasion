using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public int currentWeapon;
    public Transform[] weapons;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            changeWeapon(0);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            changeWeapon(1);
        }
    }

    public void changeWeapon(int num)
    {
        //Debug.Log("num = " + num.ToString());
        //Debug.Log("weapons length = " + weapons.Length);
        for(int i = 0; i < weapons.Length; i++)
        {
            //Debug.Log("i = " + i.ToString());
            if(i == num)
            {
                weapons[i].gameObject.SetActive(true);
            }
            else
            {
                weapons[i].gameObject.SetActive(false);
            }
        }
    }
}
