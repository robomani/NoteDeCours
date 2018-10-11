using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject m_Target;
    public float m_CameraCollisionRange = 500f;
    private Vector3 m_Offset = new Vector3();
    private Vector3 m_NewPos = new Vector3();
    private Vector3 m_OffsetBase = new Vector3();
    private Vector3 m_TargetBase = new Vector3();
    public bool m_BossBattle = false;
    public GameObject m_BossBattleView;


    public void Start ()
    {
        m_OffsetBase = (gameObject.transform.position);
        m_TargetBase = (m_Target.transform.position);
        m_Offset = m_OffsetBase;
    }



    private void LateUpdate ()
    {
        if (!m_BossBattle)
        {
            m_NewPos = m_Offset;
            m_Offset.y = m_OffsetBase.y + (m_Target.transform.position.y - m_TargetBase.y);

            m_NewPos.x = m_OffsetBase.x + (m_Target.transform.position.x - m_TargetBase.x);
            if ((!Physics.Raycast(gameObject.transform.position, -gameObject.transform.right, m_CameraCollisionRange, LayerMask.GetMask("Wall")) || !Physics.Raycast(m_NewPos, -gameObject.transform.right, m_CameraCollisionRange, LayerMask.GetMask("Wall"))) && (!Physics.Raycast(gameObject.transform.position, gameObject.transform.right, m_CameraCollisionRange, LayerMask.GetMask("Wall")) || !Physics.Raycast(m_NewPos, gameObject.transform.right, m_CameraCollisionRange, LayerMask.GetMask("Wall"))) && !m_BossBattle)
            {
                m_Offset.x = m_OffsetBase.x + (m_Target.transform.position.x - m_TargetBase.x);
            }
            else
            {
                m_Offset.x = gameObject.transform.position.x;
            }


            m_NewPos.z = m_OffsetBase.z + (m_Target.transform.position.z - m_TargetBase.z);
            if (!Physics.Raycast(gameObject.transform.position, -Vector3.forward, m_CameraCollisionRange, LayerMask.GetMask("Wall")) || !Physics.Raycast(m_NewPos, -Vector3.forward, m_CameraCollisionRange, LayerMask.GetMask("Wall")) && !m_BossBattle)
            {
                m_Offset.z = m_OffsetBase.z + (m_Target.transform.position.z - m_TargetBase.z);
            }
            else
            {
                m_Offset.z = gameObject.transform.position.z;
            }

            transform.position = m_Offset;
        }
        else
        {
            transform.position = m_BossBattleView.transform.position;
            transform.LookAt(m_Target.transform.position);
        }
	}
}
