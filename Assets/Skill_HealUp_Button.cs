using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Skill_HealUp_Button : MonoBehaviour
{
    [SerializeField] Button button;
    [SerializeField] float healAmount;

    public static event Action<float> OnHealUpPress;

    private void Awake()
    {
        button.onClick.AddListener(() =>
        {
            HealUp();
        });

    }


    void HealUp()
    {
        OnHealUpPress?.Invoke(healAmount);
    }

}
