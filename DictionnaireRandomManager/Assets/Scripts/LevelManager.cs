using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    private GameObject m_LoadingScreen;

    private bool m_WaitTimeReady;
    private bool m_LoadingReady;

    public Action m_OnChangeScene;

    private static LevelManager m_Instance;
    public static LevelManager Instance
    {
        get { return m_Instance;}
    }

    private void Awake()
    {
        if (m_Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            m_Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        m_LoadingScreen.SetActive(false);
    }

    private void StartLoading()
    {
        m_LoadingScreen.SetActive(true);
    }

    private void OnLoadingDone(Scene i_Scene, LoadSceneMode i_Mode)
    {
        SceneManager.sceneLoaded -= OnLoadingDone;

        if (m_WaitTimeReady)
        {
            m_LoadingScreen.SetActive(false);
        }
        else
        {
            m_LoadingReady = true;
        }
    }

    public void ChangeLevel(string i_Scene, float i_Time = 3.0f)
    {
        m_LoadingReady = false;
        m_WaitTimeReady = false;
        StartLoading();
        if (m_OnChangeScene != null)
        {
            m_OnChangeScene();
        }
        SceneManager.sceneLoaded += OnLoadingDone;
        StartCoroutine(WaitLoading(i_Time, i_Scene));
        
    }

    private IEnumerator WaitLoading(float i_Time , string i_Scene)
    {
        if (i_Time <= 0)
        {
            i_Time = 0.1f;
        }
        yield return new WaitForSeconds(i_Time);
        m_WaitTimeReady = true;
        SceneManager.LoadScene(i_Scene);
        if (m_LoadingReady)
        {
            m_LoadingScreen.SetActive(false);
        }

    }
}
