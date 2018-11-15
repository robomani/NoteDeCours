using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
	public void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1))
        {
            CubeManager.Instance.SelectCube(CubeID.CubeColor.Red);
        }
        else if (Input.GetKeyUp(KeyCode.Alpha1) || Input.GetKeyUp(KeyCode.Keypad1))
        {
            CubeManager.Instance.UnSelectCube(CubeID.CubeColor.Red);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2))
        {
            CubeManager.Instance.SelectCube(CubeID.CubeColor.Green);
        }
        else if (Input.GetKeyUp(KeyCode.Alpha2) || Input.GetKeyUp(KeyCode.Keypad2))
        {
            CubeManager.Instance.UnSelectCube(CubeID.CubeColor.Green);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad3))
        {
            CubeManager.Instance.SelectCube(CubeID.CubeColor.Blue);
        }
        else if (Input.GetKeyUp(KeyCode.Alpha3) || Input.GetKeyUp(KeyCode.Keypad3))
        {
            CubeManager.Instance.UnSelectCube(CubeID.CubeColor.Blue);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            CubeManager.Instance.ShuffleCubes(1);
        }
    }
}
