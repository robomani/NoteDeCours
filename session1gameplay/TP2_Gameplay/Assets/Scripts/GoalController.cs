using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GoalController : MonoBehaviour
{
    public int m_Goal = 0;
    public int[] m_EnnemyToKill;
    public int[] m_MillitiaToDrop;
    public TextMeshPro m_TextGoal;
    public GameObject[] m_Doors;
    public GameObject[] m_Areas;
    public Camera m_MainCamera;

    void Update ()
    {

		switch(m_Goal)
        {
            case 0: m_TextGoal.text = "Placez " + m_MillitiaToDrop[m_Goal].ToString() + " milices sur la plaque pour continuer."; break;
            case 1: m_TextGoal.text = "Tuer " + m_EnnemyToKill[m_Goal].ToString() + " ennemis pour continuer."; break;
            case 2: m_TextGoal.text = "Tuer " + m_EnnemyToKill[m_Goal].ToString() + " ennemis et placez " + m_MillitiaToDrop[m_Goal].ToString() + " milices."; break;
            case 3: m_TextGoal.text = "Tuer le boss"; m_MainCamera.GetComponent<CameraFollow>().m_BossBattle = true; break;
            case 4: UnityEngine.SceneManagement.SceneManager.LoadScene("Scenes/Win", LoadSceneMode.Single); break;

            default: Debug.Log("Default"); break ;
        }

	}

    public void DropMillitia()
    {       
        m_MillitiaToDrop[m_Goal]--;
        if (m_MillitiaToDrop[m_Goal] <= 0 && m_EnnemyToKill[m_Goal] <= 0)
        {
            if(m_Doors[m_Goal])
            {
                
                m_Doors[m_Goal].SetActive(false);
            }
            if(m_Areas[m_Goal])
            {
                m_Areas[m_Goal].SetActive(false);
            }
            if (m_Areas[m_Goal + 1])
            {
                m_Areas[m_Goal + 1].SetActive(true);
            }
            m_Goal++;
        }
    }

    public void KillEnnemy()
    {
        if(m_EnnemyToKill[m_Goal] >0)
        {
            m_EnnemyToKill[m_Goal]--;
        }

        if(m_EnnemyToKill[m_Goal] <= 0 && m_MillitiaToDrop[m_Goal] <= 0)
        { 
            if (m_Doors[m_Goal])
            {
                m_Doors[m_Goal].SetActive(false);
            }
            if (m_Areas[m_Goal])
            {
                m_Areas[m_Goal].SetActive(false);
            }
            if (m_Areas[m_Goal+1])
            {
                m_Areas[m_Goal+1].SetActive(true);
            }
            m_Goal++;
        }
    }

    public void KillBoss()
    {
        m_Goal++;
    }
}
