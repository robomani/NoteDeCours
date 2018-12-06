using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(LevelData))]
public class LevelDataEditor : Editor
{
    // Tile size displayed in the editor
    private const float TILE_SIZE = 64;

    // Tile textures
    private Texture m_WallTexture;
    private Texture m_FloorTexture;
    private Texture m_DestructibleWall;

    private LevelData m_Target;
    private Rect m_Rect;
    private Rect m_TileRect;

    private int m_Width;
    private int m_Height;

    private void OnEnable()
    {
        m_Target = target as LevelData;
        m_TileRect = new Rect(0, 0, TILE_SIZE, TILE_SIZE);

        // Get the texture from the special Unity Folder
        m_WallTexture = (Texture)EditorGUIUtility.Load("Bricks.jpg");
        m_FloorTexture = (Texture)EditorGUIUtility.Load("Floor.jpg");
        m_DestructibleWall = (Texture)EditorGUIUtility.Load("DestructibleWall.jpg");


        InitSize();
    }

    public void InitSize()
    {
        if (m_Target.GetWidth() == 0 || m_Target.GetHeight() == 0)
        {
            m_Target.Tiles = new TileColumn[1];
            m_Target.Tiles[0] = new TileColumn(1);
        }

        m_Width = m_Target.GetWidth();
        m_Height = m_Target.GetHeight();
    }

    public override void OnInspectorGUI()
    {
        DrawButton();
        DrawGrid();

        if (GUI.changed)
        {
            EditorUtility.SetDirty(target);
        }
    }

    private void DrawButton()
    {
        EditorGUILayout.BeginHorizontal();
        if (GUILayout.Button("Add Row (+)"))
        {
            AddRow();
        }

        if (GUILayout.Button("Remove Row (-)"))
        {
            RemoveRow();
        }
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        if (GUILayout.Button("Add Column (+)"))
        {
            AddColumn();
        }
        if (GUILayout.Button("Remove Column (-)"))
        {
            RemoveColumn();
        }
        EditorGUILayout.EndHorizontal();
    }

    private void DrawGrid()
    {
        m_Rect = GUILayoutUtility.GetLastRect();
        m_Rect.y += m_Rect.height + TILE_SIZE * 0.5f;
        m_Rect.height = TILE_SIZE * m_Height + TILE_SIZE;

        EditorGUILayout.BeginVertical();
        for (int i = 0; i < m_Target.Tiles.Length; i++)
        {
            EditorGUILayout.BeginHorizontal();
            for (int j = 0; j < m_Target.Tiles[i].Length; j++)
            {
                if (CreateButton(i, j))
                {
                    // Everytime we click a button, we switch to the next tile in the enum
                    int id = (int)m_Target.Tiles[i][j];
                    id = (id + 1) % (int)ETileType.Count;
                    m_Target.Tiles[i][j] = (ETileType)id;
                }
            }
            EditorGUILayout.EndHorizontal();
        }
        EditorGUILayout.EndVertical();
    }

    private bool CreateButton(int aX, int aY)
    {
        // Place the buttons
        m_TileRect.x = m_Rect.x + (aX * TILE_SIZE);
        m_TileRect.y = m_Rect.y + (aY * TILE_SIZE);

        // Get the right texture according to the ETileType
        Texture image = GetTileTexture(m_Target.Tiles[aX][aY]);

        return GUI.Button(m_TileRect, image);
    }

    private Texture GetTileTexture(ETileType aTileType)
    {
        Texture image;
        switch (aTileType)
        {
            case ETileType.Wall:
                {
                    image = m_WallTexture;
                    break;
                }
            case ETileType.Floor:
                {
                    image = m_FloorTexture;
                    break;
                }
            case ETileType.DestructibleWall:
                {
                    image = m_DestructibleWall;
                    break;
                }
            default:
                image = m_FloorTexture;
                break;
        }

        return image;
    }

    private void AddColumn()
    {
        TileColumn[] temp = new TileColumn[m_Width + 1];
        for (int i = 0; i < m_Width; i++)
        {
            temp[i] = m_Target.Tiles[i];
        }

        temp[m_Width] = new TileColumn(m_Height);

        m_Target.Tiles = temp;

        m_Width++;

        EditorUtility.SetDirty(target);
    }

    private void RemoveColumn()
    {
        if (m_Width <= 1)
        {
            return;
        }
        
        TileColumn[] temp = new TileColumn[m_Target.GetWidth() - 1];
        for (int i = 0; i < m_Target.GetWidth() - 1; i++)
        {
            temp[i] = m_Target.Tiles[i];
        }

        m_Target.Tiles = temp;

        m_Width--;

        EditorUtility.SetDirty(target);
    }

    private void AddRow()
    {
        for (int i = 0; i < m_Target.Tiles.Length; i++)
        {
            TileColumn temp = new TileColumn(m_Target.Tiles[i].Length + 1);
            for (int j = 0; j < m_Target.Tiles[i].Length; j++)
            {
                temp[j] = m_Target.Tiles[i][j];
            }
            m_Target.Tiles[i] = temp;
        }

        m_Height++;

        EditorUtility.SetDirty(target);
    }

    private void RemoveRow()
    {
        if (m_Height <= 1)
        {
            return;
        }

        for (int i = 0; i < m_Width; i++)
        {
            TileColumn temp = new TileColumn(m_Height - 1);

            for (int j = 0; j < m_Height - 1; j++)
            {
                temp[j] = m_Target.Tiles[i][j];
            }

            m_Target.Tiles[i] = temp;
        }

        m_Height--;

        EditorUtility.SetDirty(target);
    }
}
