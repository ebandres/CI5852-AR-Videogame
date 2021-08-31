using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveHandler : MonoBehaviour
{   
    // Public variables
    public float save_every_second = 5;
    public GameObject planet1;
    public GameObject planet2;
    // Private variables
    private ResourcesGatheredManager resources_gathered_manager;
    private HumanityManager humanity_manager_planet1;
    private HumanityManager humanity_manager_planet2;
    private UpgradesManager upgrade_manager_planet1;
    private UpgradesManager upgrade_manager_planet2;
    private DisasterGenerator disaster_generator_planet1;
    private DisasterGenerator disaster_generator_planet2;
    private ResourceGenerator resource_generator_planet1;
    private ResourceGenerator resource_generator_planet2;

    // Start is called before the first frame update
    void Start() 
    {
        resources_gathered_manager = gameObject.GetComponent<ResourcesGatheredManager>();
        humanity_manager_planet1 = planet1.GetComponent<HumanityManager>();
        humanity_manager_planet2 = planet2.GetComponent<HumanityManager>();
        upgrade_manager_planet1 = planet1.GetComponent<UpgradesManager>();
        upgrade_manager_planet2 = planet2.GetComponent<UpgradesManager>();
        disaster_generator_planet1 = planet1.GetComponent<DisasterGenerator>();
        disaster_generator_planet2 = planet2.GetComponent<DisasterGenerator>();
        resource_generator_planet1 = planet1.GetComponent<ResourceGenerator>();
        resource_generator_planet2 = planet2.GetComponent<ResourceGenerator>();
        Load();
        StartCoroutine("SaveCoroutine", save_every_second);
    }

    IEnumerator SaveCoroutine(float wait_time) {
        while(true){
            yield return new WaitForSeconds(wait_time);
            Save();
            Debug.Log("Saved");
        }
    }

    // Function used to save the game state
    public void Save() {
        //Create SaveObject with game state data
        SaveObject save_object = new SaveObject {
            carbon = resources_gathered_manager.GetCarbon(),
            iron = resources_gathered_manager.GetIron(),
            silver = resources_gathered_manager.GetSilver(),
            gold = resources_gathered_manager.GetGold(),
            diamond = resources_gathered_manager.GetDiamond(),
            humans_planet_1 = humanity_manager_planet1.GetHumanity(),
            humans_limit_planet_1 = humanity_manager_planet1.GetHumanityLimit(),
            humans_planet_2 = humanity_manager_planet1.GetHumanity(),
            humans_limit_planet_2 = humanity_manager_planet2.GetHumanityLimit(),
            regular_disaster_count_planet1 = disaster_generator_planet1.GetRegularCounter(),
            regular_disaster_count_planet2 = disaster_generator_planet2.GetRegularCounter(),
            planet1_carbon_lvl = upgrade_manager_planet1.GetCarbonLvl(),
            planet1_iron_lvl = upgrade_manager_planet1.GetIronLvl(),
            planet1_silver_lvl = upgrade_manager_planet1.GetSilverLvl(),
            planet1_gold_lvl = upgrade_manager_planet1.GetGoldLvl(),
            planet1_diamond_lvl = upgrade_manager_planet1.GetDiamondLvl(),
            planet1_upgrade1_lvl = upgrade_manager_planet1.GetUpgrade1Lvl(),
            planet1_upgrade2_lvl = upgrade_manager_planet1.GetUpgrade2Lvl(),
            planet1_upgrade3_lvl = upgrade_manager_planet1.GetUpgrade3Lvl(),
            planet1_upgrade4_lvl = upgrade_manager_planet1.GetUpgrade4Lvl(),
            planet1_upgrade5_lvl = upgrade_manager_planet1.GetUpgrade5Lvl(),
            planet1_upgrade6_lvl = upgrade_manager_planet1.GetUpgrade6Lvl(),
            planet2_carbon_lvl = upgrade_manager_planet2.GetCarbonLvl(),
            planet2_iron_lvl = upgrade_manager_planet2.GetIronLvl(),
            planet2_silver_lvl = upgrade_manager_planet2.GetSilverLvl(),
            planet2_gold_lvl = upgrade_manager_planet2.GetGoldLvl(),
            planet2_diamond_lvl = upgrade_manager_planet2.GetDiamondLvl(),
            planet2_upgrade1_lvl = upgrade_manager_planet2.GetUpgrade1Lvl(),
            planet2_upgrade2_lvl = upgrade_manager_planet2.GetUpgrade2Lvl(),
            planet2_upgrade3_lvl = upgrade_manager_planet2.GetUpgrade3Lvl(),
            planet2_upgrade4_lvl = upgrade_manager_planet2.GetUpgrade4Lvl(),
            planet2_upgrade5_lvl = upgrade_manager_planet2.GetUpgrade5Lvl(),
            planet2_upgrade6_lvl = upgrade_manager_planet2.GetUpgrade6Lvl(),
            carbon_stored_planet1 = resource_generator_planet1.GetCarbonStored(),
            iron_stored_planet1 = resource_generator_planet1.GetIronStored(),
            silver_stored_planet1 = resource_generator_planet1.GetSilverStored(),
            gold_stored_planet1 = resource_generator_planet1.GetGoldStored(),
            diamond_stored_planet1 = resource_generator_planet1.GetDiamondStored(),
            carbon_stored_planet2 = resource_generator_planet2.GetCarbonStored(),
            iron_stored_planet2 = resource_generator_planet2.GetIronStored(),
            silver_stored_planet2 = resource_generator_planet2.GetSilverStored(),
            gold_stored_planet2 = resource_generator_planet2.GetGoldStored(),
            diamond_stored_planet2 = resource_generator_planet2.GetDiamondStored()

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
            resources_gathered_manager.SetCarbon(save_object.carbon);
            resources_gathered_manager.SetIron(save_object.iron);
            resources_gathered_manager.SetSilver(save_object.silver);
            resources_gathered_manager.SetGold(save_object.gold);
            resources_gathered_manager.SetDiamond(save_object.diamond);
            humanity_manager_planet1.SetHumanity(save_object.humans_planet_1);
            humanity_manager_planet1.SetHumanityLimit(save_object.humans_limit_planet_1);
            humanity_manager_planet2.SetHumanity(save_object.humans_planet_2);
            humanity_manager_planet2.SetHumanityLimit(save_object.humans_limit_planet_2);
            disaster_generator_planet1.SetRegularCounter(save_object.regular_disaster_count_planet1);
            disaster_generator_planet2.SetRegularCounter(save_object.regular_disaster_count_planet2);
            upgrade_manager_planet1.SetCarbonLvl(save_object.planet1_carbon_lvl);
            upgrade_manager_planet1.SetIronLvl(save_object.planet1_iron_lvl);
            upgrade_manager_planet1.SetSilverLvl(save_object.planet1_silver_lvl);
            upgrade_manager_planet1.SetGoldLvl(save_object.planet1_gold_lvl);
            upgrade_manager_planet1.SetDiamondLvl(save_object.planet1_diamond_lvl);
            upgrade_manager_planet1.SetUpgrade1Lvl(save_object.planet1_upgrade1_lvl);
            upgrade_manager_planet1.SetUpgrade2Lvl(save_object.planet1_upgrade2_lvl);
            upgrade_manager_planet1.SetUpgrade3Lvl(save_object.planet1_upgrade3_lvl);
            upgrade_manager_planet1.SetUpgrade4Lvl(save_object.planet1_upgrade4_lvl);
            upgrade_manager_planet1.SetUpgrade5Lvl(save_object.planet1_upgrade5_lvl);
            upgrade_manager_planet1.SetUpgrade6Lvl(save_object.planet1_upgrade6_lvl);
            upgrade_manager_planet2.SetCarbonLvl(save_object.planet2_carbon_lvl);
            upgrade_manager_planet2.SetIronLvl(save_object.planet2_iron_lvl);
            upgrade_manager_planet2.SetSilverLvl(save_object.planet2_silver_lvl);
            upgrade_manager_planet2.SetGoldLvl(save_object.planet2_gold_lvl);
            upgrade_manager_planet2.SetDiamondLvl(save_object.planet2_diamond_lvl);
            upgrade_manager_planet2.SetUpgrade1Lvl(save_object.planet2_upgrade1_lvl);
            upgrade_manager_planet2.SetUpgrade2Lvl(save_object.planet2_upgrade2_lvl);
            upgrade_manager_planet2.SetUpgrade3Lvl(save_object.planet2_upgrade3_lvl);
            upgrade_manager_planet2.SetUpgrade4Lvl(save_object.planet2_upgrade4_lvl);
            upgrade_manager_planet2.SetUpgrade5Lvl(save_object.planet2_upgrade5_lvl);
            upgrade_manager_planet2.SetUpgrade6Lvl(save_object.planet2_upgrade6_lvl);
            resource_generator_planet1.SetCarbonStored(save_object.carbon_stored_planet1);
            resource_generator_planet1.SetIronStored(save_object.iron_stored_planet1);
            resource_generator_planet1.SetSilverStored(save_object.silver_stored_planet1);
            resource_generator_planet1.SetGoldStored(save_object.gold_stored_planet1);
            resource_generator_planet1.SetDiamondStored(save_object.diamond_stored_planet1);
            resource_generator_planet2.SetCarbonStored(save_object.carbon_stored_planet2);
            resource_generator_planet2.SetIronStored(save_object.iron_stored_planet2);
            resource_generator_planet2.SetSilverStored(save_object.silver_stored_planet2);
            resource_generator_planet2.SetGoldStored(save_object.gold_stored_planet2);
            resource_generator_planet2.SetDiamondStored(save_object.diamond_stored_planet2);
        }
    }

    // Object that contains saved/loaded data
    private class SaveObject {
        public int carbon;
        public int iron;
        public int silver;
        public int gold;
        public int diamond;
        public ulong humans_planet_1;
        public ulong humans_limit_planet_1;
        public ulong humans_planet_2;
        public ulong humans_limit_planet_2;
        public int regular_disaster_count_planet1;
        public int regular_disaster_count_planet2;
        public int planet1_carbon_lvl;
        public int planet1_iron_lvl;
        public int planet1_silver_lvl;
        public int planet1_gold_lvl;
        public int planet1_diamond_lvl;
        public int planet1_upgrade1_lvl;
        public int planet1_upgrade2_lvl;
        public int planet1_upgrade3_lvl;
        public int planet1_upgrade4_lvl;
        public int planet1_upgrade5_lvl;
        public int planet1_upgrade6_lvl;
        public int planet2_carbon_lvl;
        public int planet2_iron_lvl;
        public int planet2_silver_lvl;
        public int planet2_gold_lvl;
        public int planet2_diamond_lvl;
        public int planet2_upgrade1_lvl;
        public int planet2_upgrade2_lvl;
        public int planet2_upgrade3_lvl;
        public int planet2_upgrade4_lvl;
        public int planet2_upgrade5_lvl;
        public int planet2_upgrade6_lvl;
        public int carbon_stored_planet1;
        public int iron_stored_planet1;
        public int silver_stored_planet1;
        public int gold_stored_planet1;
        public int diamond_stored_planet1;
        public int carbon_stored_planet2;
        public int iron_stored_planet2;
        public int silver_stored_planet2;
        public int gold_stored_planet2;
        public int diamond_stored_planet2;
    }
}
