using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ResourceGenerator : MonoBehaviour
{
	// Public variables
    public int time = 2;
    public double nothing_prob = 0.23;
    public double carbon_prob = 0.30; // 0.75 Max Lvl
    public double iron_prob = 0.20; // 0.5 Max Lvl
    public double silver_prob = 0.12; // 0.37 Max Lvl
    public double gold_prob = 0.10; // 0.25 Max Lvl
    public double diamond_prob = 0.05; // 0.12 Max Lvl
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
    private int carbon_generator_limiter = 1;
    private int iron_generator_limiter = 1;
    private int silver_generator_limiter = 1;
    private int gold_generator_limiter = 1;
    private int diamond_generator_limiter = 1;
    private UpgradesManager upgrades_manager;

    // Getters
    public int GetCarbonGenLimiter() { return carbon_generator_limiter; }
    public int GetIronGenLimiter() { return iron_generator_limiter; }
    public int GetSilverGenLimiter() { return silver_generator_limiter; }
    public int GetGoldGenLimiter() { return gold_generator_limiter; }
    public int GetDiamondGenLimiter() { return diamond_generator_limiter; }

    // Setters
    public void SetCarbonGenLimiter(int c) { carbon_generator_limiter = c; }
    public void SetIronGenLimiter(int i) { iron_generator_limiter = i; }
    public void SetSilverGenLimiter(int s) { silver_generator_limiter = s; }
    public void SetGoldGenLimiter(int g) { gold_generator_limiter = g; }
    public void SetDiamondGenLimiter(int d) { diamond_generator_limiter = d; }
    
    // Gather resources functions
    public int GatherCarbon() { 
        int tmp = carbon;
        carbon = 0;
        UI_carbon_value.text = carbon.ToString();
        return tmp; 
    }
    public int GatherIron() { 
        int tmp = iron;
        iron = 0;
        UI_iron_value.text = iron.ToString();
        return tmp; 
    }
    public int GatherSilver() { 
        int tmp = silver;
        silver = 0;
        UI_silver_value.text = silver.ToString();
        return tmp; 
    }
    public int GatherGold() { 
        int tmp = gold;
        gold = 0;
        UI_gold_value.text = gold.ToString();
        return tmp; 
    }
    public int GatherDiamond() { 
        int tmp = diamond;
        diamond = 0;
        UI_diamond_value.text = diamond.ToString();
        return tmp; 
    }


    void Start()
    {   
        upgrades_manager = gameObject.GetComponent<UpgradesManager>();
        StartCoroutine("ResourceCoroutine");
    }


    IEnumerator ResourceCoroutine() {
        System.Random random = new System.Random();
        double nothing_extracted, carbon_extracted, iron_extracted, silver_extracted, gold_extracted, diamond_extracted;

    	while (true){
            
            nothing_extracted = random.NextDouble();
    		carbon_extracted = random.NextDouble();
            iron_extracted = random.NextDouble();
            silver_extracted = random.NextDouble();
            gold_extracted = random.NextDouble();
            diamond_extracted = random.NextDouble();

            if (nothing_extracted <= nothing_prob) {
                continue;
            }

            if (carbon_extracted <= carbon_prob){
                if(upgrades_manager.GetCarbonLvl() == 1){
                    carbon += 1;
                }
                else {
                    carbon += random.Next(
                        random.Next(1, carbon_generator_limiter), 
                        carbon_generator_limiter+2
                    );
                }
                UI_carbon_value.text = carbon.ToString();
            } 

            if (iron_extracted <= iron_prob){
                if(upgrades_manager.GetIronLvl() == 1){
                    iron += 1;
                }
                else {
                    iron += random.Next(
                        random.Next(1, iron_generator_limiter), 
                        iron_generator_limiter+2
                    );
                }
                UI_iron_value.text = iron.ToString();
            } 
            
            if (silver_extracted <= silver_prob){
                if(upgrades_manager.GetSilverLvl() == 1){
                    silver += 1;
                }
                else {
                    silver += random.Next(
                        random.Next(1, silver_generator_limiter), 
                        silver_generator_limiter+2
                    );
                }
                UI_silver_value.text = silver.ToString();
            }

            if (gold_extracted <= gold_prob){
                if(upgrades_manager.GetGoldLvl() == 1){
                    gold += 1;
                }
                else {
                    gold += random.Next(
                        random.Next(1, gold_generator_limiter), 
                        gold_generator_limiter+2
                    );
                }
                UI_gold_value.text = gold.ToString();
            }
            
            if (diamond_extracted <= diamond_prob){
                if(upgrades_manager.GetDiamondLvl() == 1){
                    diamond += 1;
                }
                else {
                    diamond += random.Next(
                        random.Next(1, diamond_generator_limiter), 
                        diamond_generator_limiter+2
                    );
                }
                UI_diamond_value.text = diamond.ToString();
            }

    		yield return new WaitForSeconds(time);

    	}
    }
}