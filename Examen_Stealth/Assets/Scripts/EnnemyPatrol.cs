using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;


public class EnnemyPatrol : MonoBehaviour
{
    public NavMeshAgent m_Agent;
    public AICharacterControl m_AI;
    public List<Transform> m_Path = new List<Transform>();
    public int m_PatrolSpot;
    public float m_MaxSeeDistance = 100;
    public float m_DelayBetweenMoves = 1.0f;
    public float m_time = 0f;
    public bool m_AtDestination = true;
    public GameObject m_InteractPromp;

    private RaycastHit m_HitInfo;
    private Ray m_Ray;

    private void Start()
    {
        m_AI = GetComponent<AICharacterControl>();
    }

    private void Update ()
    {
        m_Ray.origin = transform.position;
        m_Ray.direction = transform.forward;
        Debug.DrawRay(transform.position, transform.forward, Color.red, 0.1f);
        if (Physics.Raycast(m_Ray, out m_HitInfo, m_MaxSeeDistance))
        {
            if (m_HitInfo.transform.tag == "Player")
            {
                m_AI.target = m_HitInfo.transform;
            }
        }

        if (m_Path.Count > 0)
        {
            if (m_AtDestination)
            {
                if (m_time < m_DelayBetweenMoves )
                {
                    m_time += Time.deltaTime;
                }
                else
                {
                    m_time = 0;
                    
                    if (m_PatrolSpot >= m_Path.Count)
                    {
                        m_PatrolSpot = 0;
                    }
                    m_Agent.SetDestination(m_Path[m_PatrolSpot].position);
                    m_AtDestination = false;
                }
            }
            else
            {

                if (transform.position.x == m_Path[m_PatrolSpot].position.x && transform.position.z == m_Path[m_PatrolSpot].position.z)
                {
                    m_AtDestination = true;
                    m_PatrolSpot++;
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        m_Ray.origin = transform.position;
        m_Ray.direction = other.transform.position;
        Debug.DrawRay(transform.position, other.transform.position, Color.red, 5.0f);
        if (other.tag == "Player" && Physics.Raycast(m_Ray, out m_HitInfo, m_MaxSeeDistance))
        {
            if (m_HitInfo.transform.tag == "Player")
            {
                m_Agent.SetDestination(m_HitInfo.transform.position);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            m_AtDestination = true;
        }
    }

    private void OnCollisionEnter(Collision i_Collision)
    {
        if (i_Collision.gameObject.tag == "Player")
        {
            m_InteractPromp.SetActive(true);
        }
    }
}
