using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnGUI_Exemple : MonoBehaviour
{
    public float m_MyFloat = 0f;
    public Texture2D m_BoxBackground;
    public Color m_BoxStartColor = Color.green;
    public Color m_BoxEndColor = Color.red;
    public string[] m_ToolBarStrings;

    private int m_ToolBarInt = -1;
    private bool m_CheatToggle = true;
    private bool m_MyToggle = false;
    private string m_Mytext;
    private Rect m_MyRect;
    private Texture2D m_TextureCopy;
    private Color m_PreviousColor;
    private Vector2 m_ScrollPosition;

    #region Getters
    private Color CurrentColor
    {
        get
        {
            return Color.Lerp(m_BoxStartColor, m_BoxEndColor, m_MyFloat);
        }
    }
    #endregion
   
    private void Start()
    {

        SetupTexture();
        m_PreviousColor = CurrentColor;
        SetColor();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            m_CheatToggle = !m_CheatToggle;
        }


        if (!m_PreviousColor.Equals(CurrentColor))
        {
            SetColor();
        }

        m_PreviousColor = CurrentColor;
    }

    private void OnGUI()
    {
        if(m_CheatToggle)
        {


            //GUI.color = Color.red;
            //GUI.contentColor = Color.grey;

            GUIStyle style = new GUIStyle(GUI.skin.box);
            if(m_TextureCopy != null)
            {
                style.normal.background = m_TextureCopy;
            }

            float relativeWith = Screen.width * 0.5f;

            m_ScrollPosition = GUI.BeginScrollView(new Rect(10f,10f, relativeWith-50f, 350f),m_ScrollPosition, new Rect(10f, 10f, relativeWith, 400f));


            m_MyRect = new Rect(10f, 10f, 150f, 100f);

            GUI.Box(new Rect(10f, 10f, relativeWith, 500f),"", style);

            if (GUI.Button(m_MyRect, "Button"))
            {
                Debug.Log("Activer");
            }

            SetNewLine(20f);
            GUI.Label(m_MyRect, "My Slider");

            SetNewLine(20f);
            m_MyFloat = GUI.HorizontalSlider(m_MyRect, m_MyFloat, 0f, 1f);

            SetNewLine(50f);
            m_Mytext = GUI.TextField(m_MyRect, m_Mytext);

            SetNewLine(20f);
            m_MyToggle = GUI.Toggle(m_MyRect, m_MyToggle, "Toggle?");

            SetNewLine(20f);
            int currentInt = m_ToolBarInt;
            m_ToolBarInt = GUI.Toolbar(m_MyRect, m_ToolBarInt, m_ToolBarStrings);
            if (currentInt != m_ToolBarInt)
            {
                OnToolbarChanged();
            }

            GUI.EndScrollView();
        }
    }

    private void SetNewLine(float i_Height = 100f ,float i_Spacing = 15f)
    {
        m_MyRect.y += m_MyRect.height + i_Spacing;
        m_MyRect.height = i_Height;
    }

    private void SetColor()
    {
        if (m_TextureCopy == null)
        {
            return;
        }

        for (int y = 0; y < m_TextureCopy.height; y++)
        {
            for (int x = 0; x < m_TextureCopy.width; x++)
            {
                m_TextureCopy.SetPixel(x, y, CurrentColor);
            }
        }
        m_TextureCopy.Apply();
    }

    private void SetupTexture()
    {
        if (m_BoxBackground == null)
        {
            return;
        }
        Color32[] pixels = m_BoxBackground.GetPixels32();
        System.Array.Reverse(pixels);
        m_TextureCopy = new Texture2D(m_BoxBackground.width, m_BoxBackground.height);
        m_TextureCopy.SetPixels32(pixels);
        m_TextureCopy.Apply();
    }

    private void OnToolbarChanged()
    {
        Vector3 newScale = Vector3.zero;
        switch (m_ToolBarInt)
        {
            case 1:
                newScale = Vector3.one;
                break;
            case 2:
                newScale = Vector3.one*2;
                break;
        }
        transform.localScale = newScale;
    }
}
