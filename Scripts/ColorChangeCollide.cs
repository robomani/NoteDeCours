using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChangeCollide : MonoBehaviour
{
    public Material m_Material;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            m_Material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        }
    }
}