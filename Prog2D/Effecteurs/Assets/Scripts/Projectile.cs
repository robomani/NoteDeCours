using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Vector2 m_MoveDir = Vector2.zero;
    public float m_Speed = 1;
    public float m_TimeToLive = 3f;

    private void Update()
    {
        m_TimeToLive -= Time.deltaTime;
        if (m_TimeToLive <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        transform.GetComponent<Rigidbody2D>().velocity = m_MoveDir * m_Speed;
    }

    private void OnTriggerEnter2D(Collider2D i_Collision)
    {
        if (i_Collision.gameObject.layer != 9)
        {
            Debug.Log("Plateforme");
            Destroy(gameObject);
        }
        else
        {
            Debug.Log(i_Collision.gameObject.layer);
        }
    }

}
