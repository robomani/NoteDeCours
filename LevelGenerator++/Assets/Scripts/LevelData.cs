using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/Level", fileName = "new Level", order = 1)]
public class LevelData : ScriptableObject
{
    [SerializeField] private TileColumn[] m_Tiles;

    public TileColumn[] Tiles
    {
        get { return m_Tiles;}
        set { m_Tiles = value; }
    }

    public int GetHeight()
    {
        if (m_Tiles == null || m_Tiles.Length == 0)
        {
            return 0;
        }

        return m_Tiles[0].Length;
    }

    public int GetWidth()
    {
        if (m_Tiles == null)
        {
            return 0;
        }

        return m_Tiles.Length;
    }
}

[System.Serializable]
public class TileColumn
{
    [SerializeField] private ETileType[] m_Tiles;

    public TileColumn(int aLength)
    {
        m_Tiles = new ETileType[aLength];
    }

    public ETileType this[int aY]
    {
        get { return m_Tiles[aY]; }
        set { m_Tiles[aY] = value; }
    }

    public int Length { get { return m_Tiles == null ? 0 : m_Tiles.Length; } }
}
