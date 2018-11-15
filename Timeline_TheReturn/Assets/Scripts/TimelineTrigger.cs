using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TimelineTrigger : MonoBehaviour
{
    public PlayableDirector m_Timeline;
    public bool m_UseOneTimeOnly = false;

    private bool m_HasBeenUsed = false;

    private void OnTriggerEnter(Collider i_Other)
    {
        if (!m_HasBeenUsed)
        {
            m_Timeline.Play();
            if (m_UseOneTimeOnly)
            {
                m_HasBeenUsed = true;
            }
        }           
    }
}
