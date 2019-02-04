using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevelSwitch : MonoBehaviour
{
    public GameObject endDoors;
    public Sprite newEndDoors;
    public Sprite greenSwitch;
    void OnCollisionEnter2D(Collision2D _colInfo)
    {
        Player _player = _colInfo.collider.GetComponent<Player>();
        if (_player != null)
        {
            //Destroy(gameObject);
            this.gameObject.GetComponent<SpriteRenderer>().sprite = greenSwitch;
            this.gameObject.GetComponent<PolygonCollider2D>().enabled = false;
            endDoors.GetComponent<SpriteRenderer>().sprite = newEndDoors;
            GameMaster.gm.keyAcquired = true;
        }
    }
}