using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeManager : MonoBehaviour
{
    private Dictionary<CubeID.CubeColor, TestCube> m_Cubes = new Dictionary<CubeID.CubeColor, TestCube>();

    private List<Vector3> m_Postition = new List<Vector3>();

    private static CubeManager m_Instance;
    public static CubeManager Instance
    {
        get { return m_Instance; }
    }

    private void Awake()
    {
        if (m_Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            m_Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void ShuffleCubes(int i_Passes = 1)
    {
        for (int i = 0; i < i_Passes; i++)
        {
            int posR, posG, posB;
            //Red
            do
            {
                posR = Random.Range(0, m_Cubes.Count);
                //Green
                do
                {
                    posG = Random.Range(0, m_Cubes.Count);
                } while (posG == posR);
                //Blue
                do
                {
                    posB = Random.Range(0, m_Cubes.Count);
                } while (posB == posR || posB == posG);
            } while (m_Cubes[CubeID.CubeColor.Red].transform.position == m_Postition[posR] 
            && m_Cubes[CubeID.CubeColor.Green].transform.position == m_Postition[posG] 
            && m_Cubes[CubeID.CubeColor.Blue].transform.position == m_Postition[posB]);


            m_Cubes[CubeID.CubeColor.Red].MoveCube(m_Postition[posR]);
            m_Cubes[CubeID.CubeColor.Green].MoveCube(m_Postition[posG]);
            m_Cubes[CubeID.CubeColor.Blue].MoveCube(m_Postition[posB]);
        }
    }

    public void SelectCube(CubeID.CubeColor i_Cube)
    {
        m_Cubes[i_Cube].SelectCube();
    }

    public void UnSelectCube(CubeID.CubeColor i_Cube)
    {
        m_Cubes[i_Cube].UnselectCube();
    }

    public void AddCubeToManager(CubeID.CubeColor i_Color, TestCube i_Cube)
    {
        m_Cubes.Add(i_Color,i_Cube);
        m_Postition.Add(i_Cube.gameObject.transform.position);
    }
}
