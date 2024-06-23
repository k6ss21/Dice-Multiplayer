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

    public GameObject enemyPlayer;

    private void Start()
    {

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
                obj.GetComponent<Bullet>().SetTarget(enemyPlayer);
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
