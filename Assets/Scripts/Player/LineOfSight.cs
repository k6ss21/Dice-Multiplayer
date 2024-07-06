using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineOfSight : MonoBehaviour
{   

    public float VisionRange;

    public float VisionAngle;

    public LayerMask VisionObstructingLayer;
    public int VisionConeResolution = 120;

    public bool enemyOnSight;

    private void Start()
    {
        VisionAngle *= Mathf.Deg2Rad;
    }


    private void FixedUpdate()
    {
        //CheckEnemy();
    }

    // void CheckEnemy()  /// CHANGE THIS TO A COLLIDER WITH TRIGGER ENTER AND EXIT FUNTION !!!! 
    // {
    //     float Currentangle = -VisionAngle / 2;

    //     float angleIcrement = VisionAngle / (VisionConeResolution - 1);

    //     float Sine;

    //     float Cosine;

    //     for (int i = 0; i < VisionConeResolution; i++)

    //     {

    //         Sine = Mathf.Sin(Currentangle);

    //         Cosine = Mathf.Cos(Currentangle);

    //         Vector3 RaycastDirection = (transform.forward * Cosine) + (transform.right * Sine);

    //         Vector3 VertForward = (Vector3.forward * Cosine) + (Vector3.right * Sine);

    //         if (Physics.Raycast(transform.position, RaycastDirection, out RaycastHit hit, VisionRange, VisionObstructingLayer))

    //         {
    //             enemyOnSight = true;
    //              Debug.Log("Enemy Found" );
    //         }

    //         else

    //         {
    //            enemyOnSight = false;
    //            Debug.Log("No Enemy Found" );         
    //         }





    //         Currentangle += angleIcrement;

    //     }

    // }

   

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
          //  Debug.Log("Enemy in LOS!!! ");
            enemyOnSight = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            enemyOnSight = false;
           // Debug.Log("Enemy out of LOS!!! ");
        }
    }

}
