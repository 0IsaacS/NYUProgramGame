using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    //fields
    public GameObject player;
    public float repeatWidth;
    // Start is called before the first frame update
    void Start()
    {
        repeatWidth = transform.GetChild(0).gameObject.GetComponent<BoxCollider2D>().size.x;
    }

    // Update is called once per frame
    void Update()
    {

        if (player != null)
        {
            if (player.transform.position.x > transform.position.x + repeatWidth)
            {
                transform.position = transform.position + new Vector3(repeatWidth, 0, 0);
            }
            if (player.transform.position.x < transform.position.x - repeatWidth)
            {
                transform.position = transform.position + new Vector3(-repeatWidth, 0, 0);
            }
        }
    }
}
