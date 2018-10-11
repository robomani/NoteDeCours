using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MilitiaController : BaseCharacter
{

    private float m_Time = 0;
    public float m_ShootCooldown = 2f;

    protected void Start()
    {
        m_MoveSpeed = 0f;

    }
    public void Update()
    {
        m_Time += Time.deltaTime;
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Ennemy")
        {
            
            if(m_Time >= m_ShootCooldown)
            {
                transform.LookAt(other.transform.position + new Vector3(0, 0.5f, 0));
                base.Shoot();
                m_Time = 0;
            }          
        }
    }

}
