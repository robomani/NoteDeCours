using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SkillTarget
{
    ALLY,
    ENNEMY
}

public abstract class FighterSkill : ScriptableObject
{
    public string Name = "Skill";
    public Sprite Icon = null;
    public string CasterAnimation = "battle_cast_magic";

    public abstract SkillTarget Target { get; }
    public virtual IEnumerator Execute(Fighter caster, Fighter target)
    {
        Debug.Log($"{caster.name} executes {Name} on {target.name}");
        yield break;
    }
}