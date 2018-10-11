using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineTest : MonoBehaviour
{
    [SerializeField]
    private float m_Delay = 3f;

    private WaitForSeconds m_TimeToWait;
    private Coroutine m_HurtCoroutine;

    private void Start()
    {
        
        m_TimeToWait = new WaitForSeconds(m_Delay);
        //StartCoroutine(WaitForCoroutine());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            if (m_HurtCoroutine != null)
            {
                StopCoroutine(m_HurtCoroutine);
                m_HurtCoroutine = null;
            }
            m_HurtCoroutine = StartCoroutine(HurtSequence());
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            Die();
        }
    }

    private IEnumerator WaitForGinetteToRetire()
    {
        Debug.Log("Before Wait");
        //ici on reutilise notre WaitForSeconds pour crée moins de déchets.
        yield return m_TimeToWait;

        Debug.Log("Alfter Wait");
    }

    private IEnumerator WaitForCoroutine()
    {
        Debug.Log("J'attend que Ginette prenne sa retraite");

        yield return StartCoroutine(WaitForGinetteToRetire());

        Debug.Log("Ginette a enfin pris sa retraite.");
    }

    private IEnumerator HurtSequence()
    {
        Debug.Log("Red screen");
        yield return new WaitForSeconds(0.5f);
        Debug.Log("Sploosh de sang");
        yield return new WaitForSeconds(1f);
        Debug.Log("AAAAAAAHHHHHHHHHHHHHHHHHHHHHHHHOOOOOOOOOOOOOOOUUUUUUUCCCCCCHHHHHHHHHHHH CIBOLE");
    }

    private void Die()
    {
        Debug.Log("Meurt");
        StopAllCoroutines();
    }
}
