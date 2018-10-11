using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public struct Background
{
    public float m_LayerDistance;
    public GameObject m_Visual;
}

public class ParallaxeInfini : MonoBehaviour
{
    [SerializeField]
    private List<Background> m_Backgrounds = new List<Background>();
    [SerializeField]
    private float m_Speed = 10;

    private Vector3 m_BackgroundTargetPos = new Vector3();

    private void LateUpdate()
    {
        float parallaxeValue;
        Background background;

        for (int i = 0; i < m_Backgrounds.Count; i++)
        {
            background = m_Backgrounds[i];
            parallaxeValue = 0;
            parallaxeValue = -0.01f * background.m_LayerDistance;

            m_BackgroundTargetPos = background.m_Visual.transform.position;

            m_BackgroundTargetPos.x += parallaxeValue;

            Debug.Log(parallaxeValue);

            if (m_BackgroundTargetPos.x > -19.2f)
            {
                background.m_Visual.transform.position = Vector3.Lerp(background.m_Visual.transform.position, m_BackgroundTargetPos, m_Speed * Time.deltaTime);
                Debug.Log(background.m_Visual.transform.position);
                Debug.Log(m_BackgroundTargetPos);
            }
            else
            {
                background.m_Visual.transform.position = new Vector3(19.2f,0,0);
                Debug.Log("Teleporte");
            }
            
        }

    }
}
