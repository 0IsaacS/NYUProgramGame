using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Fields
    private float moveMult = 3f, duration = 20f;
    [SerializeField] private Transform player;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            StartCoroutine(move(Vector3.right));
        }
        if (Input.GetKey(KeyCode.A))
        {
            StartCoroutine(move(Vector3.left));
        }
    }

    private IEnumerator move(Vector3 dir)
    {
        dir /= moveMult;
        Vector3 target = player.position + dir;
        player.position = Vector3.Lerp(player.position, target, duration * Time.deltaTime);
        yield return null;
    }
}
