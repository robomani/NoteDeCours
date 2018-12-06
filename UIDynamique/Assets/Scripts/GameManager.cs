using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public UserInterface m_UI;

    private void Start()
    {
        m_UI.AddCommand("Attack", Attack);
        m_UI.AddCommand("Item", ChoseItems);
        m_UI.AddCommand("Run", Run);
    }

    private void Attack()
    {
        Debug.Log("Attack");
    }

    private void ChoseItems()
    {
        Debug.Log("ChoseItem");
    }

    private void Run()
    {
        Debug.Log("Run");
    }
}
