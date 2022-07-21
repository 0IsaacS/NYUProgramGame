using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWeapon : MonoBehaviour
{
    //Fields
    public GameObject[] weaponPrefab;
    public Animator playerAnimator;
    [SerializeField] private Transform firePoint;
    public PlayerMovement player;
    public bool hasFired;

    // Start is called before the first frame update
    void Start()
    {
        hasFired = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && !hasFired)
        {
            StartCoroutine(fire());
        }
    }

    IEnumerator fire()
    {
        float waitLength = 0;
        bool term = false;
        foreach (AnimationClip clip in playerAnimator.runtimeAnimatorController.animationClips)
        {
            switch (clip.name)
            {
                case "Mag_Attack":
                    waitLength = clip.length;
                    term = !term;
                    break;
                default:
                    break;
            }
            if (term)
            {
                break;
            }
        }

        playerAnimator.SetBool("isAttacking", true);
        hasFired = true;
        yield return new WaitForSeconds(0.1f);
        int index = (int)Random.Range(0, weaponPrefab.Length);
        Instantiate(weaponPrefab[index], firePoint.position, player.transform.rotation);
        yield return new WaitForSeconds(waitLength);
        hasFired = false;
        playerAnimator.SetBool("isAttacking", false);
    }
}