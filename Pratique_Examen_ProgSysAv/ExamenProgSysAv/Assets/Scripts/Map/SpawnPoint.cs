using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SpawnPoint : MonoBehaviour
{
    public string m_SpawnPointName = "default";
    public Vector2 m_PlayerDirection = Vector2.down;

    public void OnDrawGizmos()
    {
        Gizmos.DrawIcon(transform.position, "entry1.png");
    }

    public void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, 0.5f);
    }


    public static SpawnPoint FindOrDefault(string spawnPointName)
    {
        var spawnPoints = FindObjectsOfType<SpawnPoint>();

        SpawnPoint result = null;

        if (spawnPoints.Length > 0)
        {
            result = spawnPoints.FirstOrDefault(s => s.m_SpawnPointName.CompareTo(spawnPointName) == 0);
            if (result == null) result = spawnPoints.FirstOrDefault(s => s.m_SpawnPointName.CompareTo("default") == 0);
            if (result == null) result = spawnPoints.FirstOrDefault();
        }

        return result;
    }
}
