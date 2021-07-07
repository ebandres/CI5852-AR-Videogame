using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{   
    private int currency = 0;
    private int express_currency = 0;
    private static string SAVE_FOLDER;

    // Getters
    public int GetCurrency() { return currency; }
    public int GetExpressCurrency() { return express_currency; }

    // Awake is called when the script instance is being loaded.
    void Awake()
    {   
        // We check if Saves folder exists, if not then it gets created
        SAVE_FOLDER = Application.dataPath + "/Saves/";
        if (!Directory.Exists(SAVE_FOLDER)) {
            Directory.CreateDirectory(SAVE_FOLDER);
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S)) {
            Save();
        }
        if (Input.GetKeyDown(KeyCode.L)) {
            Load();
        }
    }

    // Function used to save the game state
    void Save() {
        //Create SaveObject with game state data
        SaveObject save_object = new SaveObject {
            currency = currency,
            express_currency = express_currency
        };
        // From SaveObject to Json
        string json = JsonUtility.ToJson(save_object);
        // Write to Json File
        File.WriteAllText(SAVE_FOLDER + "save.json", json);
    }

    // Function used to load the game state
    void Load() {

        if (File.Exists(SAVE_FOLDER + "save.json")) {
            // Read from Json file
            string save_str = File.ReadAllText(SAVE_FOLDER + "save.json");
            // From Json to SaveObject
            SaveObject save_object = JsonUtility.FromJson<SaveObject>(save_str);
            // Set game state
            currency = save_object.currency;
            express_currency = save_object.express_currency;
        }
    }

    // Object that contains saved/loaded data
    private class SaveObject {
        public int currency;
        public int express_currency;
    }
}
