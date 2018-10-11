using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerID
{
    PlayerOne = 1,
    PlayerTwo,
    PlayerThree,
    PlayerFour,
}

public class PlayerController : MonoBehaviour
{
    public PlayerID m_ID;

    private void Update()
    {
        if (Input.GetButton("Jump_" + (int)m_ID))
        {
            Debug.Log("Jump " + m_ID);
        }
    }
}
