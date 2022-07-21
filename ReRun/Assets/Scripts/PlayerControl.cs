using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    //Fields
    public float movingSpeed;
    [SerializeField] private Transform player;
    [SerializeField] private bool onGround;
    private bool facingRight;
    public Animator playerAnimator;
    private bool isMovingLeft;
    private bool isMovingRight;
    public FireWeapon fireWeapon;

    // Start is called before the first frame update
    void Start()
    {
        facingRight = true;
        gameObject.layer = 1; //move this to another script later
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            isMovingRight = true;

        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            isMovingLeft = true;

        }

        if (Input.GetKeyUp(KeyCode.D))
        {
            isMovingRight = false;
            playerAnimator.SetBool("isWalking", false);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            isMovingLeft = false;
            playerAnimator.SetBool("isWalking", false);
        }

        if (fireWeapon.hasFired)
        {
            isMovingLeft = isMovingRight = false;
        }

        if (isMovingRight)
        {
            playerAnimator.SetBool("isWalking", true);
            move(Vector3.right);
            if (!facingRight)
            {
                transform.Rotate(new Vector3(0, 180, 0));
                facingRight = true;
            }
        }
        else if (isMovingLeft)
        {
            playerAnimator.SetBool("isWalking", true);
            move(Vector3.right);
            if (facingRight)
            {
                transform.Rotate(new Vector3(0, 180, 0));
                facingRight = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space) && onGround)
        {
            jump();
        }
    }

    private void move(Vector3 dir)
    {
        transform.Translate(dir * movingSpeed * Time.deltaTime);
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
