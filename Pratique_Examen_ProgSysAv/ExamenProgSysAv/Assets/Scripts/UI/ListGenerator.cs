using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ListGenerator : MonoBehaviour
{
    [SerializeField] protected RectTransform m_Container;
    [SerializeField] protected RectTransform m_ElementPrefab;

    public List<T> GenerateElements<T>(int count)
    {
        List<T> list = new List<T>();

        for (int i = 0; i < count; i++)
        {
            list.Add(Instantiate(m_ElementPrefab, m_Container).GetComponent<T>());
        }

        return list;
    }

    public IList<KeyValuePair<T, U>> GenerateElements<T, U>(IEnumerable<T> elements)
    {
        var query = from item in elements
                    select new KeyValuePair<T, U>( item, Instantiate(m_ElementPrefab, m_Container).GetComponent<U>() );

        return query.ToList();
    }

    public void Clear()
    {
        foreach (Transform child in m_Container.transform)
        {
            Destroy(child.gameObject);
        }
    }
}
