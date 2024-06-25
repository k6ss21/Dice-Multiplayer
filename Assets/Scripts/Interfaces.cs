using UnityEngine;
using System;
using System.Collections.Generic;

public interface ISkillSaver
{
     void Save(List<SkillDetails> list);
}

public interface IDamageable
{
     void TakeDamage(float damage);
}

