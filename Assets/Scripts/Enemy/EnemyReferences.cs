using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyReferences : MonoBehaviour
{
    public Player player;
    public NavMeshAgent navMeshAgent;

    public void Start()
    {
        player = FindObjectOfType<Player>();
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

}
