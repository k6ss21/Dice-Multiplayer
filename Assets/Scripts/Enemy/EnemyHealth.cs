using UnityEngine;
using UnityEngine.UI;
public class EnemyHealth : MonoBehaviour,IDamageable
{
    [SerializeField] float enemyHealth;
    float currentHealth;

    public Image fillImage;
    public bool barUpdate;
    public float lerpSpeed;

    private void Start()
    {
        barUpdate = false;
        currentHealth = enemyHealth;
        if (fillImage != null)
        {
            fillImage.fillAmount = currentHealth / enemyHealth;
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
        if (currentHealth >= enemyHealth)
        {
            currentHealth = enemyHealth;
        }
    }

    public void HealthBarFiller()
    {
        if (fillImage != null)
        {
            float smoothHealth = Mathf.Lerp(fillImage.fillAmount, currentHealth / enemyHealth, lerpSpeed);
            // Debug.Log("Smooth Health = " + smoothHealth + "Current Health = " + currentHealth/playerHealth);
            fillImage.fillAmount = smoothHealth;
            if ((int)currentHealth == (int)(smoothHealth * enemyHealth))
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
