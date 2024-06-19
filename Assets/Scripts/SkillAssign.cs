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
        assignedSkills.RemoveAt(selectedSlot.slotNumber - 1 );
        assignedSkills.Insert(selectedSlot.slotNumber - 1 , skillCard);
        //  assignedSkills.Add(skillCard);

    }

    void DisableAfterSelected(SkillCard skillCard)
    {
        foreach(SkillCard item in allSkills)
        {
            item.disable = false;
        }
    }


}
