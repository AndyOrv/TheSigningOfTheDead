using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class playerHealth : MonoBehaviour
{
    public int startingHealth = 3;                           
    public int currentHealth;
    public Image damageImage;
    public Image hP1;
    public Image hP2;
    public Image hP3;
    public float flashSpeed;                              
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);

    bool damaged = false;

    void Awake()
    {
        currentHealth = startingHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (damaged == true)
        {
            damageImage.color = flashColour;
        }
        else
        {
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }

        damaged = false;
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth == 2)
        {
            Destroy(hP1);
        }

        if (currentHealth == 1)
        {
            Destroy(hP2);
        }
        if (currentHealth == 0)
        {
            Destroy(hP3);
        }
        damaged = true;
    }
}
