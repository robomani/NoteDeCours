using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour
{
    private void Start()
    {
        LevelManager.Instance.ChangeLevel("Gameplay", 3);
    }
}
