using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using UnityEngine;
using System;
public class FaceChecker : MonoBehaviour
{

    RollDice rollDice;

    public int diceNumber;

    public bool stop;
     public  static event Action<int> OnRollDiceEnd;

    private void Start()
    {
        stop = false;
        rollDice = FindObjectOfType<RollDice>();
    }
    void OnTriggerStay(Collider other)
    {

        if (rollDice.GetComponent<Rigidbody>().velocity == Vector3.zero && !stop)
        {
            Debug.Log(other.name);
            stop = true;
            diceNumber = int.Parse(other.name);
            OnRollDiceEnd.Invoke(diceNumber);
        }
    }
}