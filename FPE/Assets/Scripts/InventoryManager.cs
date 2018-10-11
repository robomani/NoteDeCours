using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class InventoryManager : MonoBehaviour
{
    public Slots[] m_Inventory;


    public void SortEmpty()
    {
        Transform[] rempli = new Transform[m_Inventory.Length];
        int nbrItem = 0;

        for (int i = 0; i < m_Inventory.Length; i++)
        {
            if (m_Inventory[i].InventoryItem)
            {
                rempli[nbrItem] = m_Inventory[i].InventoryItem;
                m_Inventory[i].ClearSlot();
                nbrItem++;
            }
        }

        for (int i = 0; i < nbrItem; i++)
        {
            m_Inventory[i].SetInventoryItem(rempli[i]);
        }
    }
}
