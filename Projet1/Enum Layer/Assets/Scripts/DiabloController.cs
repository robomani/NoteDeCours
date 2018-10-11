using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DiabloController : MonoBehaviour
{
    public NavMeshAgent m_Agent;
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit HitInfo;
            if (Physics.Raycast(ray, out HitInfo, 100f, LayerMask.GetMask("Ground")))
            {
                m_Agent.SetDestination(HitInfo.point);
            }
        }
    }
}
