using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance { get; private set; }
    private const string SAVE_FILE = "SaveGame.json";

    public GameData CurrentGameData { get; private set; }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        CurrentGameData = new GameData();
    }

    public void Save()
    {
        EventManager.Instance.DispatchEvent(EventID.SaveGame);
        string path = GetPath(SAVE_FILE);
        File.WriteAllText(path, JsonUtility.ToJson(CurrentGameData));

        
    }

    public void Load()
    {
        string path = GetPath(SAVE_FILE);
        if (!File.Exists(path))
        {
            return;
        }

        string gameData = File.ReadAllText(path);
        CurrentGameData = JsonUtility.FromJson<GameData>(gameData);
        EventManager.Instance.DispatchEvent(EventID.LoadeGame);
    }

    private string GetPath(string i_SaveFile)
    {
        return Path.Combine(Application.persistentDataPath, i_SaveFile);
    }
}
