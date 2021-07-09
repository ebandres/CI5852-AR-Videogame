using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{   
    // Private variables
    private int carbon = 0;
    private int iron = 0;
    private int silver = 0;
    private int gold = 0;
    private int diamond = 0;
    private static string SAVE_FOLDER;
    // Public variables
    public float save_every_mins = 1;

    // Getters
    public int GetCarbon() { return carbon; }
    public int GetIron() { return iron; }
    public int GetSilver() { return silver; }
    public int GetGold() { return gold; }
    public int GetDiamond() { return diamond; }

    // Setters
    public void SetCarbon(int c) { carbon = c; }
    public void SetIron(int i) { iron = i; }
    public void SetSilver(int s) { silver = s; }
    public void SetGold(int g) { gold = g; }
    public void SetDiamond(int d) { diamond = d; }

    // Awake is called when the script instance is being loaded.
    void Awake()
    {   
        // We check if Saves folder exists, if not then it gets created
        SAVE_FOLDER = Application.dataPath + "/Saves/";
        if (!Directory.Exists(SAVE_FOLDER)) {
            Directory.CreateDirectory(SAVE_FOLDER);
        }
    }

    void Start() 
    {
        Load();
        StartCoroutine("SaveCoroutine", save_every_mins);
    }

    IEnumerator SaveCoroutine(float wait_time) {
        while(true){
            Save();
            Debug.Log("Saved");
            yield return new WaitForSeconds(wait_time*60);
        }
    }

    // Function used to save the game state
    void Save() {
        //Create SaveObject with game state data
        SaveObject save_object = new SaveObject {
            carbon = carbon,
            iron = iron,
            silver = silver,
            gold = gold,
            diamond = diamond
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
            carbon = save_object.carbon;
            iron = save_object.iron;
            silver = save_object.silver;
            gold = save_object.gold;
            diamond = save_object.diamond;
        }
    }

    // Object that contains saved/loaded data
    private class SaveObject {
        public int carbon;
        public int iron;
        public int silver;
        public int gold;
        public int diamond;
    }
}
