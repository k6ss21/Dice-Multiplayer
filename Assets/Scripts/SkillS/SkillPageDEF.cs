using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class SkillPageDEF : MonoBehaviour, ISkillSaver
{

    public static event Action<List<SkillDetails>>  OnDEFSkillSave;
    public void Save(List<SkillDetails> list)
    {
        OnDEFSkillSave?.Invoke(list);
    }
}
