using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ici le require ajoute le composant sur l'object au même moment ou le script est ajouter (Seulement si il n'y en a pas deja un)
[RequireComponent(typeof(Rigidbody))]
public class PlayerControllerMario : MonoBehaviour
{
    //Variables editeur
    [SerializeField]
    private float m_RotationSpeed = 20f;
    [SerializeField]
    private float m_RunnSpeed = 10f;
    [SerializeField]
    private float m_RunAcceleration = 5f;
    [SerializeField]
    private float m_JumpForce = 650f;
    [SerializeField]
    private float m_FakeGravity = 20f;
    [SerializeField]
    private Transform m_RaycastParrent;

    //Variables input et mouvement
    private float m_CurrentSpeed = 0f;
    private float m_InputX = 0f;
    private float m_InputZ = 0f;
    private bool m_IsGrounded = true;

    //Vecteur
    private Vector3 m_LookRotation = new Vector3();
    private Vector3 m_MoveDir = new Vector3();

    //Component
    private Rigidbody m_Rigidbody;

    private void Awake()
    {
        //Initialiser mes variables;
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        //Modifier la velocitée
        m_MoveDir.y = m_Rigidbody.velocity.y;
        if (m_Rigidbody.velocity.y != 0f)
        {
            m_MoveDir.y -= m_FakeGravity * Time.fixedDeltaTime;
        }
        m_Rigidbody.velocity = m_MoveDir;
    }

    private void Update()
    {
        // valider les Inputs utilisateurs
        if (CheckInputAxis())
        {
            if (m_CurrentSpeed < m_RunnSpeed)
            {
                m_CurrentSpeed += m_RunnSpeed * (m_RunAcceleration * Time.deltaTime);
            }
            m_MoveDir = transform.forward * m_CurrentSpeed;
        }
        else
        {
            m_MoveDir = Vector3.zero;
            m_CurrentSpeed = 0f;
        }

        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }

        UpdateRotation();
        RaycastGround();
    }

    private void Jump()
    {
        //On ajoute une force en y au joueur
        if (m_IsGrounded)
        {
            m_IsGrounded = false;
            //ici on anule la velocitée courante en y
            m_Rigidbody.velocity = new Vector3(m_Rigidbody.velocity.x,0f,m_Rigidbody.velocity.z);
            //on lui donne une force en y
            m_Rigidbody.AddForce(transform.up * m_JumpForce);
        }
    }

    private void UpdateRotation()
    {
        m_LookRotation.x = m_InputX;
        m_LookRotation.z = m_InputZ;
        m_LookRotation *= m_RunnSpeed;

        if (CheckInputAxis())
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(m_LookRotation),m_RotationSpeed * Time.deltaTime);
        }
    }

    private void RaycastGround()
    {
        //raycast le sol 9 fois
        if (m_Rigidbody.velocity.y < 0f)
        {
            for (int i = 0; i < m_RaycastParrent.childCount; i++)
            {
                Debug.DrawRay(m_RaycastParrent.GetChild(i).transform.position, -transform.up);
                if (Physics.Raycast(m_RaycastParrent.GetChild(i).transform.position, -transform.up, 0.6f))
                {
                    m_IsGrounded = true;
                    return;
                }
            }
        }      
    }

    private bool CheckInputAxis()
    {
        //Verifie les unputs et retourn vrais s'il y a input
        m_InputX = Input.GetAxis("Horizontal");
        m_InputZ = Input.GetAxis("Vertical");
        return m_InputX != 0f || m_InputZ != 0f;
    }
}
