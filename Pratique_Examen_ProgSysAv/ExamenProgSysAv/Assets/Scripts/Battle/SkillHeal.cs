using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Skill", menuName = "Skills/Heal")]
public class SkillHeal : SkillMagic
{
    public override SkillTarget Target => SkillTarget.ALLY;

    public int Force = 1;

    public override IEnumerator Execute(Fighter caster, Fighter target)
    {
        yield return base.Execute(caster, target);

        caster.CurrentMP -= MpCost;
        target.CurrentHP += Force;
    }
}