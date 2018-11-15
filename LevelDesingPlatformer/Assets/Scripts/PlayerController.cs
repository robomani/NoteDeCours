using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    public float m_RunSpeed = 10f;
    public float m_RunAcceleration = 5f;
    public float m_TurnSpeed = 10f;
    public float m_JumpForce = 650f;
    public float m_FakeGravity = 20f;
    public float m_MaxGroundAngle = 45f;
    public float m_CharacterHeight = 1f;
    public float m_HeightPadding = 0.5f;
    public LayerMask m_Layer;
    public Transform[] m_RayPositions;

    public bool m_ActiveDebug = true;
    public GameObject m_WaterFilter;
    private bool m_IsInWater;

    private Rigidbody m_RigidBody;
    private float m_CurrentSpeed = 0f;
    private Vector2 m_Input = new Vector2();
    private float m_RotationAngle;
    private float m_GroundAngle;

    private Quaternion m_TargetRotation = new Quaternion();
    private Transform m_Camera;

    private Vector3 m_Foward = new Vector3();
    private Vector3 m_Gravity = new Vector3();
    private RaycastHit m_HitInfo;
    private bool m_IsGrounded = true;
    private Vector3 m_MoveDir = new Vector3();

    private void Awake()
    {
        m_RigidBody = GetComponent<Rigidbody>();
    }

    private void Start ()
    {
        m_Camera = Camera.main.transform;
	}
	
	
	private void Update ()
    {
        GetInput();
        CalculateDirection();
        RayCastGround();
        CalculateGroundAngle();
        CalculateFoward();

        if (m_ActiveDebug)
        {
            DrawDebugLines();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
	}

    private void FixedUpdate()
    {
        if (m_Input != Vector2.zero)
        {
            Rotate();
            SetSpeed();
        }
        else
        {
            ResteSpeed();
        }

        m_MoveDir = m_Foward * m_CurrentSpeed;
        m_MoveDir.y = m_RigidBody.velocity.y;

        if (m_RigidBody.velocity.y != 0)
        {
            m_MoveDir.y -= m_FakeGravity * Time.fixedDeltaTime;
        }

        m_RigidBody.velocity = m_MoveDir;
    }

    private void GetInput()
    {
        m_Input.x = Input.GetAxis("Horizontal");
        m_Input.y = Input.GetAxis("Vertical");
    }

    private void CalculateDirection()
    {
        //Calcul l'angle selon l'input
        m_RotationAngle = Mathf.Atan2(m_Input.x, m_Input.y);
        //Transfère l'angle en degré
        m_RotationAngle *= Mathf.Rad2Deg;
        //Rotation relative à la camera
        m_RotationAngle += m_Camera.localEulerAngles.y;
    }

    private void CalculateFoward()
    {
        if (m_IsGrounded)
        {
            //Retourn le vecteur "Forward" en considérent la pente sur laquelle nous somment. Donc nous voulons un "Forward" parallele
            m_Foward = Vector3.Cross(transform.right, m_HitInfo.normal);
        }
        else
        {
            m_Foward = transform.forward;
        }
    }

    private void CalculateGroundAngle()
    {
        if (m_IsGrounded)
        {
            //Ici on determine l'angle du sol en utilisant la normal et notre foward
            m_GroundAngle = Vector3.Angle(m_HitInfo.normal, transform.forward);
        }
        else
        {
            m_GroundAngle = 90f;
        }
    }

    private void RayCastGround()
    {
        bool touch = false;
        for (int i = 0; i < m_RayPositions.Length; i++)
        {
            if (Physics.Raycast(m_RayPositions[i].position, Vector3.down, out m_HitInfo, m_CharacterHeight + m_HeightPadding, m_Layer))
            {
                m_IsGrounded = true;
                touch = true;
            }
        }

        if (Physics.Raycast(transform.position, Vector3.down, out m_HitInfo, m_CharacterHeight + m_HeightPadding, m_Layer))
        {
            m_IsGrounded = true;
            touch = true;
        }
        else if(!touch)
        {
            m_IsGrounded = false;
        }
    }

    private void Rotate()
    {
        //Convertis les eulersAngles en quaternion
        m_TargetRotation = Quaternion.Euler(0f, m_RotationAngle, 0f);
        transform.rotation = Quaternion.Slerp(transform.rotation, m_TargetRotation, m_TurnSpeed * Time.fixedDeltaTime);
    }

    private void SetSpeed()
    {
        if (m_GroundAngle < m_MaxGroundAngle + 90f)
        {
            if (m_CurrentSpeed < m_RunSpeed)
            {
                m_CurrentSpeed += m_RunSpeed * (m_RunAcceleration * Time.fixedDeltaTime);
            }
        }
        else
        {
            ResteSpeed();
        }
    }

    private void Jump()
    {
        if (m_IsGrounded || m_IsInWater)
        {
            m_IsGrounded = false;
            m_RigidBody.velocity = Vector3.zero;
            m_RigidBody.AddForce(transform.up * m_JumpForce);
        }
    }

    private void ResteSpeed()
    {
        m_CurrentSpeed = 0f;
    }

    private void DrawDebugLines()
    {
        Debug.DrawLine(transform.position, transform.position + m_Foward * m_HeightPadding * 2f, Color.blue);
        Debug.DrawLine(transform.position, transform.position - Vector3.up * (m_CharacterHeight + m_HeightPadding), Color.green);
        for (int i = 0; i < m_RayPositions.Length; i++)
        {
            Debug.DrawLine(m_RayPositions[i].position, m_RayPositions[i].position - Vector3.up * (m_CharacterHeight + m_HeightPadding), Color.green);
        }
    }

    public void InWater()
    {
        m_FakeGravity = -5f;
        m_JumpForce = 150.0f;
        m_IsInWater = true;
        if (m_WaterFilter)
        {
            m_WaterFilter.SetActive(true);
        }
    }

    public void ExitWater()
    {
        m_FakeGravity = 20.0f;
        m_JumpForce = 650.0f;
        m_IsInWater = false;
        if (m_WaterFilter)
        {
            m_WaterFilter.SetActive(false);
        }
    }

    public void InWind()
    {
        m_FakeGravity = -50f;
        m_RigidBody.AddForce(transform.up * m_JumpForce);
    }

    public void ExitWind()
    {
        m_FakeGravity = 20.0f;
    }
}
