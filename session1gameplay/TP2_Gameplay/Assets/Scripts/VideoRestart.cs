using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class VideoRestart : MonoBehaviour
{

    private float m_Time = 212f;
	public TextMeshProUGUI m_Text;
    

	private void Update ()
    {
        m_Time -= Time.deltaTime;
        if(m_Time <= 0)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Scenes/DiabloLike", LoadSceneMode.Single);
        }
        else
        {
            m_Text.text = "Restart in " + m_Time + " secondes";
        }

	}
}
