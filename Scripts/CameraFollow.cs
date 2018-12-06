using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject m_Target;
    public float m_CameraCollisionRange = 5f;
    private Vector3 m_Offset = new Vector3();
    private Vector3 m_NewPos = new Vector3();
    private Vector3 m_OffsetBase = new Vector3();
    private Vector3 m_TargetBase = new Vector3();


    public void Start ()
    {
        m_OffsetBase = (gameObject.transform.position);
        m_TargetBase = (m_Target.transform.position);

    }

    private void Update()
    {
        
    }

    private void LateUpdate ()
    {
        m_NewPos = m_Offset;
        m_Offset.y = m_OffsetBase.y + (m_Target.transform.position.y - m_TargetBase.y);

        m_NewPos.x = m_OffsetBase.x + (m_Target.transform.position.x - m_TargetBase.x);
        if ((!Physics.Raycast(gameObject.transform.position, -gameObject.transform.right, m_CameraCollisionRange) || !Physics.Raycast(m_NewPos, -gameObject.transform.right, m_CameraCollisionRange)) && (!Physics.Raycast(gameObject.transform.position, gameObject.transform.right, m_CameraCollisionRange) || !Physics.Raycast(m_NewPos, gameObject.transform.right, m_CameraCollisionRange)))
        {
            m_Offset.x = m_OffsetBase.x + (m_Target.transform.position.x - m_TargetBase.x);
        }        

        
        m_NewPos.z = m_OffsetBase.z + (m_Target.transform.position.z - m_TargetBase.z);
        if (!Physics.Raycast(gameObject.transform.position, -gameObject.transform.forward, m_CameraCollisionRange) || !Physics.Raycast(m_NewPos, -gameObject.transform.forward, m_CameraCollisionRange))
        {
            m_Offset.z = m_OffsetBase.z + (m_Target.transform.position.z - m_TargetBase.z);
        }
        
        transform.position = m_Offset;
	}
}
