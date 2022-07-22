using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Fields
    private float moveMult = 3f, duration = 20f;
    [SerializeField] private Transform player;
    [SerializeField] private bool onGround;
    private bool facingRight;
    public bool isWalking;
    public Animator playerAnimator;
    public Stats stats;
    [SerializeField] private bool dJump;
    public AudioSource playerAudio;
    public AudioClip jumpSoundEffect;

    // Start is called before the first frame update
    void Start()
    {
        dJump = false;
        player = transform;
        facingRight = true;
        onGround = true;
        gameObject.layer = 1; //move this to another script later
        Time.timeScale = 1;
        playerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            StartCoroutine(move(Vector3.right));
            if (!facingRight)
            {
                transform.Rotate(new Vector3(0, 180, 0));
                facingRight = true;
            }
        }
        if (Input.GetKey(KeyCode.A))
        {
            StartCoroutine(move(Vector3.left));
            if (facingRight)
            {
                transform.Rotate(new Vector3(0, 180, 0));
                facingRight = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (dJump && !onGround)
            {
                dJump = false;
                jump(4);
            }
            if (onGround)
            {
                onGround = false;
                jump();
            }
        }
        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            isWalking = false;
        }

        if (isWalking)
        {
            playerAnimator.SetBool("isWalking", true);
        }
        else
        {
            playerAnimator.SetBool("isWalking", false);
        }
    }

    private IEnumerator move(Vector3 dir)
    {
        Debug.Log("Is moving");
        isWalking = true;
        dir /= moveMult;
        Vector3 target = transform.position + dir;
        Debug.Log(target);
        transform.position = Vector3.Lerp(transform.position, target, duration * Time.deltaTime);
        yield return null;
    }
    private void jump()
    {
        playerAudio.PlayOneShot(jumpSoundEffect);
        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, 0);
        GetComponent<Rigidbody2D>().AddForce(Vector3.up * 7, ForceMode2D.Impulse);
    }
    private void jump(float power)
    {
        playerAudio.PlayOneShot(jumpSoundEffect);
        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, 0);
        GetComponent<Rigidbody2D>().AddForce(Vector3.up * 7, ForceMode2D.Impulse);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            onGround = true;
            dJump = true;
            GetComponent<Rigidbody2D>().AddForce(Vector3.up, ForceMode2D.Force);
        }
        if (collision.gameObject.tag == "spikes")
        {
            stats.health = 0;
        }
    }
}
