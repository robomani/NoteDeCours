//#define USE_REORDERABLE

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;


[CustomPropertyDrawer(typeof(SpriteAnimation))]
public class SpriteAnimationDrawer : PropertyDrawer
{
    readonly string FLIP_X_PROPERTY_NAME = "m_FlipX";
    readonly string SPRITES_PROPERTY_NAME = "m_Sprites";
    readonly string ID_PROPERTY_NAME = "m_Id";
    readonly string FRAME_DURATION_PROPERTY_NAME = "m_FrameDuration";

    private Dictionary<string, float> lastanimTime = new Dictionary<string, float>();
    private Dictionary<string, float> animTime = new Dictionary<string, float>();
    private Dictionary<string, int> animFrame = new Dictionary<string, int>();
    private readonly Dictionary<Sprite, Texture2D> _textures = new Dictionary<Sprite, Texture2D>();
    private readonly Dictionary<string, ReorderableList> _lists = new Dictionary<string, ReorderableList>();

    // Draw the property inside the given rect
    public override void OnGUI(Rect rect, SerializedProperty property, GUIContent label)
    {
#if USE_REORDERABLE
        {
            var prop = property.FindPropertyRelative(ID_PROPERTY_NAME);
            rect.height = EditorGUIUtility.singleLineHeight;
            EditorGUI.PropertyField(rect, prop);
        }
        {
            var prop = property.FindPropertyRelative(FRAME_DURATION_PROPERTY_NAME);
            rect.y += EditorGUIUtility.singleLineHeight;
            EditorGUI.PropertyField(rect, prop);
        }
        {
            var prop = property.FindPropertyRelative(FLIP_X_PROPERTY_NAME);
            rect.y += EditorGUIUtility.singleLineHeight;
            EditorGUI.PropertyField(rect, prop);
        }
        {
            var prop = property.FindPropertyRelative(SPRITES_PROPERTY_NAME);
            rect.y += EditorGUIUtility.singleLineHeight;
            List(property, prop).DoList(rect);
        }
#else
        EditorGUI.PropertyField(rect, property, true);
        var spritesProp = property.FindPropertyRelative("m_Sprites");
        if (property.isExpanded && spritesProp.isExpanded)
        {
            rect.y += EditorGUIUtility.singleLineHeight * 2 + 16; rect.x = 0;
            DrawAnimationPreview(rect, property, spritesProp);
        }
#endif
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
#if USE_REORDERABLE
        return (8 + 2 * EditorGUIUtility.singleLineHeight +
            List(property, property.FindPropertyRelative(SPRITES_PROPERTY_NAME)).GetHeight());
#else
        return EditorGUI.GetPropertyHeight(property);
#endif
    }

#if USE_REORDERABLE
    private ReorderableList List(SerializedProperty parentProperty, SerializedProperty property)
    {
        SerializedObject serializedObject;
        try
        {
            ReorderableList list;
            serializedObject = property.serializedObject;
            var hashCode = property.propertyPath;
            if (!_lists.ContainsKey(hashCode))
            {
                list = new ReorderableList(serializedObject, property, true, false, true, true);
                list.drawElementCallback = (Rect rect, int index, bool isActive, bool isFocused) =>
                {
                    try
                    {
                        var element = list.serializedProperty.GetArrayElementAtIndex(index);
                        
                        rect.x += 20;
                        rect.width = 128;
                        rect.height = EditorGUIUtility.singleLineHeight;
                        //rect.height = 40;
                        EditorGUI.PropertyField(rect, element, GUIContent.none);

                        if (Event.current.type != EventType.Repaint || element.objectReferenceValue == null)
                            return;

                        if (element.objectReferenceValue != null)
                        {
                            Sprite sp = element.objectReferenceValue as Sprite;

                            rect.x -= 30;
                            rect.width = 48;
                            rect.height = 48;
                            if (!_textures.ContainsKey(sp))
                                _textures[sp] = textureFromSprite(sp);
                            EditorGUI.LabelField(rect, new GUIContent(_textures[sp]));
                        }

                        if (index == 0)
                        {
                            rect.x += EditorGUIUtility.currentViewWidth - 96;
                            DrawAnimationPreview(rect, parentProperty, property);
                        }
                    }
                    catch
                    {
                    };
                };

                list.elementHeightCallback = (index) =>
                {
                    return 40;
                };

                _lists[hashCode] = list;
            }
            else
            {
                list = _lists[hashCode];
            }

            return list;
        }
        catch
        {
            return null;
        }
    }
#endif

