using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ResourceGenerator : MonoBehaviour
{
	// Public variables
    public int time = 2;
    public double nothing_prob = 0.23;
    public double carbon_prob = 0.53;
    public double iron_prob = 0.73;
    public double silver_prob = 0.85;
    public double gold_prob = 0.95;
    public double diamond_prob = 1;
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
        StartCoroutine("ResourceCoroutine");
    }


    IEnumerator ResourceCoroutine() {
    	while (true){
    		double resource = new System.Random().NextDouble();
            if (nothing_prob < resource){
                if (resource <= carbon_prob){
                    carbon += 1;
                    UI_carbon_value.text = carbon.ToString();
                } else if (resource <= iron_prob){
                    iron += 1;
                    UI_iron_value.text = iron.ToString();
                } else if (resource <= silver_prob){
                    silver += 1;
                    UI_silver_value.text = silver.ToString();
                } else if (resource <= gold_prob){
                    gold += 1;
                    UI_gold_value.text = gold.ToString();
                } else if (resource <= diamond_prob){
                    diamond += 1;
                    UI_diamond_value.text = diamond.ToString();
                }
            }

    		yield return new WaitForSeconds(time);

    	}
    }
}
