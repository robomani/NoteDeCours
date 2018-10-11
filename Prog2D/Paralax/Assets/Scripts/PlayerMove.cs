using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    private float m_Speed = 5f;
    private SpriteRenderer m_Visuel;
    private float m_InputX;
    [SerializeField]
    private Animator m_Animator;

    private void Awake()
    {
        m_Visuel = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        m_InputX = Input.GetAxisRaw("Horizontal");
        m_Animator.SetInteger("Speed", (int)m_InputX);
        if (m_InputX > 0f)
        {
            m_Visuel.flipX = false;
        }
        else if (m_InputX < 0f)
        {
            m_Visuel.flipX = true;
        }

        transform.Translate(m_Speed * m_InputX*Time.deltaTime, 0f, 0f);
    }

}
