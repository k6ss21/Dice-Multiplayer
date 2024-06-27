using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;
using UnityEngine.InputSystem;
public class Player : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform shootPosition;

    PlayerReferences playerReferences;

    

    private void Start()
    {
        playerReferences = GetComponent<PlayerReferences>();
       

    }

    public void Shoot()
    {
        Debug.Log("Shooting");
        GameObject obj = Instantiate(bulletPrefab, shootPosition.position, Quaternion.identity);
        if (playerReferences.enemyPlayer != null)
        {
            if (playerReferences.los.enemyOnSight)
            {
                obj.GetComponent<Bullet>().SetTarget(playerReferences.enemyPlayer.gameObject);
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
