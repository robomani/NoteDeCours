using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerNavMesh : MonoBehaviour
{
    public NavMeshAgent m_Agent;
    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray,out hit, 1000f, LayerMask.GetMask("Ground")))
        {
            m_Agent.SetDestination(hit.point);
        }
    }
}
