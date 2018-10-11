using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXAudio : MonoBehaviour
{
    [SerializeField]
    private AudioSource m_AudioSource;

    private float m_Counter;
    private float m_Duration;

    public void Setup(AudioClip i_Clip)
    {
        m_AudioSource.clip = i_Clip;
        m_Duration = i_Clip.length;
    }

    public void Play()
    {
        m_AudioSource.Play();
    }

    private void Update()
    {
        m_Counter += Time.deltaTime;
        if (m_Counter >= m_Duration)
        {
            Destroy(gameObject);
        }
    }
}
