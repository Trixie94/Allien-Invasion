using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpecialAbility : MonoBehaviour
{
    private float theta, x, y;
    public GameObject miniRocketPrefab;
    private Player player;
    public float radius = 1;
    public GameObject holder;

    private void Start()
    {
        SpawnCircle();
    }
    public void SpawnCircle()
    {
        //Instantiate(holder, player.transform.position, Quaternion.identity);
        holder = Instantiate(holder, transform.position, Quaternion.identity);
        for (int i=0; i < 12; i++)
        {
            theta = i * 2 * Mathf.PI / 12;
            x = Mathf.Sin(theta) * radius;
            y = Mathf.Cos(theta) * radius;
            GameObject clone = Instantiate(miniRocketPrefab, player.transform.position + new Vector3(x, y, 0), Quaternion.identity);
            //Instantiate(miniRocketPrefab, player.transform.position + new Vector3(x, y, 0), Quaternion.identity);
            clone.transform.parent = holder.transform;
        }
    }
}

