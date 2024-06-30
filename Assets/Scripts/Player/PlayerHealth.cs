using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
public class PlayerHealth : MonoBehaviour, IDamageable
{
    [SerializeField] float playerHealth;
    float currentHealth;

    public Image fillImage;
    public bool barUpdate;
    public float lerpSpeed;

    private void OnEnable()
    {
        Skill_HealUp_Button.OnHealUpPress += TakeHealth;
    }
    private void OnDisable()
    {
        Skill_HealUp_Button.OnHealUpPress -= TakeHealth;
    }

    private void Start()
    {
        barUpdate = false;
        currentHealth = playerHealth;
        if (fillImage != null)
        {
            fillImage.fillAmount = currentHealth / playerHealth;
        }
    }

    private void Update()
    {
        if (barUpdate)
        {
            lerpSpeed = 3f * Time.deltaTime;
            HealthBarFiller();
        }
    }
    public void DealDamage(float value)
    {
        currentHealth -= value;
        barUpdate = true;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
        }
    }

    public void TakeHealth(float value)
    {
        currentHealth += value;
        barUpdate = true;
        if (currentHealth >= playerHealth)
        {
            currentHealth = playerHealth;
        }
    }

    public void HealthBarFiller()
    {
        if (fillImage != null)
        {
            float smoothHealth = Mathf.Lerp(fillImage.fillAmount, currentHealth / playerHealth, lerpSpeed);
            // Debug.Log("Smooth Health = " + smoothHealth + "Current Health = " + currentHealth/playerHealth);
            fillImage.fillAmount = smoothHealth;
            if ((int)currentHealth == (int)(smoothHealth * playerHealth))
            {
                barUpdate = false;
            }
        }
    }

    public void TakeDamage(float damage)
    {
        DealDamage(damage);
    }
}
