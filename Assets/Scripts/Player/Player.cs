
using UnityEngine;
using UnityEngine.InputSystem;
public class Player : MonoBehaviour
{
    float damage;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform shootPosition;

    [SerializeField]PlayerReferences playerReferences;

    void OnEnable()
    {
        Skill_DamageUp_Button.OnDamageChange += ChangeDamage;
    }

    private void OnDisable()
    {
        Skill_DamageUp_Button.OnDamageChange -= ChangeDamage;
    }



    void ChangeDamage(float amount)
    {
        damage = amount;
    }

    public void Shoot()
    {
        // Debug.Log("Shooting");
        GameObject obj = Instantiate(bulletPrefab, shootPosition.position, Quaternion.identity);
        if (playerReferences.enemyPlayer != null)
        {
            Debug.Log("Enemy Shoot");
            Bullet bullet = obj.GetComponent<Bullet>();
            bullet.SetDamage(damage);
            if (playerReferences.los.enemyOnSight)
            {
                bullet.SetTarget(playerReferences.enemyPlayer.gameObject);
            }
            else
            {
                bullet.SetDirection(transform.forward);
            }
        }
        else
        {
            Debug.Log("No Enemy Found");
        }

    }

    public void OnShoot(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Shoot();
        }
    }


}
