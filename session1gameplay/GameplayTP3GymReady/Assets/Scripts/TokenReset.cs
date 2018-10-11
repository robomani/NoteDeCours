using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TokenReset : BaseToken
{
    public TokenController m_Controller;
    private void OnTriggerEnter(Collider a_Other)
    {

        if (a_Other.tag == "Player")
        {
            a_Other.GetComponent<PlayerController>().m_ResetReady = true;
            a_Other.GetComponent<PlayerController>().m_ResetIcone.SetActive(true);
        }
        else if (a_Other.tag == "Clone")
        {
            PlayerController player = a_Other.GetComponent<PlayerController>().m_PrimeBody.GetComponent<PlayerController>();
            player.m_ResetReady = true;
            player.m_ResetIcone.SetActive(true);
        }
        m_Controller.m_Resset = true;
    }

}
