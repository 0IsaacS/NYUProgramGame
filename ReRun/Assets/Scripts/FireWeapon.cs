using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWeapon : MonoBehaviour
{
    //Fields
    public GameObject weaponPrefab;
    private float velo = 10f;
    [SerializeField] private Transform firePoint;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            fire();
        }
    }

    private void fire()
    {
        GameObject make = Instantiate(weaponPrefab, firePoint.position, Quaternion.identity);
        make.GetComponent<Rigidbody2D>().velocity = firePoint.up * velo;
    }
}
