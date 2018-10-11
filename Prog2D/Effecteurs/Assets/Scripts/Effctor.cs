using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effctor : MonoBehaviour
{
    public GameObject m_Effector;
    public GameObject m_Visual;

    private void OnTriggerEnter2D(Collider2D a_Collision)
    {
        if (a_Collision.gameObject.layer == 10)
        {
            Debug.Log("Projectile");
            m_Effector.SetActive(true);
            if (a_Collision != null)
            {
                Destroy(a_Collision.gameObject);
            }
            m_Visual.transform.Rotate(transform.position, 180f);
        }
        else
        {
            Debug.Log(LayerMask.GetMask("Projectile") + " / " + a_Collision.gameObject.layer);
        }
    }

}
