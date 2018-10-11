using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    private Transform m_Item;
    private RaycastHit m_HitInfo;
    private Ray m_Ray;


    private void Update()
    {
        m_Ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(m_Ray.origin, m_Ray.direction * 100,Color.cyan);
       
        if (Physics.Raycast(m_Ray, out m_HitInfo, 100f, LayerMask.GetMask("InventoryItems")))
        {
            Debug.Log("Inventory item");
            if (Input.GetButtonDown("Fire1"))
            {
                m_Item = m_HitInfo.transform;
            }
        }

        if (!Input.GetButton("Fire1") && m_Item != null)
        {
            Debug.Log("Releash");
            if (Physics.Raycast(m_Ray, out m_HitInfo, 100f, LayerMask.GetMask("Slot")))
            {
                m_HitInfo.collider.GetComponent<Slots>().SetInventoryItem(m_Item);
            }
            else if(m_Item.parent != null)
            {
                m_Item.transform.localPosition = new Vector3(0, 0, -5);
            }
            m_Item = null;
        }
        
        if (Physics.Raycast(m_Ray, out m_HitInfo, 100f, LayerMask.GetMask("Slot")))
        {
            Debug.Log("Slot");
        }

        /*
        if (Physics.Raycast(m_Ray, out m_HitInfo, 100f))
        {
            Debug.Log(m_HitInfo.collider.gameObject.layer);
        }
        */
    }

    private void FixedUpdate()
    {
        if (m_Item && Input.GetButton("Fire1"))
        {
            Vector3 temp = Camera.main.ScreenPointToRay(Input.mousePosition).origin;
            m_Item.transform.position = new Vector3(temp.x,temp.y, m_Item.transform.position.z);
        }
    }
}
