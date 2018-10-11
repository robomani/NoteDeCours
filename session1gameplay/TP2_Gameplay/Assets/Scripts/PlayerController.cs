using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : BaseCharacter
{
    private int m_NbrMilitia = 0;
    private float m_TimeSinceLastClick = 0;
    private float m_TimeToMove = 0;

    public void Update ()
    {
        m_TimeToMove += Time.deltaTime;
        m_TimeSinceLastClick += Time.deltaTime;
        if (Input.GetMouseButton(0) && m_TimeToMove >= 0.2)
        {
            RaycastHit hitInfo;
            Ray myRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(myRay, out hitInfo, 50000f, LayerMask.GetMask("Ennemy"), QueryTriggerInteraction.Ignore) && Input.GetMouseButtonDown(0))
            {
                //Debug.Log("Ennemy");
                transform.LookAt(hitInfo.point);
                base.Shoot();
                m_RigidBody.velocity = Vector3.zero;
                m_TargetPosition = Vector3.zero;
                m_TimeToMove = 0;
            }
            else if(Physics.Raycast(myRay, out hitInfo, 50000f, LayerMask.GetMask("Player"), QueryTriggerInteraction.Ignore) && Input.GetMouseButtonDown(0) && m_TimeSinceLastClick <= 0.5 && m_NbrMilitia > 0)
            {
                //Debug.Log("Player");
                DropMilitia();
            }
            else if (Physics.Raycast(myRay, out hitInfo, 50000f, LayerMask.GetMask("Switch"), QueryTriggerInteraction.Ignore))
            {
                //Debug.Log("Switch");
                m_RigidBody.velocity = Vector3.zero;
                m_TargetPosition = hitInfo.point;
                m_TargetDirection = hitInfo.point - gameObject.transform.position;
                m_TargetDirection.y = 0;
                m_RigidBody.rotation = Quaternion.LookRotation(m_TargetDirection, Vector3.up);
            }
            else if (Physics.Raycast(myRay, out hitInfo, 50000f, LayerMask.GetMask("Ground"), QueryTriggerInteraction.Ignore))
            {
                //Debug.Log("Ground");
                m_RigidBody.velocity = Vector3.zero;
                m_TargetPosition = hitInfo.point;
                m_TargetDirection = hitInfo.point - gameObject.transform.position;
                m_TargetDirection.y = 0;
                m_RigidBody.rotation = Quaternion.LookRotation(m_TargetDirection,Vector3.up);
            } 
            else
            {
                //Debug.Log("Rien");
            }
            m_TimeSinceLastClick = 0;
        }
        if (gameObject.transform.position != m_TargetPosition && Vector3.Distance(transform.position, m_TargetPosition) >= 0.8 && m_TargetPosition != Vector3.zero)
        {
            m_RigidBody.velocity = m_TargetDirection.normalized * m_MoveSpeed;
        }
        else
        {
            m_RigidBody.velocity = Vector3.zero;
            m_TargetPosition = Vector3.zero;
        }
    }

    public int GetMilitia()
    {
        m_NbrMilitia += 1;
        return m_NbrMilitia;
    }

    public int DropMilitia()
    {
        m_NbrMilitia -= 1;
        transform.GetChild(transform.childCount - 1).parent = null;
        return m_NbrMilitia;
    }

}
