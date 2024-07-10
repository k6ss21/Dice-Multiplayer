
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
public class Player : MonoBehaviour
{
    float damage;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform shootPosition;

    [SerializeField] PlayerReferences playerReferences;
    public  GameObject enemyPlayer;
    LineOfSight los;

    public Button button;

    private void Awake()
    {
        button = GameObject.FindGameObjectWithTag("ShootButton").GetComponent<Button>();
        button.onClick.AddListener(() =>
        {
            Shoot();
        });

    }

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
    private void Start()
    {
        //enemyPlayer = FindObjectOfType<EnemyAI>();
        // enemyPlayer = playerReferences.enemyPlayer;
       // StartCoroutine(Initialize());
        los = GetComponentInChildren<LineOfSight>();
    }

    IEnumerator Initialize()
    {
        yield return new WaitForSeconds(5f);
        Debug.Log("Initialize");

    }

    public void Shoot()
    {
        // Debug.Log("Shooting");

        GameObject obj = Instantiate(bulletPrefab, shootPosition.position, Quaternion.identity);
        if (enemyPlayer != null)
        {
            Debug.Log("Enemy Shoot");
            Bullet bullet = obj.GetComponent<Bullet>();
            bullet.SetDamage(damage);
            if (los.enemyOnSight)
            {
                bullet.SetTarget(enemyPlayer);
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
