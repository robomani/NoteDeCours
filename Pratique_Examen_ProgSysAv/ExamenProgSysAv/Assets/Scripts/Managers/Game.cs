using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    public static MapManager map { get; private set; }
    public static UserInterface ui { get; private set; }
    public static PlayerController player { get; private set; }
    public static CameraController camera { get; private set; }
    public static InputManager input { get; private set; }
    public static SaveManager save { get; private set; }
    public static InventoryManager inventory { get; private set; }

    public static bool IsDestroyed => map == null;

    private void Awake()
    {
        JsonConvert.DefaultSettings = () => new JsonSerializerSettings
        {
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
        };

        map = FindObjectOfType<MapManager>();
        ui = FindObjectOfType<UserInterface>();
        player = FindObjectOfType<PlayerController>();
        camera = FindObjectOfType<CameraController>();
        input = FindObjectOfType<InputManager>();
        save = FindObjectOfType<SaveManager>();
        inventory = FindObjectOfType<InventoryManager>();
    }

    // Use this for initialization
    void Start ()
    {
        bool loadSuccess = save.LoadGame();
        if (!loadSuccess)
        {
            map.LoadScene("map_Forest", "default");
        }
	}
}
