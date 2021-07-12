using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ResourceGenerator : MonoBehaviour
{
	// Public variables
    public int coal = 0;
    public int iron = 0;
    public int silver = 0;
    public int gold = 0;
    public int diamond = 0;
    public int time = 2;
    public double nothing_prob = 0.23;
    public double coal_prob = 0.53;
    public double iron_prob = 0.73;
    public double silver_prob = 0.85;
    public double gold_prob = 0.95;
    public double diamond_prob = 1;

    // Private variables
    private Text UI_coal_value;
    private Text UI_iron_value;
    private Text UI_silver_value;
    private Text UI_gold_value;
    private Text UI_diamond_value;

    void Start()
    {
        UI_coal_value = GameObject.Find("Value Carbono " + gameObject.name).GetComponent<Text>();
        UI_iron_value = GameObject.Find("Value Hierro " + gameObject.name).GetComponent<Text>();
        UI_silver_value = GameObject.Find("Value Plata " + gameObject.name).GetComponent<Text>();
        UI_gold_value = GameObject.Find("Value Oro " + gameObject.name).GetComponent<Text>();
        UI_diamond_value = GameObject.Find("Value Diamante " + gameObject.name).GetComponent<Text>();
        StartCoroutine("ResourceCoroutine");
    }


    IEnumerator ResourceCoroutine() {
    	while (true){
    		double resource = new System.Random().NextDouble();
            Debug.Log(resource);
            if (nothing_prob < resource){
                if (resource <= coal_prob){
                    Debug.Log(gameObject.name + " CARBON");
                    coal += 1;
                    UI_coal_value.text = coal.ToString();
                } else if (resource <= iron_prob){
                    Debug.Log(gameObject.name + " HIERRO");
                    iron += 1;
                    UI_iron_value.text = iron.ToString();
                } else if (resource <= silver_prob){
                    Debug.Log(gameObject.name + " PLATA");
                    silver += 1;
                    UI_silver_value.text = silver.ToString();
                } else if (resource <= gold_prob){
                    Debug.Log(gameObject.name + " ORO");
                    gold += 1;
                    UI_gold_value.text = gold.ToString();
                } else if (resource <= diamond_prob){
                    Debug.Log(gameObject.name + " DIAMANTE");
                    diamond += 1;
                    UI_diamond_value.text = diamond.ToString();
                }
            }

    		yield return new WaitForSeconds(time);

    	}
    }
}
