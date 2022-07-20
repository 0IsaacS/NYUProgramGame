using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWeapon : MonoBehaviour {
    //Fields
    public GameObject weaponPrefab;
    public Animator playerAnimator;
    [SerializeField] private Transform firePoint;
    public PlayerControl player;
    public bool hasFired;

    // Start is called before the first frame update
    void Start() {
        hasFired = false;
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.F) && !hasFired) {
            StartCoroutine(fire());
        }
    }

    IEnumerator fire() {
        playerAnimator.SetBool("isAttacking", true);
        hasFired = true;
        yield return new WaitForSeconds(1);
        Instantiate(weaponPrefab, firePoint.position, player.transform.rotation);
        hasFired = false;
        playerAnimator.SetBool("isAttacking", false);
    }
}