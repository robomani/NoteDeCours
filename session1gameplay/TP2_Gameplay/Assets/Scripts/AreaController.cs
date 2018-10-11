using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AreaController : MonoBehaviour
{
    public int m_NbrCivilian = 3;
    public int m_NbrEnnemy = 2;
    public Rigidbody m_Civilian;
    public Rigidbody m_Ennemy;
    public float m_Length_Z;
    public float m_Width_X;
    //Nbr d'ennemi possible à spawner -1 pour infini;
    public int m_NbrEnemmyToKill;
    public TextMeshPro m_Goal;

    public void Start ()
    {
		for (int i = 0; i < m_NbrCivilian; i++)
        {
            SpawnCivilian();
        }

        for (int i = 0; i < m_NbrEnnemy; i++)
        {
            if (m_NbrEnemmyToKill > 0)
            {
                m_NbrEnemmyToKill--;
                SpawnEnnemy();
            }
            else if(m_NbrEnemmyToKill == -1)
            {
                SpawnEnnemy();
            }
            
        }
    }
	
	public void Update ()
    {
		if(GameObject.FindGameObjectsWithTag("Civilian").Length < m_NbrCivilian)
        {
            SpawnCivilian();
        }

        if (GameObject.FindGameObjectsWithTag("Ennemy").Length < m_NbrEnnemy)
        {
            if (m_NbrEnemmyToKill > 0)
            {
                m_NbrEnemmyToKill--;
                SpawnEnnemy();
            }
            else if (m_NbrEnemmyToKill == -1)
            {
                SpawnEnnemy();
            }
        }
    }

    public void SpawnCivilian()
    {
        
        int spawnPointX = Random.Range(Mathf.RoundToInt(transform.position.x - m_Width_X / 2), Mathf.RoundToInt(transform.position.x + m_Width_X / 2));
        int spawnPointZ = Random.Range(Mathf.RoundToInt(transform.position.z - m_Length_Z / 2), Mathf.RoundToInt(transform.position.z + m_Length_Z/ 2));
        Vector3 spawnPosition = new Vector3(spawnPointX, 1, spawnPointZ);
        Quaternion rotation = Random.rotation;
        rotation.z = 0;
        rotation.x = 0;
        rotation.w = 0;

        Rigidbody civilianClone = (Rigidbody)Instantiate(m_Civilian, spawnPosition, rotation);
    }

    public void SpawnEnnemy()
    {
        int spawnPointX = Random.Range(Mathf.RoundToInt(transform.position.x) - 75, Mathf.RoundToInt(transform.position.x + 75));
        int spawnPointZ = Random.Range(Mathf.RoundToInt(transform.position.z) - 75, Mathf.RoundToInt(transform.position.z + 75));
        Vector3 spawnPosition = new Vector3(spawnPointX, 1, spawnPointZ);
        Quaternion rotation = Random.rotation;
        rotation.z = 0;
        rotation.x = 0;
        rotation.w = 0;

        Rigidbody EnnemyClone = (Rigidbody)Instantiate(m_Ennemy, spawnPosition, rotation);
    }
}
