using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAI : MonoBehaviour
{
    //Fields
    public Transform player, self;
    private bool attacking = false;
    [SerializeField] private EnemyAnimationControl ac;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindWithTag("Player").transform;

        if (Mathf.Abs(self.position.x - player.position.x) > 3f && !attacking)
        {
            StartCoroutine(moveToPlayer());
        }
        else
        {
            attack();
        }
    }

    IEnumerator moveToPlayer()
    {
        self.position = Vector3.Lerp(self.position, player.position, 2 * Time.deltaTime);
        yield return null;
    }
    void attack()
    {
        attacking = true;
        ac.Attack();
        attacking = false;
    }
}