using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    private static LevelGenerator m_Instance;
    public static LevelGenerator Instance
    {
        get { return m_Instance; }
    }

    private const float PIXEL_PER_UNIT = 100;
    private const float TILE_SIZE = 64;

    public GameObject[] m_FloorPrefabList;
    public GameObject[] m_WallPrefabList;
    public GameObject[] m_DestructibleWallPrefabList;

    public LevelData m_LevelData;

    public PlayerMovement m_PlayerPrefab;
        
    private void Awake()
    {
        m_Instance = this;

        float x = (-Screen.width + TILE_SIZE) / PIXEL_PER_UNIT / 2.0f;
        float y = (Screen.height - TILE_SIZE) / PIXEL_PER_UNIT / 2.0f;
        Vector2 initialPos = new Vector2(x, y);
        /*
        int width = (int)(Screen.width / TILE_SIZE);
        int height = (int)(Screen.height / TILE_SIZE);
        */
        Vector2 offset = new Vector2(TILE_SIZE / PIXEL_PER_UNIT, -TILE_SIZE / PIXEL_PER_UNIT);
        Vector2 spawnPos = initialPos + offset;
        PlayerMovement player = Instantiate(m_PlayerPrefab, spawnPos, Quaternion.identity);
        player.Setup(1, 1);

        for (int i = 0; i < m_LevelData.GetWidth(); ++i)
        {
            for (int j = 0; j < m_LevelData.GetHeight(); ++j)
            {
                offset = new Vector2(TILE_SIZE * i / PIXEL_PER_UNIT, -TILE_SIZE * j / PIXEL_PER_UNIT);
                spawnPos = initialPos + offset;

                CreateTile(m_LevelData.Tiles[i][j], spawnPos);
            }
        }
    }

    private void CreateTile(ETileType aType, Vector2 aPos)
    {
        switch (aType)
        {
            case ETileType.Floor:
                {
                    GameObject floor = Instantiate(m_FloorPrefabList[Random.Range(0, m_FloorPrefabList.Length)]);
                    floor.transform.position = aPos;
                    break;
                }
            case ETileType.Wall:
                {
                    GameObject wall = Instantiate(m_WallPrefabList[Random.Range(0, m_WallPrefabList.Length)]);
                    wall.transform.position = aPos;
                    break;
                }
                
        }
    }

    public ETileType GetTileTypeAtPos(int aRow, int aCol)
    {
        if (aRow < m_LevelData.GetWidth() && aRow >= 0
            && aCol < m_LevelData.GetHeight() && aCol >= 0)
        {
            return (ETileType)m_LevelData.Tiles[aCol][aRow];
            
        }
        return ETileType.Wall;
    }

    public Vector3 GetPositionAt(int aRow, int aCol)
    {
        float x = (-Screen.width + TILE_SIZE) / PIXEL_PER_UNIT / 2.0f;
        float y = (Screen.height - TILE_SIZE) / PIXEL_PER_UNIT / 2.0f;
        Vector2 initialPos = new Vector2(x, y);

        Vector2 offset = new Vector2(TILE_SIZE * aCol / PIXEL_PER_UNIT, -TILE_SIZE * aRow / PIXEL_PER_UNIT);
        Vector2 pos = initialPos + offset;

        return pos;
    }
}
