using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RocketJumpEffect : BaseTokenEffect
{
    public float m_RocketTimeBase = 5f;
    protected void Start ()
    {
        gameObject.GetComponent<PlayerController>().m_RocketJumpTime = m_RocketTimeBase;
        gameObject.GetComponent<PlayerController>().m_JetPack.SetActive(true);
        gameObject.GetComponent<PlayerController>().m_RocketJumpIcone.SetActive(true);
        gameObject.GetComponent<PlayerController>().m_RocketJumpTimeText.text = gameObject.GetComponent<PlayerController>().m_RocketJumpTime.ToString();
        if (gameObject.GetComponent<PlayerController>().m_NBRClones > 0)
        {
            for (int i = 0; i < gameObject.GetComponent<PlayerController>().m_NBRClones; i++)
            {
                gameObject.GetComponent<PlayerController>().m_CloneArray[i].GetComponent<PlayerController>().m_RocketJumpTime = m_RocketTimeBase;
                gameObject.GetComponent<PlayerController>().m_CloneArray[i].GetComponent<PlayerController>().m_JetPack.SetActive(true);
            }
        }
    }

    protected void OnDestroy()
    {
        gameObject.GetComponent<PlayerController>().m_RocketJumpTime = 0f;
        gameObject.GetComponent<PlayerController>().m_JetPack.SetActive(false);
        gameObject.GetComponent<PlayerController>().m_RocketJumpIcone.SetActive(false);
    }
}
