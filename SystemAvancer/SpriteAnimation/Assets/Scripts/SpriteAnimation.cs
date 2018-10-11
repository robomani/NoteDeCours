using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteAnimation : MonoBehaviour
{
    [SerializeField]
    private Sprite[] m_Sprites;

    [SerializeField]
    private float m_FrameDuration = 1.0f;

    [SerializeField]
    private SpriteRenderer m_Renderer;

    private float m_FrameRemainingTime = 0.0f;
    private int m_FrameIndex = 0;

    private bool m_Invalidated;

    private void Awake()
    {
        if (m_Sprites.Length > 0)
        {
            m_Renderer.sprite = m_Sprites[0];
        }
    }

    private void Update()
    {
        m_FrameRemainingTime -= Time.deltaTime;
        if (m_FrameRemainingTime <= 0.0f)
        {
            if (m_FrameIndex < m_Sprites.Length -1)
            {
                m_FrameIndex++;
            }
            else
            {
                m_FrameIndex = 0;
            }
            
            m_FrameRemainingTime += m_FrameDuration;
            m_Renderer.sprite = m_Sprites[m_FrameIndex];
        }

        /*
        if (m_Invalidated)
        {
            UpdateSprite();
        }
        */

    }

    private void UpdateSprite()
    {
        m_Invalidated = false;
        m_Renderer.sprite = m_Sprites[m_FrameIndex % m_Sprites.Length];
    }
}
