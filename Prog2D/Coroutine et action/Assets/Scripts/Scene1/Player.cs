using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            ActionTest testing = GameObject.FindObjectOfType<ActionTest>();
            testing.m_Action += MyAction;
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            Destroy(gameObject);
        }
    } 

    public void MyAction()
    {
        Debug.Log("Way to many logs, Please collapse");
    }

    private void OnDestroy()
    {
        ActionTest testing = GameObject.FindObjectOfType<ActionTest>();
        testing.m_Action -= MyAction;
    }
}
