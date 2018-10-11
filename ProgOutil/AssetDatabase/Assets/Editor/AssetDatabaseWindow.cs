using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class AssetDatabaseWindow : EditorWindow
{
    private enum AssetAction
    {
        Copy,
        Move,
        Open,
        Rename,
    }

    private const string TEXTURE_PATH = "Assets/Art/Heart.png";
    private const string SPRITE_SHEET_PATH = "Assets/Art/Enemy.png";

    private bool m_ShowTexture;
    private Texture m_Texture;

    private AssetAction m_Action;
    private Object m_Asset;
    private Object m_Directory;

    private string m_Rename;
    private string m_Animal;
    private string[] m_PopupExemple = new string[3] { "Dog", "Cat", "Giraffe" };

    [MenuItem("Tools/Asset Manipulator...")]
    private static void Init()
    {
        GetWindow<AssetDatabaseWindow>().Show();
    }

    private void OnEnable()
    {
        m_Texture = AssetDatabase.LoadAssetAtPath<Texture>(TEXTURE_PATH);
    }

    private void OnGUI()
    {
        ShowAsset();
        ShowAction();
        ShowMisc();
    }

    private void ShowAsset()
    {
        m_Asset = EditorGUILayout.ObjectField("Asset", m_Asset, typeof(Object), false);

        //Si la condition est vrait tout ce qui se trouve à l'interieur sera grisé
        EditorGUI.BeginDisabledGroup(m_Asset == null);
        if (GUILayout.Button("Show Asset Path"))
        {
            // Sert à lui donner le chemin d'accès d'un objet
            string assetPath = AssetDatabase.GetAssetPath(m_Asset);
            // * Permet de nous donner l'extention d'un chemin d'acces
            string extension = Path.GetExtension(assetPath);
            Debug.Log("Asset Path: " + assetPath + " | Extention: " + extension);
        }
        EditorGUI.EndDisabledGroup();
    }

    private void ShowAction()
    {
        EditorGUILayout.BeginVertical(GUI.skin.box);
        EditorGUILayout.LabelField("Action", EditorStyles.centeredGreyMiniLabel);
        // set à montrer en menu déroulant un enum
        m_Action = (AssetAction)EditorGUILayout.EnumPopup("Action", m_Action);

        /*
        //Sert à montrer en liste déroulente à partir d'un array de string
        int index = ArrayUtility.IndexOf(m_PopupExemple, m_Animal);
        index = EditorGUILayout.Popup("Animal", index, m_PopupExemple);
        if (index != -1)
        {
            m_Animal = m_PopupExemple[index];
        }
        */
        ShowParameters();
        ShowActionButton();

        EditorGUILayout.EndVertical();

        
    }

    private void ShowParameters()
    {
        switch (m_Action)
        {
            case AssetAction.Copy:
            case AssetAction.Move:
                EditorGUI.BeginChangeCheck();
                m_Directory = EditorGUILayout.ObjectField("Directory", m_Directory, typeof(Object), false);
                if(EditorGUI.EndChangeCheck())
                {
                    if (m_Directory != null)
                    {
                        string assetPath = AssetDatabase.GetAssetPath(m_Directory);
                        bool isValid = AssetDatabase.IsValidFolder(assetPath);
                        if (!isValid)
                        {
                            m_Directory = null;
                            Debug.LogWarning("This is not a directory");
                        }
                    }
                }
                break;
            case AssetAction.Open:
                break;
            case AssetAction.Rename:
                m_Rename = EditorGUILayout.TextField("Rename", m_Rename);
                break;
            default:
                break;
        }
    }

    private void ShowActionButton()
    {
        EditorGUI.BeginDisabledGroup(m_Asset == null);
        if (GUILayout.Button(m_Action.ToString() + " asset"))
        {
            bool needSave = false;
            string assetPath = AssetDatabase.GetAssetPath(m_Asset);
            switch (m_Action)
            {
                case AssetAction.Copy:
                case AssetAction.Move:
                    if (m_Directory != null)
                    {
                        string directoryPath = AssetDatabase.GetAssetPath(m_Directory);
                        directoryPath += "/" + GetAssetFullName(assetPath);
                        if (assetPath.Equals(directoryPath))
                        {
                            Debug.LogError("Cannot " + m_Action.ToString() + " Since paths are the same!");
                            return;
                        }

                        if (m_Action == AssetAction.Copy)
                        {
                            needSave = AssetDatabase.CopyAsset(assetPath, directoryPath);
                        }
                        else
                        {
                           needSave = string.IsNullOrEmpty(AssetDatabase.MoveAsset(assetPath, directoryPath));
                        }
                    }
                    break;
                case AssetAction.Open:
                    AssetDatabase.OpenAsset(m_Asset);
                    break;
                case AssetAction.Rename:
                    if (!string.IsNullOrEmpty(m_Rename))
                    {
                        needSave = string.IsNullOrEmpty(AssetDatabase.RenameAsset(assetPath, m_Rename)); 
                    }
                    break;
                default:
                    break;
            }
            if (needSave)
            {
                AssetDatabase.SaveAssets();
                AssetDatabase.Refresh();
            }
        }
        EditorGUI.EndDisabledGroup();
    }

    private void ShowMisc()
    {
        EditorGUILayout.BeginVertical(GUI.skin.box);
        EditorGUILayout.LabelField("Misc", EditorStyles.centeredGreyMiniLabel);

        m_ShowTexture = EditorGUILayout.Toggle("Show Texture? ", m_ShowTexture);
        if (m_ShowTexture)
        {
            GUILayout.Label(m_Texture);
        }

        if (GUILayout.Button("Load Sprites"))
        {
            Object[] allObject = AssetDatabase.LoadAllAssetsAtPath(SPRITE_SHEET_PATH);
            foreach (Object obj in allObject)
            {
                Debug.Log("Name: " + obj.name + " | Type: " + obj.GetType().Name);
            }
        }

        EditorGUI.BeginDisabledGroup(m_Asset == null);
        if (GUILayout.Button("Get Dependencies"))
        {
            string assetPath = AssetDatabase.GetAssetPath(m_Asset);
            string[] dependencies = AssetDatabase.GetDependencies(assetPath, true);
            foreach (string str in dependencies)
            {
                Debug.Log(str);
            }
        }
        EditorGUI.EndDisabledGroup();
        EditorGUILayout.EndVertical();
    }

    private string GetAssetFullName(string i_AssetPath)
    {
        string[] splits = i_AssetPath.Split('/');
        return splits[splits.Length - 1];
    }
}
