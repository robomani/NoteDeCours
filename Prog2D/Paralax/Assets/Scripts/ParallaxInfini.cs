using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxInfini : MonoBehaviour
{
    public List<GameObject> m_Background = new List<GameObject>();
    public float m_Speed = 5f;

    private float m_ScreenWith;
    private Vector2 m_MovePos = new Vector2();
    private GameObject m_PreviousBackground;

    private void Start()
    {
        m_ScreenWith = -Screen.width / 100f;
        m_PreviousBackground = m_Background[m_Background.Count - 1];
    }

    private void Update()
    {
        for (int i = 0; i < m_Background.Count; i++)
        {
            //ici on deplace nos backgrounds
            m_Background[i].transform.Translate(-m_Speed*Time.deltaTime, 0, 0);
            // on vérifie si nos images dépassent la largeur de notre écran
            if (m_Background[i].transform.position.x <= m_ScreenWith)
            {
                //on assigne une nouvelle position en x du background ayant dépasser la limite.
                m_MovePos.x = m_PreviousBackground.transform.position.x - m_ScreenWith;
                m_Background[i].transform.position = m_MovePos;
                m_Background[i].transform.Translate(-m_Speed * Time.deltaTime, 0, 0);
            }
            m_PreviousBackground = m_Background[i];
        }
    }
}
