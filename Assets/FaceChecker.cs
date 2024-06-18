using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using UnityEngine;

public class FaceChecker : MonoBehaviour
{

    RollDice rollDice;

    public int diceNumber;

    private void Start()
    {
        rollDice = FindObjectOfType<RollDice>();
    }
    void OnTriggerStay(Collider other)
    {
        if (rollDice.GetComponent<Rigidbody>().velocity == Vector3.zero)
        {
            Debug.Log(other.name);
            diceNumber = int.Parse(other.name);
        }
    }
}