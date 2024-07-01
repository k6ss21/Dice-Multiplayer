using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEditor.U2D;
public class Skill_MoveSpeedUp_Button : MonoBehaviour
{
    [SerializeField] Button button;
     float defaultSpeedUpMulti = 1f;
    [SerializeField] float speedUpMulti = 2f;

    public static event Action<float> OnMoveSpeedUpPress;

    private void Awake()
    {
        button.onClick.AddListener(() =>
        {
            HealUp();
        });

    }


    void HealUp()
    {
        OnMoveSpeedUpPress?.Invoke(speedUpMulti);
        StartCoroutine(SpeedResetTimer());
    }

        IEnumerator SpeedResetTimer ()
    {
        yield return new WaitForSeconds(10f);
        OnMoveSpeedUpPress?.Invoke(defaultSpeedUpMulti);

    }
}
