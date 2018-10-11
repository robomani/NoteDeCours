using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private LayerMask m_Mask;

    private int a = 0;
    private int b = 10;

    private void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray,1000f, m_Mask))
            {
                Debug.Log("Nuke it from orbit it's the only way to be sure!");
            }
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            m_Mask = LayerMask.GetMask("Ennemy") | LayerMask.GetMask("Princess") | LayerMask.GetMask("Default");
        }
    }

    private void OnTriggerEnter(Collider i_Col)
    {
        bool JimmyComprends = i_Col.gameObject.layer == LayerMask.NameToLayer("Ennemy") ? true : false;
        int MathComprend = a < b ? 100 : 0;
        string TiPatEnPatinComprend = b > a ? "Programmeur" : "Prof de science";
    }
}
