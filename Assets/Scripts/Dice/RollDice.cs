using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;
using Random = UnityEngine.Random;
using System.Threading;
public class RollDice : MonoBehaviour
{

    public bool enable;
    Vector3 startPos;
    Quaternion startRotation;
    NewPlayerInput otherInput;
    Rigidbody rb;
    [SerializeField] float minRandomForceValue, maxRandomForceValue, startRollingForce;

    private float forceX, forceY, forceZ;

    public int rollCount =0;



    private void Awake()
    {
        enable = true;
        otherInput = new NewPlayerInput();

    }


    void OnEnable()
    {
        otherInput.Enable();
    }

    private void OnDisable()
    {
        otherInput.Disable();
    }

    private void Start()
    {
        startPos = transform.position;
        startRotation = transform.rotation;
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;

    }

    private void Update()
    {
        if (enable)
        {
            if (otherInput.Other.RollDice.WasPerformedThisFrame())
            {
                DiceRoll();
            }
        }
        if (otherInput.Other.ResetDice.WasPerformedThisFrame())
        {
            ResetDice();
        }

    }

    private void DiceRoll()
    {
        rollCount++;
        rb.isKinematic = false;
        enable = false;
        forceX = Random.Range(minRandomForceValue, maxRandomForceValue);
        forceY = Random.Range(minRandomForceValue, maxRandomForceValue);
        forceZ = Random.Range(minRandomForceValue, maxRandomForceValue);

        rb.AddForce(Vector3.up * startRollingForce);
        rb.AddTorque(forceX, forceY, forceZ);
    }

    public void ResetDice()
    {
        transform.position = startPos;
        transform.rotation = startRotation;
        rb.isKinematic = true;
    }
}
