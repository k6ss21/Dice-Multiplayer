using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
public class Skill_DamageUp_Button : MonoBehaviour
{
     [SerializeField] Button button;
    [SerializeField] float damageAmount;

    public static event Action<float> OnDamageChange;

    private void Awake()
    {
        button.onClick.AddListener(() =>
        {
            DamageUp();
        });

    }


    void DamageUp()
    {
        OnDamageChange?.Invoke(damageAmount);
        StartCoroutine(DamageResetTimer());
    }

    IEnumerator DamageResetTimer ()
    {
        yield return new WaitForSeconds(10f);
        OnDamageChange?.Invoke(10f);

    }
}
