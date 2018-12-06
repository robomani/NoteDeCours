using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToPoints : MonoBehaviour
{
    public float m_MoveTime = 1f;
    public float m_MoveDistance = 10f;
    public float m_WaitTime = 1f;
    public List<Transform> m_MovePointList = new List<Transform>();
    public int m_CurrentIndex = 0;
    public bool m_CanLoop = false;

    private float m_CurrentTime;

    private Vector3 m_StartPos;
    private Vector3 m_EndPos;
    private Quaternion m_StartRot;
    private Quaternion m_EndRot;

    private void Start()
    {
        StartCoroutine(LerpToPoint());
    }

    private void RestartLerptoPoint()
    {
        m_CurrentIndex++;
        if (m_CurrentIndex == m_MovePointList.Count)
        {
            if (m_CanLoop)
            {
                m_CurrentIndex = 0;
                StartCoroutine(LerpToPoint());
            }
        }
        else
        {
            StartCoroutine(LerpToPoint());
        }
    }

    private IEnumerator LerpToPoint()
    {
        m_StartPos = transform.position;
        m_EndPos = m_MovePointList[m_CurrentIndex].position;

        m_StartRot = transform.rotation;
        m_EndRot = m_MovePointList[m_CurrentIndex].localRotation;

        yield return new WaitForSeconds(m_WaitTime);
        float value;

        while (m_CurrentTime != m_MoveTime)
        {
            m_CurrentTime += Time.deltaTime;
            if (m_CurrentTime > m_MoveTime)
            {
                m_CurrentTime = m_MoveTime;
            }

            value = m_CurrentTime / m_MoveTime;
            transform.position = Vector3.Lerp(m_StartPos, m_EndPos, value);
            transform.rotation = Quaternion.Slerp(m_StartRot, m_EndRot, value);
            yield return new WaitForEndOfFrame();
        }
        m_CurrentTime = 0f;
        RestartLerptoPoint();
    }
}
