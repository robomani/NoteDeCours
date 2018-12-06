using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CommandListDialog : ListGenerator
{
    IEnumerable<Command> m_Commands;
    public IEnumerable<Command> Commands
    {
        get { return m_Commands; }
        set
        {
            Clear();
            foreach (var cmd in value)
            {
                var btn = Instantiate(m_ElementPrefab, m_Container).GetComponent<CommandButton>();
                btn.interactable = cmd.Enabled;
                btn.Name = cmd.Name;
                btn.onClick.AddListener(cmd.action);
            }
            StartCoroutine(SetFocus());
        }
    }

    public IEnumerator SetFocus()
    {
        yield return null;
        EventSystem.current?.SetSelectedGameObject(
            m_Container.GetComponentInChildren<CommandButton>()?.gameObject
            );
    }
}
