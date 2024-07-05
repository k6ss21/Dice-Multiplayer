using System;
using UnityEngine;
using UnityEngine.UI;
public class PlayerHealth : MonoBehaviour, IDamageable
{
    [SerializeField] float playerHealth;
    float currentHealth;

     Image fillImage;
    public bool barUpdate;
    public float lerpSpeed;

    PlayerReferences playerReferences;

    public static event Action OnPlayerDead;

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
       // playerReferences = GetComponent<PlayerReferences>();
        fillImage = GameObject.FindWithTag("Player Health Bar").GetComponent<Image>();
        barUpdate = false;
        currentHealth = playerHealth;
        if (fillImage != null)
        {
            fillImage.fillAmount = currentHealth / playerHealth;
        }
        else
        {
            Debug.LogError("Fill Image Not Found");
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
            PlayerDead();
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
         else
        {
            Debug.LogError("Fill Image Not Found");
        }
    }

    public void TakeDamage(float damage)
    {
        DealDamage(damage);
    }

    void PlayerDead()
    {
        OnPlayerDead?.Invoke();
    }
}
