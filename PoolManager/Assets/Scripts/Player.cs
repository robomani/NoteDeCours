using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private GameObject m_Batarang;

    private Action ReturnBatarangs;
    private void Update()
    {
        //Use case 1
        if (Input.GetKeyDown(KeyCode.A) && m_Batarang == null)
        {
            m_Batarang = PoolManager.Instance.GetFromPool(EPoolType.Cube, Vector3.zero);
        }
        else if (Input.GetKeyDown(KeyCode.D) && m_Batarang != null)
        {
            PoolManager.Instance.ReturnToPool(EPoolType.Cube, m_Batarang);
            m_Batarang = null;
        }

        //use case 2
        if (Input.GetKeyDown(KeyCode.F))
        {
            PoolManager.Instance.GetFromPool(EPoolType.Cube, Vector3.zero).GetComponent<PoolableItem>().StartTimer(2f); ;
        }

        //use case 3 (Action)
        if (Input.GetKeyDown(KeyCode.S))
        {
            ReturnBatarangs += PoolManager.Instance.GetFromPool(EPoolType.Cube, Vector3.zero).GetComponent<PoolableItem>().RetrurnToPool;
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            if (ReturnBatarangs != null)
            {
                ReturnBatarangs();
            }
        }
    }
}
