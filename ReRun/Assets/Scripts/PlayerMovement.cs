using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Fields
    private float moveMult = 3f, duration = 20f;
    [SerializeField] private Transform player;
    private bool onGround;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.layer = 1; //move this to another script later
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            StartCoroutine(move(Vector3.right));
            if (GetComponent<SpriteRenderer>().flipX)
            {
                GetComponent<SpriteRenderer>().flipX = false;
            }
        }
        if (Input.GetKey(KeyCode.A))
        {
            StartCoroutine(move(Vector3.left));
            if (!GetComponent<SpriteRenderer>().flipX)
            {
                GetComponent<SpriteRenderer>().flipX = true;
            }
        }
        if (Input.GetKeyDown(KeyCode.Space) && onGround)
        {
            jump();
        }
    }

    private IEnumerator move(Vector3 dir)
    {
        dir /= moveMult;
        Vector3 target = player.position + dir;
        player.position = Vector3.Lerp(player.position, target, duration * Time.deltaTime);
        yield return null;
    }
    private void jump()
    {
        onGround = false;
        GetComponent<Rigidbody2D>().AddForce(Vector3.up * 10, ForceMode2D.Impulse);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            onGround = true;
            GetComponent<Rigidbody2D>().AddForce(Vector3.up, ForceMode2D.Force);
        }
    }
}
