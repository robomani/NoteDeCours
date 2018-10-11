using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Rigidbody2D m_RB;
    public float m_Speed = 10f;
    public float m_JumpForce = 50f;
    public GameObject m_Projectile;
    public Transform m_SpawnProjectilePosition;

    private GameObject m_CurrentProjectile = null;
    private Vector2 m_MoveDir = new Vector2();
    private void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            m_MoveDir = transform.right;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            m_MoveDir = -transform.right;
        }
        else
        {
            m_MoveDir = Vector2.zero;
        }

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W))
        {
            m_RB.AddForce(transform.up * m_JumpForce);
        }
        
        Debug.DrawRay(transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position, Color.grey);
        //Physics2D.Raycast(transform.position,(Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position),100f, LayerMask.GetMask("Effector")) && 
        if (!m_CurrentProjectile)
        {
            if (Input.GetMouseButtonDown(0))
            {            
                m_CurrentProjectile = Instantiate(m_Projectile, m_SpawnProjectilePosition.position, Quaternion.identity);
                m_CurrentProjectile.GetComponent<Projectile>().m_MoveDir = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized;
            }
            
        }
    }

    private void FixedUpdate()
    {
        m_MoveDir *= m_Speed;
        m_MoveDir.y = m_RB.velocity.y;
        m_RB.velocity = m_MoveDir;
    }
}
