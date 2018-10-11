using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LinqExemple : MonoBehaviour
{
    public List<GameObject> m_Objects;

    private void Update()
    {
        GameObject nearestGO = m_Objects
            .OrderBy(go => Vector3.Distance(transform.position, go.transform.position))
            .FirstOrDefault();

        

        //Avoir le dernier (Les 2 prochains font la même choses
        GameObject FurthestGO = m_Objects
            .OrderBy(go => Vector3.Distance(transform.position, go.transform.position))
            .LastOrDefault();

        GameObject FurthestGO2 = m_Objects
            .OrderByDescending(go => Vector3.Distance(transform.position, go.transform.position))
            .FirstOrDefault();

        //comment avoir un element à une position X
        GameObject secondGO = m_Objects
            .OrderBy(go => Vector3.Distance(transform.position, go.transform.position))
            .Skip(1)
            .FirstOrDefault();

        //coment avoir les x premier éléments de la liste
        GameObject[] firstTwoGO = m_Objects
            .OrderBy(go => Vector3.Distance(transform.position, go.transform.position))
            .Take(2)
            .ToArray();

        //comment filter les elements d'une liste selon une condition
        GameObject[] fiteredObjects = m_Objects
            .Where(go => go.name.Contains("Cube"))
            .ToArray();

        //Est-ce que je contien au moin un element selon la condition 
        bool hasCube = m_Objects
            .Any(go => go.name == "Cube3");

        //Comment enlever les doublons d'une liste
        List<int> nonSenseInts = new List<int>() {0,0,0,1,1,1,1,2,3,3,3,4,4,4,4,4,3,3,1,-1 };
        int[] distinctInts = nonSenseInts.Distinct().ToArray();

       
        foreach (int distinct in distinctInts)
        {
            Debug.Log(distinct);
        }
        
    }

    private GameObject GetNearestGameObject()
    {
        float minDistance = Mathf.Infinity;
        GameObject closestGO = null;

        foreach (GameObject go in m_Objects)
        {
            float distance = Vector3.Distance(transform.position, go.transform.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                closestGO = go;
            }
        }
        return closestGO;
    }
}
