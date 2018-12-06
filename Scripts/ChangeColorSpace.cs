using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColorSpace : MonoBehaviour
{
    public Material m_Material;


	private void Update ()
    {
        
		if(Input.GetKeyDown(KeyCode.Space))
        {
            m_Material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);

        }
    }
}
