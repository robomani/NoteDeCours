using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using System.Linq;

public class UserInterface : MonoBehaviour
{
    public ScreenFader fader { get; private set; }

    [SerializeField]
    private RectTransform m_DialogBox;
    [SerializeField]
    private TextMeshProUGUI m_DialogBoxText;
    
    public ListGenerator m_PhysicalSkillsMenu;
    public ListGenerator m_MagicSkillsMenu;


    private void Awake()
    {
        fader = GetComponentInChildren<ScreenFader>();
        fader.gameObject.SetActive(true);

        m_PhysicalSkillsMenu.gameObject.SetActive(true);
        m_MagicSkillsMenu.gameObject.SetActive(true);

        m_DialogBox.gameObject.SetActive(false);
    }

    public void DisplayDialogBox(string msg, float seconds = 2.0f)
    {
        StopAllCoroutines();
        
        m_DialogBox.gameObject.SetActive(true);
        m_DialogBoxText.SetText(msg);

        StartCoroutine(HideDialogBoxAfterSeconds(seconds));
    }

    private void HideDialogBox()
    {
        m_DialogBox.gameObject.SetActive(false);
    }

    private IEnumerator HideDialogBoxAfterSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        HideDialogBox();
    }

    public void UpdateMagicSkillsMenu(IEnumerable<SkillMagic> skills)
    {
        m_MagicSkillsMenu.Clear();
        foreach (var uiForSkill in m_MagicSkillsMenu.GenerateElements<SkillMagic, SkillUI>(skills))
        {
            var skill = uiForSkill.Key;
            var ui = uiForSkill.Value;

            ui.MP = skill.MpCost;
            ui.Name = skill.Name;
            ui.Icon = skill.Icon;
        }
    }

    public void UpdatePhysicalSkillsMenu(IEnumerable<SkillAttack> skills)
    {
        m_PhysicalSkillsMenu.Clear();
        foreach (var uiForSkill in m_PhysicalSkillsMenu.GenerateElements<SkillAttack, SkillUI>(skills))
        {
            var skill = uiForSkill.Key;
            var ui = uiForSkill.Value;

            ui.MP = 0;
            ui.Name = skill.Name;
            ui.Icon = skill.Icon;
        }
    }
}
