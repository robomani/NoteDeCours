using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseProjectile : MonoBehaviour
{

	protected virtual void Start ()
    {
		
	}

    protected virtual void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<BaseCharacter>())
        {
            collision.gameObject.GetComponent<BaseCharacter>().m_HP--;
            if(collision.gameObject.GetComponent<BaseCharacter>().m_HP < 1)
            {
                collision.gameObject.GetComponent<BaseCharacter>().Death();
            }
        }
        Destroy(gameObject);
    }
}
