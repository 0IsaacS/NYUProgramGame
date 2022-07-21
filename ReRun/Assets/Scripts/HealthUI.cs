using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUI : MonoBehaviour
{
    //Fields
    public Stats st;
    public GameObject[] hearts;

    // Start is called before the first frame update
    void Awake()
    {
        gameObject.layer = 1;
        st = GameObject.FindWithTag("Player").GetComponent<Stats>();
        hearts = GameObject.FindGameObjectsWithTag("Heart");
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void updateHealth()
    {
        for (int i = 0; i < st.health; i++)
        {
            hearts[i].SetActive(true);
        }
        for (int i = st.health; i < st.maxHealth; i++)
        {
            hearts[i].SetActive(false);
        }
    }
}
