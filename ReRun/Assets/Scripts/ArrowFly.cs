using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowFly : MonoBehaviour
{
    public float movingSpeed;
    private Vector3 positionZero;

    // Start is called before the first frame update
    void Start()
    {
        positionZero = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * movingSpeed * Time.deltaTime);

        if(transform.position.x - positionZero.x > 50 || transform.position.x - positionZero.x < -50) {
            Destroy(gameObject);
        }
    }
}
