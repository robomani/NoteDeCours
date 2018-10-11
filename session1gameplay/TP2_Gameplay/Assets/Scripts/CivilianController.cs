using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CivilianController : BaseCharacter
{
    private Material m_Material;
    private Vector3 m_VectTemp;
    


    protected void Start()
    {     
        m_Material = transform.GetComponent<Renderer>().material;
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            m_Material.color = collision.gameObject.GetComponent<Renderer>().material.color;
            foreach (Renderer variableName in GetComponentsInChildren<Renderer>())
            {
                variableName.material.color = collision.gameObject.GetComponent<Renderer>().material.color;
            }          
            transform.tag = "Militia";
            gameObject.layer = LayerMask.NameToLayer("Militia");
            gameObject.AddComponent<MilitiaController>();
            gameObject.GetComponent<MilitiaController>().m_Projectile = this.m_Projectile;
            gameObject.GetComponent<MilitiaController>().m_SpawnPoint = this.m_SpawnPoint;
            gameObject.name = "Militia";
            transform.parent = collision.transform;
            m_RigidBody.velocity = Vector3.zero;
            m_RigidBody.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezeRotationX;
            m_VectTemp = collision.transform.position;
            m_VectTemp.y = (1.5f * collision.gameObject.GetComponent<PlayerController>().GetMilitia());
            transform.position = m_VectTemp;
            Destroy(this);
        }
        else if(collision.gameObject.tag == "Ennemy")
        {
            m_Material.color = collision.gameObject.GetComponent<Renderer>().material.color;
            transform.tag = "Ennemy";
            gameObject.layer = LayerMask.NameToLayer("Ennemy");
            gameObject.AddComponent<EnnemyController>();
            gameObject.name = "Ennemy";
            Destroy(this);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            m_RigidBody.velocity = (other.transform.position - gameObject.transform.position).normalized * m_MoveSpeed;
        }
        else if (other.tag == "Ennemy")
        {
            m_RigidBody.velocity = (gameObject.transform.position - other.transform.position).normalized * m_MoveSpeed;
        }
    }

}