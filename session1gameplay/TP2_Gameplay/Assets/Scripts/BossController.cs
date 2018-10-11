using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : EnnemyController
{
    public float m_Time = 0;
    public float m_ShootCooldown = 4f;

    public override void Death()
    {
        m_GoalManager.GetComponent<GoalController>().KillBoss();
    }

    protected override void OnTriggerStay(Collider a_Other)
    {
        m_Time += Time.deltaTime;
        if (a_Other.tag == "Player" && m_Time > m_ShootCooldown)
        {
            transform.LookAt(a_Other.transform.position);
            base.Shoot();
            m_Time = 0;
        }
    }
}
