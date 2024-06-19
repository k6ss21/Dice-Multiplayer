using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using TMPro;
using Unity.VisualScripting;
using Unity.VisualScripting.ReorderableList;
using UnityEditor;
using UnityEngine;

public class SkillAssign : MonoBehaviour
{
    public SkillSlot[] skillSlot;

    public SkillSlot selectedSlot;

    public List<SkillCard> assignedSkills;

    public List<SkillCard> allSkills;


    private void Start()
    {

        RestSelect();
        DisableAfterSelected();
        UpdateSlotUI();
    }

    public void SelectSlot(SkillSlot slot)
    {
        selectedSlot = slot;
        RestSelect();
    }

    public void RestSelect()
    {
        foreach (SkillSlot item in skillSlot)
        {
            item.isSelected = false;
        }
    }



    public void AssignSkillToSlot(SkillCard skillCard)
    {
        if(selectedSlot == null) return;
        assignedSkills.RemoveAt(selectedSlot.slotNumber - 1 );
        assignedSkills.Insert(selectedSlot.slotNumber - 1 , skillCard);
        UpdateSlotUI();
        DisableAfterSelected();
        //  assignedSkills.Add(skillCard);

    }

    void DisableAfterSelected()
    {
        foreach(SkillCard item in allSkills)
        {
             item.Disable(false);
        }
        foreach (SkillCard item in assignedSkills)
        {
            item.Disable(true);
        }
    }

    void UpdateSlotUI()
    {
        for (int i = 0; i < skillSlot.Length; i++)
        {
            skillSlot[i].GetComponentInChildren<TextMeshProUGUI>().text = assignedSkills[i].name.ToString();
        }
    }


}
