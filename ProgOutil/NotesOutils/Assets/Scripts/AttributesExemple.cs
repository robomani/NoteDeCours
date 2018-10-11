using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(Rigidbody))]
public class AttributesExemple : MonoBehaviour
{
    #region NestedClasses
    [System.Serializable]
    public class Data
    {
        public int m_ID;
        public GameObject m_GO;
    }
    #endregion

    [Header("Group 1")]
    public float myFloat;

    [SerializeField]
    [Clear]
    private bool serializedBool;

    [HideInInspector]
    public bool publicHiddenBool;

    [Range(0,1)]
    [Tooltip("This is used for nothing")]
    public float m_Range;

    [Space(10f)]
    [Header ("Group 2")]
    [Multiline(5)]
    public string m_Multiline;

    [Clear]
    public string m_ClearString;

    public Data m_Data;

    private void OnGUI()
    {
        GUI.Label(new Rect(0f, 0f, 100f, 20f), "My Label");
    }
}
