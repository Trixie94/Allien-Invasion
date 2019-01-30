using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour {

    public static GameMaster gm;
    void Awake()
    {
        if (gm == null)
        {
            gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        }
        if(scene.name != "Level1")
        {
            gm.playerScore = PlayerPrefs.GetInt("Score");
        }

    }
    private void Start()
    {
        lifes = GlobalControl.Instance.lifes;
        plasmaGunBool = GlobalControl.Instance.plasmaGunBool;
        if (plasmaGunBool == true)
        {
            pistol.SetActive(false);
            plasmaGun.SetActive(true);
        }
    }
    public GameObject pistol;
    public GameObject plasmaGun;
    public bool plasmaGunBool;
    public Transform playerPrefab;
    public Transform spawnPoint;
    public int spawnDelay = 2;
    public GameObject spawnPrefab;
    public Scene scene;
    public CameraShake cameraShake;
    public int playerScore;
    public int lifes;
    public Player player;
    public bool keyAcquired = false;

    public IEnumerator _RespawnPlayer()
    {
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(spawnDelay);

        Instantiate(playerPrefab, spawnPoint.position, spawnPoint.rotation);
        //GameObject clone = Instantiate(spawnPrefab, spawnPoint.position, spawnPoint.rotation) as GameObject;
        //Destroy(clone, 3f);
    }
    public static void KillPlayer(Player player)
    {
        Destroy(player.gameObject);
        gm.StartCoroutine(gm._RespawnPlayer());
        gm.lifes -= 1;
    }

    public static void KillEnemy(Enemy enemy)
    {
        Destroy(enemy.gameObject);
        gm.playerScore += 10;
        PlayerPrefs.SetInt("Score", gm.playerScore);
    }

    public static void KillBoss(Boss boss)
    {
        Destroy(boss.gameObject);
        gm.playerScore += 250;
        PlayerPrefs.SetInt("Score", gm.playerScore);
    }
}