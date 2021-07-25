using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradesManager : MonoBehaviour
{
    // Private variables
    private int carbon_lvl = 1;
    private int iron_lvl = 1;
    private int silver_lvl = 1;
    private int gold_lvl = 1;
    private int diamond_lvl = 1;
    private Dictionary<int, ResourcesRequired> carbon_lvlup_requirements;
    private Dictionary<int, ResourcesRequired> iron_lvlup_requirements;
    private Dictionary<int, ResourcesRequired> silver_lvlup_requirements;
    private Dictionary<int, ResourcesRequired> gold_lvlup_requirements;
    private Dictionary<int, ResourcesRequired> diamond_lvlup_requirements;
    private ResourceGenerator resource_generator;
    // Public variables
    public Text UI_carbon_lvl_value;
    public Text UI_iron_lvl_value;
    public Text UI_silver_lvl_value;
    public Text UI_gold_lvl_value;
    public Text UI_diamond_lvl_value;

    // Getters
    public int GetCarbonLvl() { return carbon_lvl; }
    public int GetIronLvl() { return iron_lvl; }
    public int GetSilverLvl() { return silver_lvl; }
    public int GetGoldLvl() { return gold_lvl; }
    public int GetDiamondLvl() { return diamond_lvl; }

    // Setters
    public void SetCarbonLvl(int c) {
        if (c <= 0) { c = 1; } 
        else if (c >= 6) { c = 5; }

        carbon_lvl = c;
        resource_generator.SetCarbonGenLimiter(carbon_lvl);
        resource_generator.carbon_prob += (double)(0.75-0.30)/4; // 0.1125
        UI_carbon_lvl_value.text = carbon_lvl.ToString();
    }
    public void SetIronLvl(int i) { 
        if (i <= 0) { i = 1; } 
        else if (i >= 6) { i = 5; }

        iron_lvl = i; 
        resource_generator.SetIronGenLimiter(iron_lvl);
        resource_generator.iron_prob += (double)(0.50-0.20)/4; // 0.075
        UI_iron_lvl_value.text = iron_lvl.ToString();
    }
    public void SetSilverLvl(int s) {
        if (s <= 0) { s = 1; } 
        else if (s >= 6) { s = 5; }

        silver_lvl = s; 
        resource_generator.SetSilverGenLimiter(silver_lvl);
        resource_generator.silver_prob += (double)(0.37-0.12)/4; // 0.063
        UI_silver_lvl_value.text = silver_lvl.ToString();
    }
    public void SetGoldLvl(int g) {
        if (g <= 0) { g = 1; } 
        else if (g >= 6) { g = 5; }

        gold_lvl = g; 
        resource_generator.SetGoldGenLimiter(gold_lvl);
        resource_generator.gold_prob += (double)(0.25-0.10)/4; // 0.0376
        UI_gold_lvl_value.text = gold_lvl.ToString();
    }
    public void SetDiamondLvl(int d) {
        if (d <= 0) { d = 1; } 
        else if (d >= 6) { d = 5; }

        diamond_lvl = d; 
        resource_generator.SetDiamondGenLimiter(diamond_lvl);
        resource_generator.diamond_prob += (double)(0.12-0.05)/4; // 0.018
        UI_diamond_lvl_value.text = diamond_lvl.ToString();
    }

    // Resources required getters
    public ResourcesRequired GetResourcesRequiredCarbon() { return carbon_lvlup_requirements[carbon_lvl+1]; }
    public ResourcesRequired GetResourcesRequiredIron() { return iron_lvlup_requirements[iron_lvl+1]; }
    public ResourcesRequired GetResourcesRequiredSilver() { return silver_lvlup_requirements[silver_lvl+1]; }
    public ResourcesRequired GetResourcesRequiredGold() { return gold_lvlup_requirements[gold_lvl+1]; }
    public ResourcesRequired GetResourcesRequiredDiamond() { return diamond_lvlup_requirements[diamond_lvl+1]; }

    // Start is called before the first frame update
    void Start()
    {
        resource_generator = gameObject.GetComponent<ResourceGenerator>();

        carbon_lvlup_requirements = new Dictionary<int, ResourcesRequired>()
        {
            {2 , new ResourcesRequired {
                carbon = 25,
                iron = 15,
                silver = 5,
                gold = 0,
                diamond = 0
            }},
            {3 , new ResourcesRequired {
                carbon = 75,
                iron = 60,
                silver = 40,
                gold = 0,
                diamond = 0
            }},
            {4 , new ResourcesRequired {
                carbon = 160,
                iron = 110,
                silver = 80,
                gold = 20,
                diamond = 0
            }},
            {5 , new ResourcesRequired {
                carbon = 250,
                iron = 190,
                silver = 150,
                gold = 40,
                diamond = 5
            }}
        };

        iron_lvlup_requirements = new Dictionary<int, ResourcesRequired>()
        {
            {2 , new ResourcesRequired {
                carbon = 50,
                iron = 30,
                silver = 10,
                gold = 0,
                diamond = 0
            }},
            {3 , new ResourcesRequired {
                carbon = 150,
                iron = 130,
                silver = 110,
                gold = 0,
                diamond = 0
            }},
            {4 , new ResourcesRequired {
                carbon = 250,
                iron = 230,
                silver = 210,
                gold = 40,
                diamond = 0
            }},
            {5 , new ResourcesRequired {
                carbon = 350,
                iron = 330,
                silver = 310,
                gold = 70,
                diamond = 30
            }}
        };
    }

    // Object that contains the resources required to upgrade something
    public class ResourcesRequired {
        public int carbon;
        public int iron;
        public int silver;
        public int gold;
        public int diamond;
    }
}
