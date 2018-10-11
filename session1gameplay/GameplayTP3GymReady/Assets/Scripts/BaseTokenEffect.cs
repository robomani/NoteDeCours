using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseTokenEffect : MonoBehaviour
{
    protected void Update()
    {
        if(gameObject.GetComponent<PlayerController>().m_ResetReady)
        {
            Destroy(this);
        }
    }

}
