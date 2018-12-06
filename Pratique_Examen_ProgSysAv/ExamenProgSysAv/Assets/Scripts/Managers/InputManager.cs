using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public enum InputMode
    {
        DISABLED = 0,
        MOVE_PLAYER,
        MENU,
        DIALOG,
        BATTLE
    }

    private PlayerController playerController;
    private InputMode mode = InputMode.MOVE_PLAYER;

    private void Awake()
    {
        playerController = FindObjectOfType<PlayerController>();
    }

    public void SetMode(InputMode mode)
    {
        this.mode = mode;
    }

	// Update is called once per frame
	void Update ()
    {
        float inputX = Input.GetAxisRaw("Horizontal");
        float inputY = Input.GetAxisRaw("Vertical");
        bool btnAccept = Input.GetButtonDown("Fire1");
        bool btnCancel = Input.GetKeyDown(KeyCode.Escape);

        switch (mode)
        {
            case InputMode.MOVE_PLAYER:
                {
                    playerController.Move(new Vector2(inputX, inputY));
                }
                break;
            case InputMode.BATTLE:
                {
                }
                break;
        }
    }
}