    public static Texture2D textureFromSprite(Sprite sprite)
    {
        if (sprite.rect.width != sprite.texture.width)
        {
            Texture2D newText = new Texture2D((int)sprite.rect.width, (int)sprite.rect.height);
            try
            {
                Color[] newColors = sprite.texture.GetPixels((int)sprite.textureRect.x,
                                                             (int)sprite.textureRect.y,
                                                             (int)sprite.textureRect.width,
                                                             (int)sprite.textureRect.height);
                newText.SetPixels(newColors);
                newText.Apply();
            }
            catch // texture is not readable
            {
                // Create a temporary RenderTexture of the same size as the texture
                RenderTexture tmp = RenderTexture.GetTemporary(
                                    sprite.texture.width,
                                    sprite.texture.height,
                                    0,
                                    RenderTextureFormat.Default,
                                    RenderTextureReadWrite.Linear);

                // Blit the pixels on texture to the RenderTexture
                Graphics.Blit(sprite.texture, tmp);

                var previous = RenderTexture.active;
                RenderTexture.active = tmp;

                newText.ReadPixels(new Rect(sprite.rect.x, sprite.texture.height - sprite.rect.y - sprite.rect.height, sprite.rect.width, sprite.rect.height), 0, 0);
                newText.Apply();
                RenderTexture.active = previous;
                RenderTexture.ReleaseTemporary(tmp);
            }
            return newText;
        }
        else
            return sprite.texture;
    }

    void DrawAnimationPreview(Rect rect, SerializedProperty parentProperty, SerializedProperty list)
    {
        if (list.arraySize <= 0) return;

        string animId = parentProperty.FindPropertyRelative(ID_PROPERTY_NAME).stringValue;
        float frameDuration = parentProperty.FindPropertyRelative(FRAME_DURATION_PROPERTY_NAME).floatValue;
        bool flipX = parentProperty.FindPropertyRelative(FLIP_X_PROPERTY_NAME).boolValue;

        if (!animTime.ContainsKey(animId))
        {
            animTime[animId] = 0;
        }
        if (!animFrame.ContainsKey(animId))
        {
            animFrame[animId] = 0;
        }
        if (!lastanimTime.ContainsKey(animId))
        {
            lastanimTime[animId] = Time.realtimeSinceStartup;
        }

        if (Event.current.type == EventType.Repaint)
        {
            animTime[animId] += (Time.realtimeSinceStartup - lastanimTime[animId]);
            lastanimTime[animId] = Time.realtimeSinceStartup;
            if (animTime[animId] > frameDuration)
            {
                animTime[animId] = 0.0f;
                animFrame[animId]++;
            }
        }
        var frame0 = list.GetArrayElementAtIndex(0);
        var frame = list.GetArrayElementAtIndex(animFrame[animId] % list.arraySize);
        //draw a sprite
        Sprite sp0 = frame0.objectReferenceValue as Sprite;
        Sprite sp = frame.objectReferenceValue as Sprite;

        float drawSize = 40;

        float aspectH = sp.rect.width / sp.rect.height;
        float aspectW = sp.rect.height / sp.rect.width;
        float ratio;
        ratio = sp.rect.height / sp0.rect.height;
        if (aspectH < aspectW)
        {
            rect.height = drawSize * ratio;
            rect.width = rect.height * aspectH;
        }
        else
        {
            rect.width = drawSize * ratio;
            rect.height = rect.width * aspectW;
        }
        rect.y -= rect.height - drawSize;
        rect.x += drawSize - (rect.width * 0.5f);
        //rect.x += rect.width;
        rect.x -= (sp.rect.width-sp.pivot.x) * rect.width/sp.rect.width;

        if (!_textures.ContainsKey(sp))
            _textures[sp] = textureFromSprite(sp);
        GUIHelper.DrawTexture(rect, _textures[sp], flipX);
        //EditorGUI.DropShadowLabel(rect, new GUIContent(_textures[sp]));

        //rect.width = 48;
        //rect.height = 48;
        //EditorGUI.LabelField(rect, new GUIContent(_textures[sp]));
    }
}

public static class GUIHelper
{
    private static GUIStyle s_TempStyle = new GUIStyle();

    public static void DrawTexture(Rect position, Texture2D texture, bool flipX = false)
    {
        if (Event.current.type != EventType.Repaint)
            return;

        if (flipX)
        {
            //var oldTexture = texture;
            //texture = new Texture2D(texture.width, texture.height);
            position = new Rect(position.x + position.width, position.y, -position.width, position.height);
        }

        s_TempStyle.normal.background = texture;

        s_TempStyle.Draw(position, GUIContent.none, false, false, false, false);
    }

}