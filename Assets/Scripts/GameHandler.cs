using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameHandler : MonoBehaviour
{   
    // Public variables
    public float save_every_mins = 1;
    public Text UI_carbon_value;
    public Text UI_iron_value;
    public Text UI_silver_value;
    public Text UI_gold_value;
    public Text UI_diamond_value;
    // Private variables
    private int carbon = 0;
    private int iron = 0;
    private int silver = 0;
    private int gold = 0;
    private int diamond = 0;

    // Getters
    public int GetCarbon() { return carbon; }
    public int GetIron() { return iron; }
    public int GetSilver() { return silver; }
    public int GetGold() { return gold; }
    public int GetDiamond() { return diamond; }

    // Setters
    public void SetCarbon(int c) { carbon = c; UI_carbon_value.text = carbon.ToString(); }
    public void SetIron(int i) { iron = i; UI_iron_value.text = iron.ToString(); }
    public void SetSilver(int s) { silver = s; UI_silver_value.text = silver.ToString(); }
    public void SetGold(int g) { gold = g; UI_gold_value.text = gold.ToString(); }
    public void SetDiamond(int d) { diamond = d; UI_diamond_value.text = diamond.ToString(); }

    // Start is called before the first frame update
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
        File.WriteAllText(Application.persistentDataPath + "/save.json", json);
    }

    // Function used to load the game state
    void Load() {

        if (File.Exists(Application.persistentDataPath + "/save.json")) {
            // Read from Json file
            string save_str = File.ReadAllText(Application.persistentDataPath + "/save.json");
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
