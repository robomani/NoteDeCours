using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnnemyController : BaseCharacter
{
    public GameObject m_GoalManager;

    private void Start()
    {
        m_GoalManager = GameObject.FindGameObjectWithTag("Goal");
    }

    protected virtual void OnTriggerStay(Collider other)
    {
        if (other.tag == "Civilian")
        {
            m_RigidBody.velocity = (other.transform.position - transform.position).normalized * m_MoveSpeed;
        }
        else if (other.tag == "Player")
        {
            m_RigidBody.velocity = (other.transform.position - transform.position).normalized * m_MoveSpeed;
        }
        else
        {

        }
    }
    protected virtual void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Scenes/DiabloLike", LoadSceneMode.Single);
        }
        else if (collision.gameObject.tag == "Militia")
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
        
    }

    public override void Death()
    {
        m_GoalManager.GetComponent<GoalController>().KillEnnemy();
        base.Death();
    }
}
