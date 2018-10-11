using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class EditorPrefsWindow : EditorWindow
{
    [MenuItem("Tools/EditorPrefs Window")]
    private static void Init()
    {
        GetWindow<EditorPrefsWindow>().Show();
    }

    private enum EditorKey
    {
        TestBool,
        TestInt,
        TestFloat,
        TestString,
    }

    private bool m_TestBool;
    private int m_TestInt;
    private float m_TestFloat;
    private string m_TestString;

    private void OnGUI()
    {
        string[] keys = System.Enum.GetNames(typeof(EditorKey));
        for (int i = 0; i < keys.Length; i++)
        {
            EditorGUI.BeginDisabledGroup(!EditorPrefs.HasKey(keys[i]));
            if (GUILayout.Button(keys[i]))
            {
                EditorPrefs.DeleteKey(keys[i]);
            }
            EditorGUI.EndDisabledGroup();
        }

        m_TestBool = EditorPrefs.GetBool(EditorKey.TestBool.ToString(), true);
        EditorGUI.BeginChangeCheck();
        m_TestBool = EditorGUILayout.Toggle("Test Bool", m_TestBool);
        if (EditorGUI.EndChangeCheck())
        {
            EditorPrefs.SetBool(EditorKey.TestBool.ToString(), m_TestBool);
        }

        m_TestInt = EditorPrefs.GetInt(EditorKey.TestInt.ToString(), -99);
        m_TestInt = EditorGUILayout.IntField("Test Int", m_TestInt);
        EditorPrefs.SetInt(EditorKey.TestInt.ToString(), m_TestInt);

        m_TestFloat = EditorPrefs.GetFloat(EditorKey.TestFloat.ToString(), 12.55f);
        m_TestFloat = EditorGUILayout.FloatField("Test float", m_TestFloat);
        EditorPrefs.SetFloat(EditorKey.TestFloat.ToString(), m_TestFloat);

        m_TestString = EditorPrefs.GetString(EditorKey.TestString.ToString(), "Gardevoir");
        m_TestString = EditorGUILayout.TextField("Test String", m_TestString);
        EditorPrefs.SetString(EditorKey.TestString.ToString(), m_TestString);


    }
}
