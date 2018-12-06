using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Teleporter : MonoBehaviour
{
    public string m_SceneName;
    public string m_SpawnPointName = "default";

    MapManager mapManager;

    private void Start()
    {
        mapManager = FindObjectOfType<MapManager>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        mapManager.LoadScene(m_SceneName, m_SpawnPointName);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawIcon(transform.position, "exit1.png");
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, 0.5f);
    }
}
