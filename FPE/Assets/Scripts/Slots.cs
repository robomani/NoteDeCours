using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slots : MonoBehaviour
{
    private Transform m_InventoryItem;
    public Transform InventoryItem { get { return m_InventoryItem; } }

    public void SetInventoryItem(Transform i_Item)
    {
        if (!m_InventoryItem || m_InventoryItem == i_Item)
        {
            if (i_Item.parent != null)
            {
                i_Item.parent.GetComponent<Slots>().ClearSlot();
            }
            AddItem(i_Item);
        }
        else
        {
            i_Item.parent.GetComponent<Slots>().TradeItem(m_InventoryItem);
            AddItem(i_Item);
        }
    }

    public void TradeItem(Transform i_Item)
    {
        if (i_Item.parent != null)
        {
            i_Item.parent.GetComponent<Slots>().ClearSlot();
        }
        AddItem(i_Item);
    }

    public void ClearSlot()
    {
        m_InventoryItem = null;
    }

    private void AddItem(Transform i_Item)
    {    
        m_InventoryItem = i_Item;
        m_InventoryItem.transform.parent = gameObject.transform;
        m_InventoryItem.transform.localPosition = new Vector3(0, 0, -5); 
    }

}
