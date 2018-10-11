using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    //Move
    public float m_Speed = 10f;
    public float m_TurnSpeed = 5f;
    public float m_JumpForce = 10f;
    private bool m_Grounded = true;
    private Rigidbody m_RigidBody;

    //Clone PowerUp
    public bool m_Prime = false;
    public int m_NBRClones = 0;
    public int m_MaxClones = 10;
    public GameObject m_PrefabToClone;
    public GameObject[] m_CloneArray;
    public GameObject m_PrimeBody;
    public GameObject m_CloneIcone;
    public Text m_CloneNumberText;

    //RocketJump PowerUp
    public float m_RocketJumpTime = 0f;
    public float m_RocketJumpPower = 50f;
    public GameObject m_JetPack;
    public GameObject m_RocketJumpIcone;
    public Text m_RocketJumpTimeText;

    //Shrink PowerUp
    public int m_MaxNBRShink = 2;
    public int m_ShrinkUsed = 0;
    public GameObject m_ShrinkIcone;
    public Text m_ShrinkNumberText;

    //Reset PowerUp
    public bool m_ResetReady = false;
    private float m_ResetTime = 0.5f;
    public GameObject m_ResetIcone;


    private void Start ()
    {
        if(gameObject.GetComponent<Rigidbody>())
        {
            m_RigidBody = gameObject.GetComponent<Rigidbody>();
        }
        else if(m_Prime)
        {
            Debug.LogError("No RigidBody for the player");
        }
        else
        {
            Debug.LogError("No RigidBody for a clone");
        }
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            m_RigidBody.AddForce(transform.forward * m_Speed);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            m_RigidBody.AddForce(-transform.forward * (m_Speed / 2));
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Quaternion originalRotation = transform.rotation;
            transform.rotation = originalRotation * Quaternion.AngleAxis(-m_TurnSpeed, Vector3.up);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            Quaternion originalRotation = transform.rotation;
            transform.rotation = originalRotation * Quaternion.AngleAxis(m_TurnSpeed, Vector3.up);
        }

        if (Input.GetKeyDown(KeyCode.Space) && m_Grounded)
        {
            m_RigidBody.AddForce(transform.up * m_JumpForce);
            m_Grounded = false;
        }
        else if (Input.GetKey(KeyCode.Space) && !m_Grounded && m_RocketJumpTime > 0)
        {
            m_RigidBody.AddForce(transform.up * m_RocketJumpPower);
            m_RocketJumpTime -= Time.deltaTime;
            if (m_Prime)
            {
                m_RocketJumpTimeText.text = m_RocketJumpTime.ToString();
            }

            if (m_RocketJumpTime <= 0 && gameObject.GetComponent<RocketJumpEffect>())
            {
                Destroy(gameObject.GetComponent<RocketJumpEffect>());
            }
            else if (m_RocketJumpTime <= 0)
            {
                m_RocketJumpTime = 0f;
                m_JetPack.SetActive(false);
            }
        }

        if (m_ResetReady)
        {
            if (m_ResetTime <= 0)
            {
                m_ResetTime = 0.5f;
                m_ResetReady = false;
                m_ResetIcone.SetActive(false);
            }
            else
            {
                m_ResetTime -= Time.deltaTime;
            }

            if (m_NBRClones > 0)
            {
                foreach (GameObject clone in m_CloneArray)
                {
                    Destroy(clone);
                }
                m_NBRClones = 0;
                m_CloneIcone.SetActive(false);
            }

        }
    }

    private void OnTriggerEnter(Collider a_Other)
    {
        if (a_Other.tag == "Ground")
        {
            m_Grounded = true;
        }
    }

}
