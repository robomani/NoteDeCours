using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class DragAndDropExample : EditorWindow
{
    [MenuItem("Tools/DragAndDrop...")]
    private static void Init()
    {
        GetWindow<DragAndDropExample>().Show();
    }

    private void OnGUI()
    {
        DrawDragZone("Zone 1", 50f, OnDragPerform1);
        GUILayout.Space(15f);
        DrawDragZone("Zone 2", i_OnDragPerform: OnDragPerform2);
    }

    private void OnDragPerform1(Object[] i_Objects)
    {
        Debug.Log(i_Objects.Length);
    }

    private void OnDragPerform2(Object[] i_Objects)
    {
        foreach (Object obj in i_Objects)
        {
            Debug.Log(obj.name);
        }
    }

    private void DrawDragZone(string i_Label, float i_Height = 50f, System.Action<Object[]> i_OnDragPerform = null)
    {
        Rect dragArea = GUILayoutUtility.GetRect(0f,i_Height);
        GUI.Box(dragArea, i_Label);

        Event curEvent = Event.current;

        if (!dragArea.Contains(curEvent.mousePosition))
        {
            return;
        }

        if (curEvent.type == EventType.DragUpdated || curEvent.type == EventType.DragPerform)
        {
            DragAndDrop.visualMode = DragAndDropVisualMode.Copy;

            if (curEvent.type == EventType.DragPerform)
            {
                if (i_OnDragPerform != null)
                {
                    i_OnDragPerform(DragAndDrop.objectReferences);
                }
            }
        }
    }
}
