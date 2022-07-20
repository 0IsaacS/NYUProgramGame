using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    //Fields
    public int health = 3;
    public GenerateLevel gl;

    // Start is called before the first frame update
    void Start()
    {
        gl = GameObject.Find("GameManager").GetComponent<GenerateLevel>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -gl.piecesToGenerate * 3)
        {
            takeDamage(); takeDamage(); takeDamage();
        }
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
    void takeDamage()
    {
        health--;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "EnemyProjectile")
        {
            takeDamage();
        }
    }
}
