using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [System.Serializable]
    public class BossStats
    {
        public int maxHealth = 400;
        public int damage;
        public float speed;
        public Sprite[] sprites;
        public int sprite;
        private int _curHealth;
        public int curHealth
        {
            get { return _curHealth; }
            set { _curHealth = Mathf.Clamp(value, 0, maxHealth); }
        }
        public void Init()
        {
            curHealth = maxHealth;
            
        }
    }
    //public Transform bossPrefab;
    public BossStats stats = new BossStats();
    public Transform target;
    private Vector3 startPos;
    private Vector3 temp;
    public GameObject endGameUI;
    // Start is called before the first frame update
    void Start()
    {
        stats.Init();
        this.GetComponent<SpriteRenderer>().sprite = stats.sprites[3];
        stats.sprite = 3;
        startPos = transform.position;
    }

    private void Update()
    {
        if (stats.curHealth <= 300 && stats.sprite == 3)
        {
            this.GetComponent<SpriteRenderer>().sprite = stats.sprites[2];
            stats.sprite = 2;
        }else if(stats.curHealth <= 200 && stats.sprite == 2)
        {
            this.GetComponent<SpriteRenderer>().sprite = stats.sprites[1];
            stats.sprite = 1;
        }else if(stats.curHealth <= 100 && stats.sprite == 1)
        {
            this.GetComponent<SpriteRenderer>().sprite = stats.sprites[0];
            stats.sprite = 0;
        }
        if(transform.position != target.position)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, stats.speed * Time.smoothDeltaTime);
        }
        else if(target.position == startPos)
        {
            target.position = temp;
        }
        else
        {
            temp = target.position;
            target.position = startPos;
        }
    }
    public void DamageEnemy(int damage)
    {
        stats.curHealth -= damage;
        if (stats.curHealth <= 0)
        {
            GameMaster.KillBoss(this);
            endGameUI.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
