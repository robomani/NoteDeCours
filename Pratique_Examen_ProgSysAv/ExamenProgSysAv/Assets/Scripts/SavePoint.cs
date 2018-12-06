using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePoint : MonoBehaviour
{
    private bool canSave;

    private void OnTriggerEnter2D(Collider2D i_Collision)
    {
        if (i_Collision.gameObject == Game.player.gameObject)
        {
            canSave = true;
        }
    }
    private void OnTriggerExit2D(Collider2D i_Collision)
    {
        if (i_Collision.gameObject == Game.player.gameObject)
        {
            canSave = false;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && canSave)
        {
            Debug.Log("Saving");
            Game.save.SaveGame();
        }
    }

}
