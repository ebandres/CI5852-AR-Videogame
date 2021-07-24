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


    public void ImproveCarbon(double upgrade){
    	if (nothing_prob - upgrade >= 0){
    		nothing_prob = nothing_prob - upgrade;
    	}
    }

    public void ImproveIron(double upgrade){
    	if (nothing_prob - upgrade >= 0){
    		nothing_prob = nothing_prob - upgrade;
    		carbon_prob = carbon_prob - upgrade;
    	}
    }

    public void ImproveSilver(double upgrade){
    	if (nothing_prob - upgrade >= 0){
    		nothing_prob = nothing_prob - upgrade;
    		carbon_prob = carbon_prob - upgrade;
    		iron_prob = iron_prob - upgrade;
    	}
    }

    public void ImproveGold(double upgrade){
    	if (nothing_prob - upgrade >= 0){
    		nothing_prob = nothing_prob - upgrade;
    		carbon_prob = carbon_prob - upgrade;
    		iron_prob = iron_prob - upgrade;
    		silver_prob = silver_prob - upgrade;
    	}
    }

    public void ImproveDiamond(double upgrade){
    	if (nothing_prob - upgrade >= 0){
    		nothing_prob = nothing_prob - upgrade;
    		carbon_prob = carbon_prob - upgrade;
    		iron_prob = iron_prob - upgrade;
    		silver_prob = silver_prob - upgrade;
    		gold_prob = gold_prob - upgrade;
    	}
    }

    public void downgradeCarbon(double downgrade){
    	if (carbon_prob - nothing_prob - downgrade >= 0){
    		nothing_prob = nothing_prob + downgrade;
    	}
    }

    public void downgradeIron(double downgrade){
    	if (iron_prob - carbon_prob - downgrade >= 0){
    		nothing_prob = nothing_prob + downgrade;
    		carbon_prob = carbon_prob + downgrade;
    	}
    }

    public void downgradeSilver(double downgrade){
    	if (silver_prob - iron_prob - downgrade >= 0){
    		nothing_prob = nothing_prob + downgrade;
    		carbon_prob = carbon_prob + downgrade;
    		iron_prob = iron_prob + downgrade;
    	}
    }

    public void downgradeGold(double downgrade){
    	if (gold_prob - silver_prob - downgrade >= 0){
    		nothing_prob = nothing_prob + downgrade;
    		carbon_prob = carbon_prob + downgrade;
    		iron_prob = iron_prob + downgrade;
    		silver_prob = silver_prob + downgrade;
    	}
    }

    public void downgradeDiamond(double downgrade){
    	if (diamond_prob - gold_prob - downgrade >= 0){
    		nothing_prob = nothing_prob + downgrade;
    		carbon_prob = carbon_prob + downgrade;
    		iron_prob = iron_prob + downgrade;
    		silver_prob = silver_prob + downgrade;
    	}
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
