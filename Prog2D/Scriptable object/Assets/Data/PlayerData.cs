using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="ScriptableObject/CaracterData", fileName = "new data", order = 1)]
public class PlayerData : ScriptableObject
{
    [SerializeField]
    private float m_RunSpeed = 10f;

    public float RunSpeed
    {
        get { return m_RunSpeed; }
    }
}
