using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private AudioClip m_Audioclip;

    private void OnGUI()
    {
        if (GUI.Button(new Rect(10f,10f,100f,20f), "Play FootStep"))
        {
            AudioManager.Instance.PlaySFX(m_Audioclip, transform.position);
        }
    }
}
