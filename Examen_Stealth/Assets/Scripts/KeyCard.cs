using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCard : MonoBehaviour
{
    public List<GameObject> m_ObstaclesToRemove;
    public GameObject m_InteractPromp;
    public bool m_CanGet;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            m_InteractPromp.SetActive(true);
            m_CanGet = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            m_InteractPromp.SetActive(false);
            m_CanGet = false;
        }
    }

    private void Update()
    {
        if (m_CanGet && Input.GetKeyDown(KeyCode.E))
        {
            foreach (GameObject item in m_ObstaclesToRemove)
            {
                item.SetActive(false);
            }
            m_InteractPromp.SetActive(false);
            gameObject.SetActive(false);
        }
    }
}
