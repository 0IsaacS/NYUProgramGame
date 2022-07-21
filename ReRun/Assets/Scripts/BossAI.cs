using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAI : MonoBehaviour
{
    //Fields
    public int health = 5;
    public Transform player, self;
    private bool attacking = false;
    [SerializeField] private EnemyControl ac;
    [SerializeField] private Transform bound;
    private Vector3 startPos;

    // Start is called before the first frame update
    void Awake()
    {
        bound = GameObject.FindWithTag("bossbound").transform;
        player = GameObject.FindWithTag("Player").transform;
        startPos = self.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindWithTag("Player").transform;

        if (self.position.x > bound.position.x && bound.position.x - player.position.x < 0)
        {

            if (Mathf.Abs(self.position.x - player.position.x) > 3f && !attacking)
            {
                StartCoroutine(moveToPlayer());
            }
            else
            {
                attack();
            }

        }
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator moveToPlayer()
    {
        self.position = Vector3.Lerp(self.position, player.position, 0.5f * Time.deltaTime);
        yield return null;
    }
    void attack()
    {
        attacking = true;
        ac.Attack();
        attacking = false;
    }
}
