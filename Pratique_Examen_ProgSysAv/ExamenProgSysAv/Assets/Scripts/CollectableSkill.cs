using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CollectableSkill : MonoBehaviour
{
    public FighterSkill skill;
    
    private void Awake()
    {
        UpdateIcon();
    }

    private void Start()
    {
        if (Game.player.GetComponent<Fighter>().skills.Contains(skill))
        {
            gameObject.SetActive(false);
        }
    }

    private void OnDrawGizmos() => UpdateIcon();

    private void UpdateIcon()
    {
        GetComponent<SpriteRenderer>().sprite = skill.Icon;
    }

    private void OnTriggerEnter2D(Collider2D i_Collision)
    {
        if (i_Collision.GetComponent<PlayerController>())
        {
            Game.player.AddSkill(skill);
            Game.ui.DisplayDialogBox("You learned the skill " + skill.Name);
            Game.player.RefreshSkillsUI();
            Destroy(gameObject);
        }
    }
}
