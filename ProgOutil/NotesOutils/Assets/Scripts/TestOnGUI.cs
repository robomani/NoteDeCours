using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestOnGUI : MonoBehaviour
{
    public Texture m_MyTexture;
    public Texture2D m_BoxBackground;
    public string[] m_MyStrings;
    public Rect m_WindowRect = new Rect(50f, 50f, 200f, 100f);

    private bool m_ShowTexture;
    private int m_SelectionIndex;
    private float m_HorisontalSliderValue = 0.5f;
    private float m_VerticalSliderValiue = 0.25f;
    private string m_MyPassword = "";
    private Vector2 m_ScrollPosition;
    private Rect m_BoxRect;

    private void OnGUI()
    {
        m_BoxRect = new Rect(0f, 0f, Screen.width * m_HorisontalSliderValue, Screen.height * m_VerticalSliderValiue);
        Rect scrollRect = m_BoxRect;
        scrollRect.height = 500f;
        Rect scrollViewRect = scrollRect;
        scrollViewRect.width += 20;
        scrollViewRect.height += 20;

        m_ScrollPosition = GUI.BeginScrollView(scrollRect, m_ScrollPosition,scrollViewRect);

        GUIStyle boxStyle = new GUIStyle(GUI.skin.box);
        if (m_BoxBackground != null)
        {
            boxStyle.normal.background = m_BoxBackground;
        }
        GUI.Box(m_BoxRect, "My Box", boxStyle);
        m_BoxRect.height = 20f;

        SetNewLine();

        

        GUIStyle labelStyle = new GUIStyle(GUI.skin.GetStyle("Label"));
        GUIContent myContent = new GUIContent("MyLabel", "This is a label");
        Vector2 labelSize = labelStyle.CalcSize(myContent);


        //labelStyle.alignment = TextAnchor.MiddleCenter;
        Rect LabelRect = GetCenterRect(m_BoxRect, labelSize.x);
        GUI.Label(LabelRect, myContent, labelStyle);

        SetNewLine();

        Rect sliderRect = GetCenterRect(m_BoxRect, m_BoxRect.width*0.5f);
        

        m_HorisontalSliderValue = GUI.HorizontalSlider(sliderRect, m_HorisontalSliderValue,0.1f,1f);
        SetNewLine(100f);

        Rect verticalSliderRect = GetCenterRect(m_BoxRect, 20f);
        m_VerticalSliderValiue = GUI.VerticalSlider(verticalSliderRect, m_VerticalSliderValiue, 0.1f, 1f);

        SetNewLine();

        Rect passWordRect = GetCenterRect(m_BoxRect);
        m_MyPassword = GUI.PasswordField(passWordRect, m_MyPassword, '*', 10);

        SetNewLine();
        Rect textRect = GetCenterRect(m_BoxRect);
        m_MyPassword = GUI.TextField(textRect, m_MyPassword);

        SetNewLine(100f);
        Rect selectionRect = GetCenterRect(m_BoxRect, m_BoxRect.width * 0.5f);
        m_SelectionIndex = GUI.SelectionGrid(selectionRect, m_SelectionIndex, m_MyStrings, 2);


        GUI.EndScrollView();

        m_WindowRect = GUI.Window(0,m_WindowRect,ShowWindow,"Window");

        ShowGroup();
    }

    private void ShowWindow(int i_WindowID)
    {
        if (GUI.Button(new Rect(0f,20f,100f,20f),"Ben Buton"))
        {
            Debug.Log("Press Ben Button");
        }
        Rect dragRect = m_WindowRect;
        dragRect.x = 0;
        dragRect.y = 0;
        GUI.DragWindow(dragRect);
    }

    private Rect GetCenterRect(Rect i_GroupRect, float i_Width = -1f)
    {
        Rect rect = i_GroupRect;

        //Operateur Ternaire
        //              Condition ? If True           : If False
        rect.width = i_Width < 0f ? i_GroupRect.width : i_Width;

        
        rect.x += i_GroupRect.width * 0.5f - rect.width * 0.5f;
        return rect;
    }

    private void SetNewLine(float i_Height = 20f, float i_Spacing = 5f)
    {
        m_BoxRect.y += m_BoxRect.height + i_Spacing;
        m_BoxRect.height = i_Height;
        
    }

    private void ShowGroup()
    {
        Rect groupRect = new Rect(350f, 10f, m_MyTexture.width, m_MyTexture.height);
        GUI.BeginGroup(groupRect);
        {
            groupRect.x = 0f;
            groupRect.y = 0f;
            GUI.Box(groupRect, "");
            if (m_ShowTexture)
            {
                Rect textureRect = new Rect(0f, 0f, m_MyTexture.width, m_MyTexture.height);
                GUI.DrawTexture(textureRect, m_MyTexture);
            }


            Rect buttonRect = new Rect(0f, 0f, 50f, 20f);
            bool hasBeenPressed = GUI.Button(buttonRect, "Button");
            if (hasBeenPressed)
            {
                m_ShowTexture = !m_ShowTexture;
            }


        }
        GUI.EndGroup();
    }

    
}
