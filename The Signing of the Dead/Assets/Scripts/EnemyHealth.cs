using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int startingHealth = 3;
    public int currentHealth;
    public GameObject hurtFlash;
    bool damaged;
    

    void Awake()
    {
        currentHealth = startingHealth;
    }

    void Update()
    {
        if (damaged == true)
        {
            Instantiate(hurtFlash, transform.position, transform.rotation);
        }

        damaged = false;

        if (Input.GetKeyDown(KeyCode.K))
        {
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        damaged = true;

        if (currentHealth <= 0)
        {
            Destroy(gameObject);        
        } 
    }
}
