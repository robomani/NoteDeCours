using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PlayerController m_Player;

    private static GameManager m_Instance;

    public static GameManager Instance
    {
        get { return m_Instance;  }
    }

    private void Awake()
    {
        if (m_Instance != null)
        {
            Destroy(this);
        }
        else
        {
            m_Instance = this;
        }

        DontDestroyOnLoad(gameObject);
    }
}
