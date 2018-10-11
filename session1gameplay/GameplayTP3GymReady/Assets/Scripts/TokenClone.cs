using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TokenClone : BaseToken
{
    public GameObject m_PrefabToClone;

    private void OnTriggerEnter(Collider a_Other)
    {

        if (a_Other.tag == "Player" && a_Other.GetComponent<PlayerController>().m_NBRClones < a_Other.GetComponent<PlayerController>().m_MaxClones)
        {
            Vector3 temp = a_Other.transform.position;
            Quaternion tempRot = a_Other.transform.rotation;
            PlayerController player = a_Other.GetComponent<PlayerController>();
            if (player.m_NBRClones % 2 == 0)
            {
                temp.x += Mathf.Clamp(player.m_NBRClones + 2, 2, 100);
            }
            else
            {
                temp.x -= Mathf.Clamp(player.m_NBRClones + 2, 2, 100);
            }
            GameObject clone = Instantiate(m_PrefabToClone, temp, tempRot);
            clone.GetComponent<PlayerController>().m_PrimeBody = player.gameObject;
            player.m_CloneArray[player.m_NBRClones] = clone;
            player.m_NBRClones++;
            player.m_CloneIcone.SetActive(true);
            player.m_CloneNumberText.text = player.m_NBRClones.ToString();


            if (player.GetComponent<RocketJumpEffect>())
            {
                clone.GetComponent<PlayerController>().m_JetPack.SetActive(true);
                clone.GetComponent<PlayerController>().m_RocketJumpTime = player.m_RocketJumpTime;
            }

            if (player.GetComponent<ShrinkTokenEffect>())
            {
                clone.transform.localScale = player.transform.localScale;
            }

            gameObject.SetActive(false);
        }
        else if (a_Other.tag == "Clone" && a_Other.GetComponent<PlayerController>().m_PrimeBody.GetComponent<PlayerController>().m_NBRClones < a_Other.GetComponent<PlayerController>().m_PrimeBody.GetComponent<PlayerController>().m_MaxClones)
        {
            Vector3 temp = a_Other.transform.position;
            Quaternion tempRot = a_Other.transform.rotation;
            PlayerController player = a_Other.GetComponent<PlayerController>().m_PrimeBody.GetComponent<PlayerController>();
            if (player.m_NBRClones % 2 == 0)
            {
                temp.x += Mathf.Clamp(player.m_NBRClones + 2, 2, 100);
            }
            else
            {
                temp.x -= Mathf.Clamp(player.m_NBRClones + 2, 2, 100);
            }
            GameObject clone = Instantiate(m_PrefabToClone, temp, tempRot);
            clone.GetComponent<PlayerController>().m_PrimeBody = player.gameObject;
            player.m_CloneArray[player.m_NBRClones] = clone;
            player.m_NBRClones++;
            player.m_CloneIcone.SetActive(true);
            player.m_CloneNumberText.text = player.m_NBRClones.ToString();

            if (player.GetComponent<RocketJumpEffect>())
            {
                clone.GetComponent<PlayerController>().m_JetPack.SetActive(true);
                clone.GetComponent<PlayerController>().m_RocketJumpTime = player.m_RocketJumpTime;
            }

            if (player.GetComponent<ShrinkTokenEffect>())
            {
                clone.transform.localScale = player.transform.localScale;
            }

            gameObject.SetActive(false);
        }
    }


}
