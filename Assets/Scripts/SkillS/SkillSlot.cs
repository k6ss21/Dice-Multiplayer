using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.Interactions;

public class SkillSlot : MonoBehaviour, IDropHandler, IPointerClickHandler
{
    public int slotNumber;
    public bool isSelected;
    public void OnDrop(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        GetComponentInParent<SkillAssign>().SelectSlot(this);
        isSelected = true;
    }
}
