using UnityEngine;
using System;
using System.Collections.Generic;

public class SkillpageATT : MonoBehaviour , ISkillSaver
{

    public static event Action<List<SkillDetails>>  OnATTSkillSave;
    public void Save(List<SkillDetails> list)
    {
        OnATTSkillSave?.Invoke(list);
    }

    
}
