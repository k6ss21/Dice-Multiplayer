using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float damage;
    [SerializeField] float bulletSpeed = 15f;
    [SerializeField] float angleChangingSpeed = 15f;
    [SerializeField] float trackingDistanceLimit = 5f;
    Vector3 direction;
    Rigidbody rb;

    GameObject target;

    bool canTrack;


    [SerializeField] string colliderCheckTag = "Enemy";

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        canTrack = true;
        // target = GameObject.FindGameObjectWithTag("Enemy");
    }

    void FixedUpdate()
    {

        BulletMovement();
    }
    public void SetDamage(float amount)
    {
        damage = amount;
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

            TargetTracking();


            direction.Normalize();
            // float rotateAmount = Vector3.Cross(direction, transform.up).z;
            // rb.maxAngularVelocity = -angleChangingSpeed * rotateAmount;
            rb.velocity = direction * bulletSpeed * Time.deltaTime;
        }
        else
        {
            rb.velocity = direction * bulletSpeed * Time.deltaTime;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(colliderCheckTag))
        {
            other.GetComponent<IDamageable>().TakeDamage(damage);
            //  Debug.Log("HIT ENEMY!!!");
            Destroy(gameObject);
            // Destroy(other.gameObject);
        }
    }
    private void TargetTracking()
    {
        if (canTrack)
        {
            float distance = Vector3.Distance(target.transform.position, rb.position);
//            print(distance);
            if (distance >= trackingDistanceLimit)
            {
                direction = target.transform.position - rb.position;
            }

            else
            {
                canTrack = false;
            }
        }

    }
}
