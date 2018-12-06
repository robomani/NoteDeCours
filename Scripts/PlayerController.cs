using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody m_RigidBody;
    public float m_MoveSpeed = 5f;
    public float m_RotateSpeed = 5f;
    private Vector3 m_TargetPosition = new Vector3();
    private Vector3 m_TargetDirection = new Vector3();

    public void Start ()
    {
        m_RigidBody = gameObject.GetComponent<Rigidbody>();
        if(m_RigidBody == null)
        {
            Debug.LogError("Pas de Rigid Body");
        }
	}
	

	public void Update ()
    {
        if (Input.GetMouseButton(0))
        {
            RaycastHit hitInfo;
            Ray myRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(myRay, out hitInfo, 500f, LayerMask.GetMask("Ennemy")))
            {
                //Debug.Log("Ennemy");

            }
            else if (Physics.Raycast(myRay, out hitInfo, 500f, LayerMask.GetMask("Ground")))
            {
                Debug.Log("Ground");
                m_RigidBody.velocity = Vector3.zero;
                m_TargetPosition = hitInfo.point;
                m_TargetDirection = hitInfo.point - gameObject.transform.position;
                m_TargetDirection.y = 0;
                m_RigidBody.rotation = Quaternion.LookRotation(m_TargetDirection,Vector3.up);
            }
            else
            {
                //Debug.Log("Pas Ground ou ennemi");
            }
        }
        if (gameObject.transform.position != m_TargetPosition && Vector3.Distance(transform.position, m_TargetPosition) > 1 && m_TargetPosition != Vector3.zero)
        {
            m_RigidBody.velocity = m_TargetDirection * m_MoveSpeed;
        }
        else
        {
            m_RigidBody.velocity = Vector3.zero;
            m_TargetPosition = Vector3.zero;
        }
    }

}
