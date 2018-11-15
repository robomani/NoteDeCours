using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCube : MonoBehaviour
{
    public CubeID.CubeColor m_Color;

    public void Start()
    {
        CubeManager.Instance.AddCubeToManager(m_Color, GetComponent<TestCube>());
    }

    public void SelectCube()
    {
        transform.localScale = new Vector3(2, 2, 2);
    }

    public void UnselectCube()
    {
        transform.localScale = new Vector3(1, 1, 1);
    }

    public void MoveCube(Vector3 i_EndPos, float i_MoveTime = 1.0f)
    {
        StartCoroutine(GoToPosition(i_EndPos, i_MoveTime));
    }

    private IEnumerator GoToPosition(Vector3 i_EndPos, float i_MoveTime = 1.0f)
    {
        Vector3 startPos = transform.position;
        float currentTime = 0f;

        yield return new WaitForSeconds(0.2f);
        float value = 0.0f;

        while (currentTime != i_MoveTime)
        {
            currentTime += Time.deltaTime;
            if (currentTime > i_MoveTime)
            {
                currentTime = i_MoveTime;
            }

            value = currentTime / i_MoveTime;
            transform.position = Vector3.Lerp(startPos, i_EndPos, value);
            yield return new WaitForEndOfFrame();
        }      
    }
}
