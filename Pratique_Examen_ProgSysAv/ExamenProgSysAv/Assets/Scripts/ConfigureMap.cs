using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfigureMap : MonoBehaviour {
    
    [Header("Camera Settings")]
    public float m_MinimumX;
    public float m_MaximumX;
    public float m_MinimumY;
    public float m_MaximumY;

    // Use this for initialization
    void Awake ()
    {
        Game.camera.m_MinimumX = m_MinimumX;
        Game.camera.m_MaximumX = m_MaximumX;
        Game.camera.m_MinimumY = m_MinimumY;
        Game.camera.m_MaximumY = m_MaximumY;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(new Vector3(m_MinimumX, m_MinimumY), new Vector3(m_MinimumX, m_MaximumY));

        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(new Vector3(m_MaximumX, m_MinimumY), new Vector3(m_MaximumX, m_MaximumY));

        Gizmos.color = Color.red;
        Gizmos.DrawLine(new Vector3(m_MinimumX, m_MinimumY), new Vector3(m_MaximumX, m_MinimumY));

        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(new Vector3(m_MinimumX, m_MaximumY), new Vector3(m_MaximumX, m_MaximumY));
    }
}
