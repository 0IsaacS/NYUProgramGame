using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonstersControl : MonoBehaviour
{
    public EnemyAnimationControl[] enemyParts;
    public GameObject player;
    private bool isAttacking;

    // Start is called before the first frame update
    void Start()
    {
        isAttacking = false;
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (!((Mathf.Abs(transform.position.x - player.transform.position.x) > 3f || Mathf.Abs(transform.position.y - player.transform.position.y) > 0.5f) && !isAttacking))
        {
            StartCoroutine(Attack());
        }
    }

    public IEnumerator Attack()
    {
        for (int i = 0; i < enemyParts.Length; i++)
        {
            enemyParts[i].Attack();
        }
        isAttacking = true;
        yield return new WaitForSeconds(1);
        isAttacking = false;
    }

    public IEnumerator OnHit()
    {
        for (int i = 0; i < enemyParts.Length; i++)
        {
            enemyParts[i].OnHit();
        }
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            StartCoroutine(OnHit());
        }
    }
}
