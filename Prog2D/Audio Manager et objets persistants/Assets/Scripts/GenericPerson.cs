using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericPerson : MonoBehaviour
{
    public float m_ID;

    private void Awake()
    {
        Debug.Log("Je suis une personne");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            LevelManager.Instance.ChangeLevel("MainMenu");
        }
    }
}
