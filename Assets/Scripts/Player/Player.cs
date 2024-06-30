
using UnityEngine;
using UnityEngine.InputSystem;
public class Player : MonoBehaviour
{
    float damage;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform shootPosition;

    PlayerReferences playerReferences;

    void OnEnable()
    {
        Skill_DamageUp_Button.OnDamageChange += ChangeDamage;
    }

    private void OnDisable()
    {
         Skill_DamageUp_Button.OnDamageChange += ChangeDamage;
    }



    private void Start()
    {
        playerReferences = GetComponent<PlayerReferences>();


    }

    void ChangeDamage(float amount)
    {
        damage = amount;
    }

    public void Shoot()
    {
        Debug.Log("Shooting");
        GameObject obj = Instantiate(bulletPrefab, shootPosition.position, Quaternion.identity);
        if (playerReferences.enemyPlayer != null)
        {
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

    }

    public void OnShoot(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Shoot();
        }
    }


}
