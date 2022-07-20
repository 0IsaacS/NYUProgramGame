using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    public EnemyAnimationControl[] enemyParts;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z)) {
            Attack();
        }

        if (Input.GetKeyDown(KeyCode.X)) {
            OnHit();
        }
    }

    public void Attack() {
        for(int i = 0; i < enemyParts.Length; i++) {
            enemyParts[i].Attack();
        }
    }

    public void OnHit() {
        for (int i = 0; i < enemyParts.Length; i++) {
            enemyParts[i].OnHit();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Projectile")) {
            OnHit();
        }
    }
}
