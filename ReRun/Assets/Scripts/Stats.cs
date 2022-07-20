using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    //Fields
    public int health = 1, maxHealth = 5;
    public GenerateLevel gl;
    public HealthUI hUI;

    // Start is called before the first frame update
    void Start()
    {
        gl = GameObject.Find("GameManager").GetComponent<GenerateLevel>();
        hUI = GameObject.FindWithTag("HeartManager").GetComponent<HealthUI>();
        hUI.updateHealth();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -gl.piecesToGenerate * 3)
        {
            health = 0;
        }
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
    void takeDamage()
    {
        health--;
        hUI.updateHealth();
    }
    void heal()
    {
        health++;
        hUI.updateHealth();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "EnemyProjectile")
        {
            takeDamage();
        }
        if (collision.gameObject.tag == "HealthUp")
        {
            if (health < maxHealth)
            {
                heal();
            }
            Destroy(collision.gameObject);
        }
    }
}
