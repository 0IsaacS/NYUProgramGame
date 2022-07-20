using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    //fields
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.x > transform.position.x + 7.5)
        {
            transform.position = transform.position + new Vector3(20, 0, 0);
        }
    }
}
