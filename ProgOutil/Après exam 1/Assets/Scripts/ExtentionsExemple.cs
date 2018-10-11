using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtentionsExemple : MonoBehaviour
{
    private List<int> m_RandomList = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

    private List<int> m_RandomCopy;
    private int m_MyInt;

    private void Awake()
    {
        m_RandomCopy = new List<int>(m_RandomList);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            m_MyInt--;
            m_MyInt = m_MyInt.Wrap(0, 5);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            m_MyInt++;
            m_MyInt = m_MyInt.Wrap(0, 5);
        }

        Debug.Log(m_MyInt);

        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log(m_RandomCopy.RandomRemove(m_RandomList));
        }
    }
}
