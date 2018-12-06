using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerController : Fighter
{
    public CharacterAnimations m_Animations;

    private void Awake()
    {
        m_Animations = GetComponentInChildren<CharacterAnimations>();
    }

    private void Start()
    {
        RefreshSkillsUI();
    }

    private string m_DirectionName;
    
    public void Move(Vector2 direction)
    {
        float inputX = direction.x;// Input.GetAxisRaw("Horizontal");
        float inputY = direction.y;// Input.GetAxisRaw("Vertical");

        //if (!FindObjectOfType<FadeController>().Fading)
        {
            if (inputX > 0)
            {
                m_DirectionName = "right";
                SetAnimWalk();
            }
            else if (inputX < 0)
            {
                m_DirectionName = "left";
                SetAnimWalk();
            }
            else if (inputY > 0)
            {
                m_DirectionName = "up";
                SetAnimWalk();
            }
            else if (inputY < 0)
            {
                m_DirectionName = "down";
                SetAnimWalk();
            }
            else
            {
                SetAnimIdle();
            }
            
            GetComponent<Rigidbody2D>().MovePosition(transform.position + new Vector3(inputX, inputY) * Time.deltaTime * 5);
        }
    }
    
    public void RefreshSkillsUI()
    {
        /*
        List<SkillMagic> magicSkills = new List<SkillMagic>();
        List<SkillAttack> physicalSkills = new List<SkillAttack>();

        for(int i = 0; i < skills.Length; i++)
        {
            if (skills[i] is SkillMagic || skills[i] is SkillHeal)
            {
                magicSkills.Add((SkillMagic)skills[i]);
            }
            else if (skills[i] is SkillAttack)
            {
                physicalSkills.Add((SkillAttack)skills[i]);
            }
        }

        IEnumerable<SkillMagic> m1 = from mag in skills
                                     where mag is SkillMagic
                                     select mag;

        IEnumerable<SkillMagic> MagicskillsOrdered = from mskl in m1
                                                     orderby mskl.MpCost ascending
                                                     select mskl;

        IEnumerable<SkillAttack> PhisycalSkillsOrdered = from pskl in skills
                                                         where pskl is SkillAttack
                                                         orderby pskl.name ascending
                                                          select pskl;
*/


        Game.ui.UpdateMagicSkillsMenu(from skill in skills
                                      where skill is SkillMagic
                                      let magicSkill = skill as SkillMagic
                                      orderby magicSkill.MpCost
                                      select magicSkill
                                      );

        //Game.ui.UpdatePhysicalSkillsMenu(skills.Where(skill => skill is SkillAttack).Cast<SkillAttack>());
        // ==
        Game.ui.UpdatePhysicalSkillsMenu(skills.OfType<SkillAttack>());
    }

    public void SetAnimWalk()
    {
        m_Animations.SetAnimation("walk_" + m_DirectionName);
    }

    public void SetAnimIdle()
    {
        m_Animations.SetAnimation("idle_" + m_DirectionName);
    }
}
