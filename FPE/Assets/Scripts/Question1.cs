using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Material), typeof(Rigidbody))]
public class Question1 : MonoBehaviour
{
    [SerializeField]
    private float m_Speed = 10f;

    private Vector3 m_Dir;
    private Material m_Material;
    private Rigidbody m_RigidBody;

    private void Start()
    {
        m_Material = GetComponent<Renderer>().material;
        m_RigidBody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetButton("Horizontal"))
        {
            m_Dir.x = m_Speed * Input.GetAxisRaw("Horizontal");
        }
        else
        {
            m_Dir.x = 0;
        }
        
        if(Input.GetButton("Vertical"))
        {
            m_Dir.z = m_Speed * Input.GetAxisRaw("Vertical");
        }
        else
        {
            m_Dir.z = 0;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            m_Material.color = Random.ColorHSV();
        }
    }

    private void FixedUpdate()
    {
        if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
        {
            m_RigidBody.AddForce(m_Dir);
        }
        
    }
}
