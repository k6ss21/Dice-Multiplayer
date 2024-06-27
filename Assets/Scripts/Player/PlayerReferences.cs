using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerReferences : MonoBehaviour
{
    public CharacterController cc;
    public Animator animator;

    public LineOfSight los;
    public EnemyAI enemyPlayer;

    void Start()
    {
        cc = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();
        los = GetComponentInChildren<LineOfSight>();
        enemyPlayer = FindObjectOfType<EnemyAI>();
    }
}
