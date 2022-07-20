using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyArcherControl : MonoBehaviour {
    public Animator archerAnimator;
    public float attackTime;
    public GameObject arrow;
    public Transform spawnPlace;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Z)) {
            Attack();
        }
    }

    IEnumerator WaitWhenAttacking(float seconds) {
        yield return new WaitForSeconds(seconds * 3 / 4);
        Instantiate(arrow, spawnPlace.position, transform.rotation);
        yield return new WaitForSeconds(seconds / 4);
        archerAnimator.SetBool("isAttacking", false);
    }

    public void Attack() {
        archerAnimator.SetBool("isAttacking", true);
        StartCoroutine(WaitWhenAttacking(attackTime));
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Projectile")) {
            
        }
    }
}
