using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum BehaviourState
{
    Idle,
    Flee,
    Chase,
    Attack,
    EatRamenSoup,
}

public class AIController : MonoBehaviour
{
    private BehaviourState m_State;
    public int HP = 100;
    public NavMeshAgent m_Agent;
    

    //cette variable devrais être dans le GameManager
    public GameObject m_Player;

    public float m_ChaseThreshold = 5f;

    private Vector3 m_StartPos;

    private void Start()
    {
        m_State = BehaviourState.Idle;
        m_StartPos = transform.position;
    }

    private void Update()
    {
        if (CompareState(BehaviourState.Idle))
        {
            UpdateIdle();
        }

        if (CompareState(BehaviourState.Chase))
        {
            UpdateChase();
        }

        if (CompareState(BehaviourState.Attack))
        {
            UpdateAttack();
        }

        if (CompareState(BehaviourState.Flee))
        {
            UpdateFlee();
        }

        if (CompareState(BehaviourState.EatRamenSoup))
        {
            UpdateEatRamenSoup();
        }
    }

    private void UpdateIdle()
    {
        //on verifie la distance entre notre joueur et notre ai
        if (Vector3.Distance(transform.position, m_Player.transform.position) <= m_ChaseThreshold)
        {
            ChangeState(BehaviourState.Chase);
        }
    }
    private void UpdateFlee()
    {

    }
    private void UpdateChase()
    {
        if (Vector3.Distance(transform.position, m_Player.transform.position) > m_ChaseThreshold)
        {
            ChangeState(BehaviourState.Idle);
            m_Agent.SetDestination(m_StartPos);
        }
        else
        {
            m_Agent.SetDestination(m_Player.transform.position);
        }
    }
    private void UpdateAttack()
    {

    }
    private void UpdateEatRamenSoup()
    {

    }

    private void ChangeState(BehaviourState i_State)
    {
        
        switch (i_State)
        {
            case BehaviourState.Idle:
                if (m_State != BehaviourState.Idle)
                {
                    GetComponent<Renderer>().material.color = Color.green;
                }
                break;
            case BehaviourState.Flee:
                break;
            case BehaviourState.Chase:
                if (m_State != BehaviourState.Chase)
                {
                    GetComponent<Renderer>().material.color = Color.red;
                }
                break;
            case BehaviourState.Attack:
                break;
            case BehaviourState.EatRamenSoup:
                {
                    if (i_State != BehaviourState.EatRamenSoup)
                    {
                        //Call eatramensup animation
                    }
                    break;
                }
            default:
                break;
        }
        m_State = i_State;
    }

    private bool CompareState(BehaviourState i_State)
    {
        return i_State == m_State;
    }

    private void ReceiveDamage(int i_Damage)
    {
        HP -= i_Damage;
        if (HP < 10)
        {
            m_State = BehaviourState.EatRamenSoup;
        }
    }
}
