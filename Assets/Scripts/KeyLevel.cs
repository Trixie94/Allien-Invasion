using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyLevel : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D _colInfo)
    {
        Player _player = _colInfo.collider.GetComponent<Player>();
        if (_player != null)
        {
            Destroy(gameObject);
            GameMaster.gm.keyAcquired = true;
            Debug.Log(GameMaster.gm.keyAcquired);
        }
    }
}
