using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    //Fields
    public int health = 1, maxHealth = 5;
    public GenerateLevel gl;
    public HealthUI hUI;
    public GameObject gameOverScreen;
    private bool isInvincible = false;
    [SerializeField] private FireWeapon selfFire;
    public AudioSource playerAudio;
    public AudioClip onHitSoundEffect;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        gl = GameObject.Find("GameManager").GetComponent<GenerateLevel>();
        hUI = GameObject.FindWithTag("HeartManager").GetComponent<HealthUI>();
        hUI.updateHealth();
        playerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -gl.piecesToGenerate * 10)
        {
            health = 0;
        }
        if (health <= 0)
        {
            die();
        }
    }
    void takeDamage()
    {
        if (!isInvincible)
        {
            health--;
            playerAudio.PlayOneShot(onHitSoundEffect);
            hUI.updateHealth();
            StartCoroutine(tempInvincibility(1f));
        }
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
        if (collision.gameObject.tag == "RapidFire")
        {
            if (!selfFire.rapidFire)
            {
                StartCoroutine(tempRapidFire());
                Destroy(collision.gameObject);
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            takeDamage();
        }
    }
    void die()
    {
        gameOver();
        Destroy(gameObject);
    }

    void gameOver()
    {
        gameOverScreen.SetActive(true);
        Time.timeScale = 0;
    }
    IEnumerator tempInvincibility(float seconds)
    {
        isInvincible = true;
        yield return new WaitForSeconds(seconds);
        isInvincible = false;
    }

    IEnumerator tempRapidFire()
    {
        selfFire.rapidFire = true;
        yield return new WaitForSeconds(7);
        selfFire.rapidFire = false;
    }
}
