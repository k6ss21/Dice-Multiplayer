using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class RollDice : MonoBehaviour
{
    Vector3 startPos;
    Quaternion startRotation;
    NewPlayerInput otherInput;
    Rigidbody rb;
    [SerializeField] float minRandomForceValue, maxRandomForceValue, startRollingForce;

    private float forceX, forceY, forceZ;

    private void Awake()
    {
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
        if (otherInput.Other.RollDice.WasPerformedThisFrame())
        {
            DiceRoll();
        }
        if (otherInput.Other.ResetDice.WasPerformedThisFrame())
        {
            ResetDice();
        }

    }

    private void DiceRoll()
    {
        rb.isKinematic = false;

        forceX = Random.Range(minRandomForceValue, maxRandomForceValue);
        forceY = Random.Range(minRandomForceValue, maxRandomForceValue);
        forceZ = Random.Range(minRandomForceValue, maxRandomForceValue);

        rb.AddForce(Vector3.up * startRollingForce);
        rb.AddTorque(forceX, forceY, forceZ);
    }

    private void ResetDice()
    {
        transform.position = startPos;
        transform.rotation = startRotation;
        rb.isKinematic = true;
    }
}
