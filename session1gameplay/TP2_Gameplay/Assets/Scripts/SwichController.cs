using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SwichController : MonoBehaviour
{

    public int m_NumberToActivate = 5;
    public TextMeshPro m_Text;
    public TextMeshPro m_TextMiniMap;
    public TextMeshPro m_TextGoal;
    public GameObject m_GoalController;

    private void Start()
    {
        m_Text.text = m_NumberToActivate.ToString();
        m_TextMiniMap.text = m_NumberToActivate.ToString();
    }

    private void OnCollisionEnter(Collision a_Collision)
    {
        Debug.Log(a_Collision.gameObject.tag);
        if (a_Collision.gameObject.tag == "Militia" && m_NumberToActivate > 0)
        {
            m_NumberToActivate -= 1;
            m_GoalController.GetComponent<GoalController>().DropMillitia();
            m_Text.text = m_NumberToActivate.ToString();
            m_TextMiniMap.text = m_NumberToActivate.ToString();
            Destroy(a_Collision.gameObject);
            m_TextGoal.text = "Placez " + m_NumberToActivate.ToString() + " Milices sur la plaque pour continuer.";
            if (m_NumberToActivate <= 0)
            {
                SwichDestroy();
            }
        }
        else if (a_Collision.gameObject.tag == "Player")
        {

            Vector3 temp = a_Collision.transform.position;
            temp.y += 0.4f;
            a_Collision.transform.position = temp;
        }

    }


    private void SwichDestroy()
    {
            Destroy(gameObject);
    }
}
