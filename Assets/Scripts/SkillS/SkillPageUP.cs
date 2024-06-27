using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class SkillPageUP : MonoBehaviour, ISkillSaver
{

    public static event Action<List<SkillDetails>>  OnUPSkillSave;
    public void Save(List<SkillDetails> list)
    {
        OnUPSkillSave?.Invoke(list);
    }
}
