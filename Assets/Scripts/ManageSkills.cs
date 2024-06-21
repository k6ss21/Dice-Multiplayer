using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageSkills : MonoBehaviour
{
    public List<SkillDetails> skillsDetails_ATT;
    public List<SkillDetails> skillsDetails_DEF;
    public List<SkillDetails> skillsDetails_UP;


    private void OnEnable()
    {
        SkillpageATT.OnATTSkillSave += AddATTList;
        SkillPageDEF.OnDEFSkillSave += AddDEFList;
        SkillPageUP.OnUPSkillSave += AddUPList;
    }

    private void OnDisable()
    {
        SkillpageATT.OnATTSkillSave -= AddATTList;
        SkillPageDEF.OnDEFSkillSave -= AddDEFList;
        SkillPageUP.OnUPSkillSave -= AddUPList;
    }

    void AddATTList(List<SkillDetails> list)
    {
        skillsDetails_ATT = list;
    }
     void AddDEFList(List<SkillDetails> list)
    {
        skillsDetails_DEF = list;
    }
     void AddUPList(List<SkillDetails> list)
    {
        skillsDetails_UP = list;
    }

}
