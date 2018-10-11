using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TokenRocketJump : BaseToken
{
    public float m_RocketTimeAdd = 5f;
    private void OnTriggerEnter(Collider a_Other)
    {

        if (a_Other.tag == "Player")
        {
            if(a_Other.GetComponent<RocketJumpEffect>())
            {
                a_Other.GetComponent<PlayerController>().m_RocketJumpTime += m_RocketTimeAdd;
                a_Other.GetComponent<PlayerController>().m_RocketJumpTimeText.text = a_Other.GetComponent<PlayerController>().m_RocketJumpTime.ToString();

                if (a_Other.GetComponent<PlayerController>().m_NBRClones > 0)
                {
                    for (int i = 0; i < a_Other.GetComponent<PlayerController>().m_NBRClones; i++)
                    {
                        a_Other.GetComponent<PlayerController>().m_CloneArray[i].GetComponent<PlayerController>().m_RocketJumpTime += m_RocketTimeAdd;
                        a_Other.GetComponent<PlayerController>().m_CloneArray[i].GetComponent<PlayerController>().m_JetPack.SetActive(true);
                    }
                }
            }
            else
            {
                a_Other.gameObject.AddComponent<RocketJumpEffect>();      
            }
            gameObject.SetActive(false);
        }
        else if (a_Other.tag == "Clone")
        {
            PlayerController player = a_Other.GetComponent<PlayerController>().m_PrimeBody.GetComponent<PlayerController>();
            if (player.gameObject.GetComponent<RocketJumpEffect>())
            {
                player.m_RocketJumpTime += m_RocketTimeAdd;
                player.m_RocketJumpTimeText.text = player.m_RocketJumpTime.ToString();

                for (int i = 0; i < player.gameObject.GetComponent<PlayerController>().m_NBRClones; i++)
                {
                    player.gameObject.GetComponent<PlayerController>().m_CloneArray[i].GetComponent<PlayerController>().m_RocketJumpTime += m_RocketTimeAdd;
                    player.gameObject.GetComponent<PlayerController>().m_CloneArray[i].GetComponent<PlayerController>().m_JetPack.SetActive(true);
                }
             
            }
            else
            {
                player.gameObject.AddComponent<RocketJumpEffect>();
            }
            gameObject.SetActive(false);
        }
    }
}
