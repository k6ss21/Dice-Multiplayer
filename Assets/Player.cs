using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class Player : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform shootPosition;

    public void Shoot()
    {
        Debug.Log("Shooting");
        GameObject obj = Instantiate(bulletPrefab,shootPosition.position, Quaternion.identity);
        obj.GetComponent<Bullet>().SetDirection(transform.forward);

    }

    public void OnShoot(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            Shoot();
        }
    }
}
