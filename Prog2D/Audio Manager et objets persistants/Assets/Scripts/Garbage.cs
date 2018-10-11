using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Garbage : MonoBehaviour
{

    public GameObject m_Prefab;

    private void Start()
    {
        LoopDaWoop(new List<GameObject>());
    }

    private void Update ()
    {
        
        Vector3 v = new Vector3();
        GameObject obj;
        obj = GetComponent<GameObject>();
        CallGarbage();
        //Instantiate(m_Prefab, Vector3.zero, Quaternion.identity).AddComponent<Rigidbody>();

    }

    public void CallGarbage()
    {
        StartCoroutine(CreateGarbage());
    }

    public List<GameObject> LoopDaWoop(List<GameObject> i_Go)
    {
        LoopDaWoop(new List<GameObject>());
        return new List<GameObject>();
    }

    private IEnumerator CreateGarbage()
    {
        
        while (true)
        {
            Vector3 v = new Vector3();
            GameObject obj;
            obj = GetComponent<GameObject>();
            //Instantiate(m_Prefab, Vector3.zero, Quaternion.identity).AddComponent<Rigidbody>();

            yield return new WaitForSeconds(0.1f);
        }
    }
}
