using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileStuff : MonoBehaviour {
    //Fields
    private Vector3 startPos;

    // Start is called before the first frame update
    void Start() {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update() {
        transform.Translate(Vector2.right * 20 * Time.deltaTime);
        if (transform.position.x >= startPos.x + 50) {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag != "Player" && collision.gameObject.tag != "Projectile" && collision.gameObject.tag != "EnemyProjectile")
            Destroy(gameObject);
    }
}