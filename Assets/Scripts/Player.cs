using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;
using UnityEngine.InputSystem;
public class Player : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform shootPosition;

    LineOfSight los;

     EnemyAI enemyPlayer;

    private void Start()
    {
        enemyPlayer = FindObjectOfType<EnemyAI>();
        los = GetComponentInChildren<LineOfSight>();
    }

    public void Shoot()
    {
        Debug.Log("Shooting");
        GameObject obj = Instantiate(bulletPrefab, shootPosition.position, Quaternion.identity);
        if (enemyPlayer != null)
        {
            if (los.enemyOnSight)
            {
                obj.GetComponent<Bullet>().SetTarget(enemyPlayer.gameObject);
            }
            else
            {
                obj.GetComponent<Bullet>().SetDirection(transform.forward);
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
