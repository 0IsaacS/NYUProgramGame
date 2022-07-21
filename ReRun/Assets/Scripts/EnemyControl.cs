using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    public EnemyAnimationControl[] enemyParts;
    public BossAI self;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Attack()
    {
        for (int i = 0; i < enemyParts.Length; i++)
        {
            enemyParts[i].Attack();
        }
    }

    public void OnHit()
    {
        for (int i = 0; i < enemyParts.Length; i++)
        {
            enemyParts[i].OnHit();
        }
        self.health--;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            OnHit();
        }
    }
}
