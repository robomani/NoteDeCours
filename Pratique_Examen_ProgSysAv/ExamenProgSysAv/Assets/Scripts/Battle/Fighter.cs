using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum FighterState
{
    WAITING,
    READY_TO_CHOOSE_ACTION,
    READY_TO_ACT,
    DEAD
}

public class Fighter : MonoBehaviour {

    public CharacterAnimations renderer;

    public FighterSkill[] skills;
    
    public HeroStatusUI statusUI { get; set; }

    public FighterState State
    {
        get
        {
            if (m_CurrentHP <= 0)
            {
                return FighterState.DEAD;
            }
            else if (m_ProgressBar < m_Cooldown)
            {
                return FighterState.WAITING;
            }
            else if (NextSkill == null)
            {
                return FighterState.READY_TO_CHOOSE_ACTION;
            }
            else
            {
                return FighterState.READY_TO_ACT;
            }
        }
    }

    [SerializeField]
    private int m_CurrentHP = 10;
    public int CurrentHP
    {
        get { return m_CurrentHP; }
        set
        {
            m_CurrentHP = Mathf.Clamp(value, 0, m_MaxHP);
            if (State == FighterState.DEAD)
            {
                renderer.SetAnimation("battle_dead");
            }
        }
    }
    [SerializeField]
    private int m_CurrentMP = 10;
    public int CurrentMP
    {
        get { return m_CurrentMP; }
        set { m_CurrentMP = Mathf.Clamp(value, 0, m_MaxMP); }
    }
    [SerializeField]
    private int m_MaxHP = 10;
    public int MaxHP
    {
        get { return m_MaxHP; }
        set { m_MaxHP = value; }
    }
    [SerializeField]
    private int m_MaxMP = 10;
    public int MaxMP
    {
        get { return m_MaxMP; }
        set { m_MaxMP = value; }
    }

    public float m_Cooldown = 5.0f;
    public float m_ProgressBar = 0.0f;

    public FighterSkill NextSkill { get; set; } = null;
    public Fighter Target { get; set; } = null;

    public void EnterBattle()
    {
        renderer.SetAnimation("battle_idle");
        m_ProgressBar = Random.RandomRange(0.0f, m_Cooldown * 0.6f);
    }

    public IEnumerator ExecuteSkill()
    {
        if (State == FighterState.DEAD)
            yield break;

        if (NextSkill != null)
        {
            yield return new WaitForSeconds(0.5f);
            yield return NextSkill.Execute(this, Target);
        }
        NextSkill = null;
        Target = null;
        m_ProgressBar = 0;
    }

    public bool CanUse(FighterSkill skill)
    {
        if (skill is SkillAttack) return true;

        return (skill as SkillMagic)?.MpCost <= CurrentMP;
    }

    public void AddSkill(FighterSkill skill)
    {
        FighterSkill[] skillsTot = new FighterSkill[skills.Length + 1];
        int i = 0;
        for (; i < skills.Length; i++)
        {
            skillsTot[i] = skills[i];
        }
        skillsTot[i] = skill;

        skills = skillsTot;
    }
}
