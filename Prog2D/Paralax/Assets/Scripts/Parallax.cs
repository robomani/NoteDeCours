using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Aventage de la struct c'est que nous pouvons l'utiliser comme une variable multiple. Donc une variable qui contien plusieurs variables
[System.Serializable]
public struct Background
{
    public float m_LayerDistance;
    public GameObject m_Visual;
}

public class Parallax : MonoBehaviour
{
    [SerializeField]
    private Transform m_Camera;
    [SerializeField]
    private float m_Smoothing = 1f;
    [SerializeField]
    private List<Background> m_Backgrounds = new List<Background>();

    private Vector3 m_PreviousCamPos = new Vector3();
    private Vector3 m_BackgroundTargetPos = new Vector3();

    private void Start()
    {
        //On stock la position initialle de la camera
        m_PreviousCamPos = m_Camera.position;
    }

    private void LateUpdate()
    {
        float parallaxeValue;
        Background background;

        //On itere dans tout les background pour les deplacer selon leur distance relative
        for (int i = 0; i < m_Backgrounds.Count; i++)
        {
            //On stoque notre background à l'indexe i pour faciliter la reutilisation
            background = m_Backgrounds[i];

            parallaxeValue = (m_PreviousCamPos.x - m_Camera.position.x) * -background.m_LayerDistance;

            //On initialise notre vecteur avec la position courrente de notre visuel
            m_BackgroundTargetPos = background.m_Visual.transform.position;

            //On modiffie la valeur du x de notre background
            m_BackgroundTargetPos.x += parallaxeValue;

            //On interpole linéairement la position actuelle vs la position voulue pour crée notre effet de parallaxe
            background.m_Visual.transform.position = Vector3.Lerp(background.m_Visual.transform.position, m_BackgroundTargetPos, m_Smoothing * Time.deltaTime);
        }

        m_PreviousCamPos = m_Camera.position;
    }
}
