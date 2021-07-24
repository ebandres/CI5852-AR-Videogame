using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradesManager : MonoBehaviour
{
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


    // Start is called before the first frame update
    void Start()
    {
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

    // Resources required getters
    public ResourcesRequired GetResourcesRequiredCarbon() {
        return carbon_lvlup_requirements[carbon_lvl+1];
    }
    public ResourcesRequired GetResourcesRequiredIron() {
        return iron_lvlup_requirements[iron_lvl+1];
    }
    public ResourcesRequired GetResourcesRequiredSilver() {
        return silver_lvlup_requirements[silver_lvl+1];
    }
    public ResourcesRequired GetResourcesRequiredGold() {
        return gold_lvlup_requirements[gold_lvl+1];
    }
    public ResourcesRequired GetResourcesRequiredDiamond() {
        return diamond_lvlup_requirements[diamond_lvl+1];
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
