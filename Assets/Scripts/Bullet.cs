using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float bulletSpeed = 15f;
    [SerializeField] float angleChangingSpeed = 15f;
    Vector3 direction;
    Rigidbody rb;

    GameObject target;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        // target = GameObject.FindGameObjectWithTag("Enemy");
    }

    void FixedUpdate()
    {
        BulletMovement();
    }

    public void SetDirection(Vector3 dir)
    {
        direction = dir;
    }

    public void SetTarget(GameObject enemy)
    {
        target = enemy;
    }

    void BulletMovement()
    {
        if (target != null)
        {
            direction = target.transform.position - rb.position;
            direction.Normalize();
            // float rotateAmount = Vector3.Cross(direction, transform.up).z;
            // rb.maxAngularVelocity = -angleChangingSpeed * rotateAmount;
            rb.velocity = direction * bulletSpeed * Time.deltaTime;
        }
        else{
            rb.velocity = direction * bulletSpeed * Time.deltaTime;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("HIT ENEMY!!!");
            Destroy(gameObject);
            // Destroy(other.gameObject);
        }
    }

}
