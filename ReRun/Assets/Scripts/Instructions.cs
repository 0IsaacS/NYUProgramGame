using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instructions : MonoBehaviour
{
    public GameObject text;
    public GameObject seeThis;

    // Start is called before the first frame update
    void Start()
    {
        seeThis.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            text.gameObject.SetActive(true);
            seeThis.gameObject.SetActive(false);
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            text.gameObject.SetActive(false);
        }
    }
}
