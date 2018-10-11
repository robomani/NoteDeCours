using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : DontDestroyOnLoad
{
    //Pour le singleton satic veut dire que l'on peut y acceder de partout
    private static AudioManager m_Instance;
    public static AudioManager Instance
    {
        get
        {
            return m_Instance;
        }
    }

    [SerializeField]
    private SFXAudio m_SFXAudioPrefab;

    [SerializeField]
    private AudioSource m_AudioSourceMusic;

    [SerializeField]
    private AudioClip m_Music1;
    [SerializeField]
    private AudioClip m_Music2;

    protected override void Awake()
    {
        //On s'assure qu'il n'y en ait qu'un seul
        if (m_Instance != null)
        {
            //on detruit le deuxième
            Destroy(gameObject);
        }
        else
        {
            //on déclare le premier à notre static
            m_Instance = this;
        }
        base.Awake();
    }

    private IEnumerator SwichMusicRoutine(float i_Duration, AudioClip i_NextClip)
    {
        if (i_Duration <= 0)
        {
            Debug.LogError("Duration is <= 0f, so you should Never use this fonction, tell Alexandre ML if this happens");
            yield break;
        }
        while (m_AudioSourceMusic.volume > 0f)
        {
            m_AudioSourceMusic.volume -= Time.deltaTime / i_Duration;
            yield return null;
        }

        m_AudioSourceMusic.clip = i_NextClip;
        m_AudioSourceMusic.Play();

        while(m_AudioSourceMusic.volume < 1f)
        {
            m_AudioSourceMusic.volume += Time.deltaTime / i_Duration;
            yield return null;
        }
    }

    public void SwichMusic(float i_Duration)
    {
        AudioClip nextClip = m_AudioSourceMusic.clip == m_Music1 ? m_Music2 : m_Music1;
        StartCoroutine(SwichMusicRoutine(i_Duration, nextClip));
    }

    public void PlaySFX(AudioClip i_Clip, Vector3 i_Position)
    {
        SFXAudio audio = Instantiate(m_SFXAudioPrefab, i_Position, Quaternion.identity);
        audio.Setup(i_Clip);
        audio.Play();
    }
}


