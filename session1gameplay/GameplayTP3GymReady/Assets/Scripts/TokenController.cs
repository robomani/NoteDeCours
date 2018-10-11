using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TokenController : MonoBehaviour
{
	public BaseToken[] m_Tokens;
    public bool m_Resset = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) || m_Resset == true)
        {
            foreach (BaseToken token in m_Tokens)
            {
                token.gameObject.SetActive(true);
            }
            m_Resset = false;
        }
    }
}
