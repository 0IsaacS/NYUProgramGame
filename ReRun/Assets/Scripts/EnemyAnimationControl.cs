using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationControl : MonoBehaviour
{
    public float attackTime;
    public float onhitTime;
    private Animator attack;

    // Start is called before the first frame update
    void Start()
    {
        attack = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator WaitWhenAttacking(float seconds) {
        yield return new WaitForSeconds(seconds);
        attack.SetBool("isAttacking", false);
    }
    IEnumerator WaitWhenOnhit(float seconds) {
        yield return new WaitForSeconds(seconds);
        attack.SetBool("isOnhit", false);
    }

    public void Attack() {
        attack.SetBool("isAttacking", true);
        StartCoroutine(WaitWhenAttacking(attackTime));
    }

    public void OnHit() {
        attack.SetBool("isOnhit", true);
        StartCoroutine(WaitWhenOnhit(onhitTime));
    }
}
