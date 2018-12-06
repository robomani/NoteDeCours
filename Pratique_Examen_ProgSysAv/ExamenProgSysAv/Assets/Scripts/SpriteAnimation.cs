using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SpriteAnimation {

    public string m_Id;

    [SerializeField]
    private Sprite[] m_Sprites;

    [SerializeField]
    private float m_FrameDuration = 1.0f;

    [SerializeField]
    private bool m_FlipX = false;

    [HideInInspector]
    public SpriteRenderer m_Renderer;

    private bool invalidated = true;
    private int m_SpriteIndex = 0;
    private float m_FrameRemainingTime = 0.0f;

    public void Reset()
    {
        m_SpriteIndex = 0;
        m_FrameRemainingTime = m_FrameDuration;
        invalidated = true;
    }

	public bool DoUpdate ()
    {
        if (invalidated)
            UpdateSprite();

        bool reachedEnd = false;
        if (m_FrameRemainingTime <= 0.0f)
        {
            if (m_Sprites.Length > 0)
            {
                m_SpriteIndex++;
                invalidated = true;
                if (m_SpriteIndex >= m_Sprites.Length)
                {
                    m_SpriteIndex %= m_Sprites.Length;
                    reachedEnd = true;
                }
            }
            m_FrameRemainingTime = m_FrameDuration;
        }

        m_Renderer.sortingOrder = (int)(m_Renderer.transform.position.y * -100f);
        m_FrameRemainingTime -= Time.deltaTime;

        return reachedEnd;
    }

    private void UpdateSprite()
    {
        invalidated = false;
        m_Renderer.flipX = m_FlipX;
        m_Renderer.sprite = m_Sprites[m_SpriteIndex];
    }
}
