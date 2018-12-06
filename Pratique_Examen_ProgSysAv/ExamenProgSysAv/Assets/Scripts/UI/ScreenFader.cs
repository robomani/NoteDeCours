using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class ScreenFader : MonoBehaviour
{
    [Range(0.0f, 1.0f)]
    public float fadeRatio = 1.0f;

    private Image m_Image;

    public bool Fading { get; private set; }

    public event Action onFadeComplete;

    // Use this for initialization
    void Start ()
    {
        m_Image = GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
        m_Image.color = new Color(0, 0, 0, fadeRatio);
    }

    public void StartFadeIn()
    {
        StopAllCoroutines();
        Fading = true;
        StartCoroutine(FadeIn());
    }

    IEnumerator FadeIn()
    {
        Fading = true;
        while (fadeRatio < 1.0f)
        {
            fadeRatio += Time.deltaTime;
            yield return null;
        }
        Fading = false;

        if (onFadeComplete != null)
            onFadeComplete();
    }


    public void StartFadeOut()
    {
        StopAllCoroutines();
        Fading = true;
        StartCoroutine(FadeOut());
    }

    IEnumerator FadeOut()
    {
        Fading = true;
        while (fadeRatio > 0.0f)
        {
            fadeRatio -= Time.deltaTime;
            yield return null;
        }
        Fading = false;

        if (onFadeComplete != null)
            onFadeComplete();
    }
}
