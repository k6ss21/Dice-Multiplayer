using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float bulletSpeed = 15f;
    Vector3 direction;
    Rigidbody rb;
  
    private void Start() {
        rb = GetComponent<Rigidbody>();
    }
    
    void FixedUpdate()
    {
        BulletMovement();
    }

    public void SetDirection(Vector3 dir)
    {
        direction = dir;
    }

    void BulletMovement()
    {
       rb.velocity = direction * bulletSpeed * Time.deltaTime;
        
    }
}
