using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BaseCharacter : MonoBehaviour
{

    public float m_MoveSpeed = 40f;
    public Rigidbody m_Projectile;
    public float m_ProjectileSpeed = 10f;
    public Transform m_SpawnPoint;
    public int m_HP = 1;

    public Rigidbody m_RigidBody;
    protected Vector3 m_TargetPosition = new Vector3();
    protected Vector3 m_TargetDirection = new Vector3();

    protected virtual void Awake()
    {
        m_RigidBody = gameObject.GetComponent<Rigidbody>();
        if (m_RigidBody == null)
        {
            Debug.LogError("Pas de Rigid Body");
        }
    }

    protected virtual void Shoot()
    {
        Rigidbody projectileClone = (Rigidbody)Instantiate(m_Projectile, m_SpawnPoint.position, transform.rotation);
        projectileClone.velocity = transform.forward * m_ProjectileSpeed;
    }

    public virtual void Death()
    {
        if(gameObject.tag != "Player")
        {
            Destroy(gameObject);
        }
        else
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Scenes/DiabloLike", LoadSceneMode.Single);
        }

    }
}
