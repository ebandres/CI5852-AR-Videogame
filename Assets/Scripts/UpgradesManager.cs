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
    private int upgrade1_lvl = 1;
    private int upgrade2_lvl = 1;
    private int upgrade3_lvl = 1;
    private int upgrade4_lvl = 1;
    private int upgrade5_lvl = 1;
    private int upgrade6_lvl = 1;
    private Dictionary<int, ResourcesRequired> carbon_lvlup_requirements;
    private Dictionary<int, ResourcesRequired> iron_lvlup_requirements;
    private Dictionary<int, ResourcesRequired> silver_lvlup_requirements;
    private Dictionary<int, ResourcesRequired> gold_lvlup_requirements;
    private Dictionary<int, ResourcesRequired> diamond_lvlup_requirements;
    private Dictionary<int, ResourcesRequired> upgrade1_lvlup_requirements;
    private Dictionary<int, ResourcesRequired> upgrade2_lvlup_requirements;
    private Dictionary<int, ResourcesRequired> upgrade3_lvlup_requirements;
    private Dictionary<int, ResourcesRequired> upgrade4_lvlup_requirements;
    private Dictionary<int, ResourcesRequired> upgrade5_lvlup_requirements;
    private Dictionary<int, ResourcesRequired> upgrade6_lvlup_requirements;
    [SerializeField]
    private ResourceGenerator resource_generator;
    [SerializeField]
    private HumanityManager humanity_manager;
    // Public variables
    public Text UI_carbon_lvl_value;
    public Text UI_iron_lvl_value;
    public Text UI_silver_lvl_value;
    public Text UI_gold_lvl_value;
    public Text UI_diamond_lvl_value;
    public Text UI_upgrade1_lvl_value;
    public Text UI_upgrade2_lvl_value;
    public Text UI_upgrade3_lvl_value;
    public Text UI_upgrade4_lvl_value;
    public Text UI_upgrade5_lvl_value;
    public Text UI_upgrade6_lvl_value;

    // Getters
    public int GetCarbonLvl() { return carbon_lvl; }
    public int GetIronLvl() { return iron_lvl; }
    public int GetSilverLvl() { return silver_lvl; }
    public int GetGoldLvl() { return gold_lvl; }
    public int GetDiamondLvl() { return diamond_lvl; }
    public int GetUpgrade1Lvl() { return upgrade1_lvl; }
    public int GetUpgrade2Lvl() { return upgrade2_lvl; }
    public int GetUpgrade3Lvl() { return upgrade3_lvl; }
    public int GetUpgrade4Lvl() { return upgrade4_lvl; }
    public int GetUpgrade5Lvl() { return upgrade5_lvl; }
    public int GetUpgrade6Lvl() { return upgrade6_lvl; }

    // Setters
    public void SetCarbonLvl(int c) {
        if (c <= 0) { c = 1; } 
        else if (c >= 6) { c = 5; }

        if ( c != carbon_lvl ) { resource_generator.carbon_prob += (c - carbon_lvl) * (double)(0.75-0.30)/4; } // 0.1125
        resource_generator.SetCarbonGenLimiter(c);
        UI_carbon_lvl_value.text = c.ToString();
        carbon_lvl = c;
    }
    public void SetIronLvl(int i) { 
        if (i <= 0) { i = 1; } 
        else if (i >= 6) { i = 5; }

        if ( i != iron_lvl ) { resource_generator.iron_prob += (i - iron_lvl) * (double)(0.50-0.20)/4; } // 0.075
        resource_generator.SetIronGenLimiter(i);
        UI_iron_lvl_value.text = i.ToString();
        iron_lvl = i; 
    }
    public void SetSilverLvl(int s) {
        if (s <= 0) { s = 1; } 
        else if (s >= 6) { s = 5; }

        if ( s != silver_lvl ) { resource_generator.silver_prob += (s - silver_lvl) * (double)(0.37-0.12)/4; } // 0.063
        resource_generator.SetSilverGenLimiter(s);
        UI_silver_lvl_value.text = s.ToString();
        silver_lvl = s; 
    }
    public void SetGoldLvl(int g) {
        if (g <= 0) { g = 1; } 
        else if (g >= 6) { g = 5; }

        if ( g != gold_lvl ) { resource_generator.gold_prob += (g - gold_lvl) * (double)(0.25-0.10)/4; } // 0.0376
        resource_generator.SetGoldGenLimiter(g);
        UI_gold_lvl_value.text = g.ToString();
        gold_lvl = g;
    }
    public void SetDiamondLvl(int d) {
        if (d <= 0) { d = 1; } 
        else if (d >= 6) { d = 5; }

        if ( d != diamond_lvl ) { resource_generator.diamond_prob += (d - diamond_lvl) * (double)(0.12-0.05)/4; } // 0.018
        resource_generator.SetDiamondGenLimiter(d);
        UI_diamond_lvl_value.text = d.ToString();
        diamond_lvl = d; 
    }
    public void SetUpgrade1Lvl(int up1) {
        if (up1 <= 0) { up1 = 1; } 
        else if (up1 >= 6) { up1 = 5; }

        upgrade1_lvl = up1;
        switch(upgrade1_lvl){
            case 1: humanity_manager.SetHumanityLimit( humanity_manager.GetHumanityLimit() + 166 ); break;
            case 2: humanity_manager.SetHumanityLimit( humanity_manager.GetHumanityLimit() + 116666666 ); break;
            case 3: humanity_manager.SetHumanityLimit( humanity_manager.GetHumanityLimit() + 233333332 ); break;
            case 4: humanity_manager.SetHumanityLimit( humanity_manager.GetHumanityLimit() + 349999998 ); break;
            case 5: humanity_manager.SetHumanityLimit( humanity_manager.GetHumanityLimit() + 466666664 ); break;
        }
        UI_upgrade1_lvl_value.text = upgrade1_lvl.ToString();
    }
    public void SetUpgrade2Lvl(int up2) {
        if (up2 <= 0) { up2 = 1; } 
        else if (up2 >= 6) { up2 = 5; }

        upgrade2_lvl = up2;
        switch(upgrade2_lvl){
            case 1: humanity_manager.SetHumanityLimit( humanity_manager.GetHumanityLimit() + 166 ); break;
            case 2: humanity_manager.SetHumanityLimit( humanity_manager.GetHumanityLimit() + 116666666 ); break;
            case 3: humanity_manager.SetHumanityLimit( humanity_manager.GetHumanityLimit() + 233333332 ); break;
            case 4: humanity_manager.SetHumanityLimit( humanity_manager.GetHumanityLimit() + 349999998 ); break;
            case 5: humanity_manager.SetHumanityLimit( humanity_manager.GetHumanityLimit() + 466666664 ); break;
        }
        UI_upgrade2_lvl_value.text = upgrade2_lvl.ToString();
    }
    public void SetUpgrade3Lvl(int up3) {
        if (up3 <= 0) { up3 = 1; } 
        else if (up3 >= 6) { up3 = 5; }

        upgrade3_lvl = up3;
        switch(upgrade3_lvl){
            case 1: humanity_manager.SetHumanityLimit( humanity_manager.GetHumanityLimit() + 166 ); break;
            case 2: humanity_manager.SetHumanityLimit( humanity_manager.GetHumanityLimit() + 116666666 ); break;
            case 3: humanity_manager.SetHumanityLimit( humanity_manager.GetHumanityLimit() + 233333332 ); break;
            case 4: humanity_manager.SetHumanityLimit( humanity_manager.GetHumanityLimit() + 349999998 ); break;
            case 5: humanity_manager.SetHumanityLimit( humanity_manager.GetHumanityLimit() + 466666664 ); break;
        }
        UI_upgrade3_lvl_value.text = upgrade3_lvl.ToString();
    }
    public void SetUpgrade4Lvl(int up4) {
        if (up4 <= 0) { up4 = 1; } 
        else if (up4 >= 6) { up4 = 5; }

        upgrade4_lvl = up4;
        switch(upgrade4_lvl){
            case 1: humanity_manager.SetHumanityLimit( humanity_manager.GetHumanityLimit() + 166 ); break;
            case 2: humanity_manager.SetHumanityLimit( humanity_manager.GetHumanityLimit() + 116666666 ); break;
            case 3: humanity_manager.SetHumanityLimit( humanity_manager.GetHumanityLimit() + 233333332 ); break;
            case 4: humanity_manager.SetHumanityLimit( humanity_manager.GetHumanityLimit() + 349999998 ); break;
            case 5: humanity_manager.SetHumanityLimit( humanity_manager.GetHumanityLimit() + 466666664 ); break;
        }
        UI_upgrade4_lvl_value.text = upgrade4_lvl.ToString();
    }
    public void SetUpgrade5Lvl(int up5) {
        if (up5 <= 0) { up5 = 1; } 
        else if (up5 >= 6) { up5 = 5; }

        upgrade5_lvl = up5;
        switch(upgrade5_lvl){
            case 1: humanity_manager.SetHumanityLimit( humanity_manager.GetHumanityLimit() + 166 ); break;
            case 2: humanity_manager.SetHumanityLimit( humanity_manager.GetHumanityLimit() + 116666666 ); break;
            case 3: humanity_manager.SetHumanityLimit( humanity_manager.GetHumanityLimit() + 233333332 ); break;
            case 4: humanity_manager.SetHumanityLimit( humanity_manager.GetHumanityLimit() + 349999998 ); break;
            case 5: humanity_manager.SetHumanityLimit( humanity_manager.GetHumanityLimit() + 466666664 ); break;
        }
        UI_upgrade5_lvl_value.text = upgrade5_lvl.ToString();
    }
    public void SetUpgrade6Lvl(int up6) {
        if (up6 <= 0) { up6 = 1; } 
        else if (up6 >= 6) { up6 = 5; }

        upgrade6_lvl = up6;
        switch(upgrade6_lvl){
            case 1: humanity_manager.SetHumanityLimit( humanity_manager.GetHumanityLimit() + 166 ); break;
            case 2: humanity_manager.SetHumanityLimit( humanity_manager.GetHumanityLimit() + 116666666 ); break;
            case 3: humanity_manager.SetHumanityLimit( humanity_manager.GetHumanityLimit() + 233333332 ); break;
            case 4: humanity_manager.SetHumanityLimit( humanity_manager.GetHumanityLimit() + 349999998 ); break;
            case 5: humanity_manager.SetHumanityLimit( humanity_manager.GetHumanityLimit() + 466666664 ); break;
        }
        UI_upgrade6_lvl_value.text = upgrade6_lvl.ToString();
    }
    

    // Resources required getters
    public ResourcesRequired GetResourcesRequiredCarbon() { return carbon_lvlup_requirements[carbon_lvl+1]; }
    public ResourcesRequired GetResourcesRequiredIron() { return iron_lvlup_requirements[iron_lvl+1]; }
    public ResourcesRequired GetResourcesRequiredSilver() { return silver_lvlup_requirements[silver_lvl+1]; }
    public ResourcesRequired GetResourcesRequiredGold() { return gold_lvlup_requirements[gold_lvl+1]; }
    public ResourcesRequired GetResourcesRequiredDiamond() { return diamond_lvlup_requirements[diamond_lvl+1]; }
    public ResourcesRequired GetResourcesRequiredUpgrade1() { return upgrade1_lvlup_requirements[upgrade1_lvl+1]; }
    public ResourcesRequired GetResourcesRequiredUpgrade2() { return upgrade2_lvlup_requirements[upgrade2_lvl+1]; }
    public ResourcesRequired GetResourcesRequiredUpgrade3() { return upgrade3_lvlup_requirements[upgrade3_lvl+1]; }
    public ResourcesRequired GetResourcesRequiredUpgrade4() { return upgrade4_lvlup_requirements[upgrade4_lvl+1]; }
    public ResourcesRequired GetResourcesRequiredUpgrade5() { return upgrade5_lvlup_requirements[upgrade5_lvl+1]; }
    public ResourcesRequired GetResourcesRequiredUpgrade6() { return upgrade6_lvlup_requirements[upgrade6_lvl+1]; }

    private void SetGeneratorsLvlUpRequirements() {

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

        silver_lvlup_requirements = new Dictionary<int, ResourcesRequired>()
        {
            {2 , new ResourcesRequired {
                carbon = 60,
                iron = 35,
                silver = 30,
                gold = 0,
                diamond = 0
            }},
            {3 , new ResourcesRequired {
                carbon = 170,
                iron = 140,
                silver = 115,
                gold = 30,
                diamond = 0
            }},
            {4 , new ResourcesRequired {
                carbon = 300,
                iron = 280,
                silver = 240,
                gold = 90,
                diamond = 10
            }},
            {5 , new ResourcesRequired {
                carbon = 450,
                iron = 380,
                silver = 310,
                gold = 120,
                diamond = 50
            }}
        };

        gold_lvlup_requirements = new Dictionary<int, ResourcesRequired>()
        {
            {2 , new ResourcesRequired {
                carbon = 90,
                iron = 65,
                silver = 60,
                gold = 10,
                diamond = 0
            }},
            {3 , new ResourcesRequired {
                carbon = 220,
                iron = 180,
                silver = 155,
                gold = 60,
                diamond = 10
            }},
            {4 , new ResourcesRequired {
                carbon = 370,
                iron = 330,
                silver = 280,
                gold = 110,
                diamond = 40
            }},
            {5 , new ResourcesRequired {
                carbon = 450,
                iron = 380,
                silver = 310,
                gold = 120,
                diamond = 70
            }}
        };

        diamond_lvlup_requirements = new Dictionary<int, ResourcesRequired>()
        {
            {2 , new ResourcesRequired {
                carbon = 150,
                iron = 125,
                silver = 90,
                gold = 60,
                diamond = 10
            }},
            {3 , new ResourcesRequired {
                carbon = 280,
                iron = 260,
                silver = 220,
                gold = 140,
                diamond = 70
            }},
            {4 , new ResourcesRequired {
                carbon = 400,
                iron = 370,
                silver = 320,
                gold = 210,
                diamond = 120
            }},
            {5 , new ResourcesRequired {
                carbon = 500,
                iron = 500,
                silver = 500,
                gold = 500,
                diamond = 200
            }}
        };
    }

    private void SetPlanetUpgradesLvlUpRequirements() {
        // TO-DO: Diversify requirements
        upgrade1_lvlup_requirements = new Dictionary<int, ResourcesRequired>()
        {
            {2 , new ResourcesRequired {
                carbon = 90,
                iron = 65,
                silver = 60,
                gold = 10,
                diamond = 0
            }},
            {3 , new ResourcesRequired {
                carbon = 220,
                iron = 180,
                silver = 155,
                gold = 60,
                diamond = 10
            }},
            {4 , new ResourcesRequired {
                carbon = 370,
                iron = 330,
                silver = 280,
                gold = 110,
                diamond = 40
            }},
            {5 , new ResourcesRequired {
                carbon = 450,
                iron = 380,
                silver = 310,
                gold = 120,
                diamond = 70
            }}
        };

        upgrade2_lvlup_requirements = new Dictionary<int, ResourcesRequired>()
        {
            {2 , new ResourcesRequired {
                carbon = 90,
                iron = 65,
                silver = 60,
                gold = 10,
                diamond = 0
            }},
            {3 , new ResourcesRequired {
                carbon = 220,
                iron = 180,
                silver = 155,
                gold = 60,
                diamond = 10
            }},
            {4 , new ResourcesRequired {
                carbon = 370,
                iron = 330,
                silver = 280,
                gold = 110,
                diamond = 40
            }},
            {5 , new ResourcesRequired {
                carbon = 450,
                iron = 380,
                silver = 310,
                gold = 120,
                diamond = 70
            }}
        };

        upgrade3_lvlup_requirements = new Dictionary<int, ResourcesRequired>()
        {
            {2 , new ResourcesRequired {
                carbon = 90,
                iron = 65,
                silver = 60,
                gold = 10,
                diamond = 0
            }},
            {3 , new ResourcesRequired {
                carbon = 220,
                iron = 180,
                silver = 155,
                gold = 60,
                diamond = 10
            }},
            {4 , new ResourcesRequired {
                carbon = 370,
                iron = 330,
                silver = 280,
                gold = 110,
                diamond = 40
            }},
            {5 , new ResourcesRequired {
                carbon = 450,
                iron = 380,
                silver = 310,
                gold = 120,
                diamond = 70
            }}
        };

        upgrade4_lvlup_requirements = new Dictionary<int, ResourcesRequired>()
        {
            {2 , new ResourcesRequired {
                carbon = 90,
                iron = 65,
                silver = 60,
                gold = 10,
                diamond = 0
            }},
            {3 , new ResourcesRequired {
                carbon = 220,
                iron = 180,
                silver = 155,
                gold = 60,
                diamond = 10
            }},
            {4 , new ResourcesRequired {
                carbon = 370,
                iron = 330,
                silver = 280,
                gold = 110,
                diamond = 40
            }},
            {5 , new ResourcesRequired {
                carbon = 450,
                iron = 380,
                silver = 310,
                gold = 120,
                diamond = 70
            }}
        };

        upgrade5_lvlup_requirements = new Dictionary<int, ResourcesRequired>()
        {
            {2 , new ResourcesRequired {
                carbon = 90,
                iron = 65,
                silver = 60,
                gold = 10,
                diamond = 0
            }},
            {3 , new ResourcesRequired {
                carbon = 220,
                iron = 180,
                silver = 155,
                gold = 60,
                diamond = 10
            }},
            {4 , new ResourcesRequired {
                carbon = 370,
                iron = 330,
                silver = 280,
                gold = 110,
                diamond = 40
            }},
            {5 , new ResourcesRequired {
                carbon = 450,
                iron = 380,
                silver = 310,
                gold = 120,
                diamond = 70
            }}
        };

        upgrade6_lvlup_requirements = new Dictionary<int, ResourcesRequired>()
        {
            {2 , new ResourcesRequired {
                carbon = 90,
                iron = 65,
                silver = 60,
                gold = 10,
                diamond = 0
            }},
            {3 , new ResourcesRequired {
                carbon = 220,
                iron = 180,
                silver = 155,
                gold = 60,
                diamond = 10
            }},
            {4 , new ResourcesRequired {
                carbon = 370,
                iron = 330,
                silver = 280,
                gold = 110,
                diamond = 40
            }},
            {5 , new ResourcesRequired {
                carbon = 450,
                iron = 380,
                silver = 310,
                gold = 120,
                diamond = 70
            }}
        };
    }

    // Start is called before the first frame update
    void Start()
    {
        SetGeneratorsLvlUpRequirements();
        SetPlanetUpgradesLvlUpRequirements();
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
