using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemy : MonoBehaviour
{
   public bool moveBot = false;
   bool moveRight;
   public float moveSpeed = 10f;
    private void Start()
    {
        StartCoroutine(MoveEnemy());
    }

    private void FixedUpdate() {
        if(moveRight)
        {
            transform.Translate(Vector3.right*moveSpeed *Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.left*moveSpeed *Time.deltaTime);
        }
    }

    IEnumerator MoveEnemy()
    {
        while (moveBot)
        {
            moveRight = true;
            yield return new WaitForSeconds(1f);
            moveRight = false;
            yield return new WaitForSeconds(1f);
        }

    }
}
