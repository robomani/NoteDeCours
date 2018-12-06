using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.Events;

public class MapManager : MonoBehaviour
{
    public string CurrentMap { get; private set; }

    private string lastRegisteredMap;
    private Vector3 lastRegisteredPosition;

    public void LoadScene(string sceneName, Action placeCharacter)
    {
        CurrentMap = sceneName;
        Action onFadeInComplete = null;
        onFadeInComplete = delegate
        {
            Game.ui.fader.onFadeComplete -= onFadeInComplete;

            SceneManager.LoadScene(sceneName);
        };
        /*
        Action onFadeOutComplete = null;
        onFadeOutComplete = delegate
        {
            ui.fader.onFadeComplete -= onFadeOutComplete;

            input.SetMode(InputManager.InputMode.MOVE_PLAYER);
        };*/

        UnityAction<Scene, LoadSceneMode> onSceneLoaded = null;
        onSceneLoaded = delegate (Scene scene, LoadSceneMode mode)
        {
            SceneManager.sceneLoaded -= onSceneLoaded;

            Game.player.SetAnimIdle();
            Game.input.SetMode(InputManager.InputMode.MOVE_PLAYER);

            if (placeCharacter != null)
            {
                placeCharacter();
            }
            
            //ui.fader.onFadeComplete += onFadeOutComplete;
            Game.ui.fader.StartFadeOut();
        };

        Game.input.SetMode(InputManager.InputMode.DISABLED);
        Game.ui.fader.onFadeComplete += onFadeInComplete;
        Game.ui.fader.StartFadeIn();
        SceneManager.sceneLoaded += onSceneLoaded;
    }

    public void LoadScene(string sceneName, Vector3 position)
    {
        LoadScene(sceneName, () => { Game.player.transform.position = position; });
    }

    public void LoadScene(string sceneName, string spawnPoint)
    {
        LoadScene(sceneName, () =>
        {
            var point = SpawnPoint.FindOrDefault(spawnPoint);
            Game.player.transform.position = point.transform.position;
            Game.player.Move(point.m_PlayerDirection.normalized*0.001f);
        });
    }

    public void RegisterCurrentPosition()
    {
        lastRegisteredMap = CurrentMap;
        lastRegisteredPosition = Game.player.transform.position;
    }

    public void RestoreLastPosition()
    {
        LoadScene(lastRegisteredMap, lastRegisteredPosition);
    }
}
