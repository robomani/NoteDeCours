using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerPower : MonoBehaviour
{
    public TextMeshProUGUI m_Text;
    public float m_Charge = 100.0f;
    public bool m_IsActive;
    public GameObject m_avatar;

    private void Start()
    {
        
    }

    private void Update()
    {
        if (m_IsActive)
        {
            m_Charge = m_Charge - Time.deltaTime;
            m_Text.text = "Stealth suit charge : " + m_Charge.ToString();
            if (m_Charge <= 0)
            {
                m_Charge = 0;
                m_Text.text = "Stealth suit charge : " + m_Charge.ToString();
                m_IsActive = false;
                gameObject.tag = "Player";
                m_avatar.GetComponent<Renderer>().material.color = Color.white;
            }
        }

        if (Input.GetKeyDown(KeyCode.Q) && m_Charge > 0)
        {
            if (m_IsActive)
            {
                m_IsActive = false;
                gameObject.tag = "Player";
                m_avatar.GetComponent<Renderer>().material.color = Color.white;
            }
            else
            {
                m_IsActive = true;
                gameObject.tag = "InvisiblePlayer";
                m_avatar.GetComponent<Renderer>().material.color = Color.blue;
            }
        }
    }


}
