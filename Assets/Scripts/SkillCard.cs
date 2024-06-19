using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SkillCard : MonoBehaviour, IPointerClickHandler
{

    private int tmpNumber = 1;

    public bool disable = false;

    SkillAssign skillAssign;

    private void Start() {
        skillAssign = FindObjectOfType<SkillAssign>();
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        skillAssign.AssignSkillToSlot(this);
       Debug.Log("Pointer Click");
    }

}
