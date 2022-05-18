using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timerBoost : MonoBehaviour
{
    public int startingHealth = 1;
    public int currentHealth;
    public int timerAmount = 10; 
    public GameObject controller;
    Timer timerUp;

    void Awake()
    {
        currentHealth = startingHealth;
        timerUp = controller.GetComponent<Timer>();
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
            timerUp.addTime(timerAmount);
        }
    }
}
