using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float playerHealth;
    float currentHealth;

    public void DealDamage(float value)
    {
        currentHealth -= value;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
        }
    }

    public void TakeHealth(float value)
    {
        currentHealth += value;
        if (currentHealth >= playerHealth)
        {
            currentHealth = playerHealth;
        }
    }
}   
