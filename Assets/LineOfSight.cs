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


    private void Update()
    {
        CheckEnemy();
    }

    void CheckEnemy()
    {
        float Currentangle = -VisionAngle / 2;

        float angleIcrement = VisionAngle / (VisionConeResolution - 1);

        float Sine;

        float Cosine;

        for (int i = 0; i < VisionConeResolution; i++)

        {

            Sine = Mathf.Sin(Currentangle);

            Cosine = Mathf.Cos(Currentangle);

            Vector3 RaycastDirection = (transform.forward * Cosine) + (transform.right * Sine);

            Vector3 VertForward = (Vector3.forward * Cosine) + (Vector3.right * Sine);

            if (Physics.Raycast(transform.position, RaycastDirection, out RaycastHit hit, VisionRange, VisionObstructingLayer))

            {

                Debug.Log("Enemy Found" );
            }

            else

            {
                Debug.Log("No Enemy Found" );         
            }





            Currentangle += angleIcrement;

        }

    }

}
