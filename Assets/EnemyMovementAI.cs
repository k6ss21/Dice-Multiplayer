using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovementAI : MonoBehaviour
{
    public bool moveBot = false;
    bool moveRight;
    public float moveSpeed = 10f;

    public Player target;

    [SerializeField] float pathFindingDelay;
    [SerializeField] float pathFindingTime;

    private NavMeshAgent navMeshAgent;


    private void Start()
    {
        target = FindObjectOfType<Player>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        StartCoroutine(MoveEnemyRoutine());
        Vector3 lookPos = target.transform.position - transform.position;
        lookPos.y = 0;
        Quaternion rotation = Quaternion.LookRotation(lookPos);
        transform.rotation =  rotation;

    }
    private void Update()
    {
        bool inRange = Vector3.Distance(target.transform.position, transform.position) <= 5f;
        Debug.Log(inRange);

        if (!inRange)
        {

            FollowTarget();
        }
        else
        {
            LootAtTargert();
        }
    }
    private void FixedUpdate()
    {


        if (moveBot)
        {
            MoveEnemy();
        }
    }

    void MoveEnemy()
    {
        if (moveRight)
        {
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        }
    }

    IEnumerator MoveEnemyRoutine()
    {
        while (moveBot)
        {
            moveRight = true;
            yield return new WaitForSeconds(1f);
            moveRight = false;
            yield return new WaitForSeconds(1f);
        }

    }

    void LootAtTargert()
    {
        Vector3 lookPos = target.transform.position - transform.position;
        lookPos.y = 0;
        Quaternion rotation = Quaternion.LookRotation(lookPos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 0.2f);
    }

    void FollowTarget()
    {
        if (Time.time >= pathFindingTime)
        {
            pathFindingTime = Time.time + pathFindingDelay;
            navMeshAgent.SetDestination(target.transform.position);
        }

    }
}
