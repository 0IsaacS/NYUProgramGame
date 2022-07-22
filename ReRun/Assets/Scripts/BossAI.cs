using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossAI : MonoBehaviour
{
    //Fields
    public int health;
    public Transform player, self;
    private bool attacking = false;
    [SerializeField] private EnemyControl ac;
    [SerializeField] private Transform bound;
    private Vector3 startPos;
    public GameObject bossFightBGM;
    public GameObject normalBGM;
    public GameObject menuBGM;
    private bool isInBossFight;

    // Start is called before the first frame update
    void Awake()
    {
        health = 20;
        isInBossFight = false;
        bound = GameObject.FindWithTag("bossbound").transform;
        player = GameObject.FindWithTag("Player").transform;
        startPos = self.transform.position;
        bossFightBGM.gameObject.SetActive(false);
        menuBGM.gameObject.SetActive(false);
        normalBGM.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // if ! menu scene running..
        Scene scene = SceneManager.GetActiveScene();
        Debug.Log(scene.name);
        if(scene.name == "MenuScene" || player == null) {
            normalBGM.gameObject.SetActive(false);
            menuBGM.gameObject.SetActive(true);
            bossFightBGM.gameObject.SetActive(false);
        }

        else if(!isInBossFight) {
            menuBGM.gameObject.SetActive(false);
            normalBGM.gameObject.SetActive(true);
            bossFightBGM.gameObject.SetActive(false);
        }

        player = GameObject.FindWithTag("Player").transform;

        if (player.position.x < self.position.x)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        if (self.position.x > bound.position.x && bound.position.x - player.position.x < 0)
        {

            if ((Mathf.Abs(self.position.x - player.position.x) > 3f || Mathf.Abs(self.position.y - player.position.y) > 0.5f) && !attacking)
            {
                StartCoroutine(moveToPlayer());
            }
            else
            {
                StartCoroutine(attack());
            }

        }
        if (health <= 0)
        {
            bossFightBGM.gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }

    IEnumerator moveToPlayer()
    {
        normalBGM.gameObject.SetActive(false);
        bossFightBGM.gameObject.SetActive(true);
        isInBossFight = false;
        self.position = Vector3.Lerp(self.position, player.position, 0.5f * Time.deltaTime);
        yield return null;
    }
    IEnumerator attack()
    {
        attacking = true;
        ac.Attack();
        attacking = false;
        yield return null;
    }
}
