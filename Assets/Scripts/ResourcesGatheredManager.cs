using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourcesGatheredManager : MonoBehaviour
{
    // Private variables
    [SerializeField] private Text UI_carbon_value;
    [SerializeField] private Text UI_iron_value;
    [SerializeField] private Text UI_silver_value;
    [SerializeField] private Text UI_gold_value;
    [SerializeField] private Text UI_diamond_value;
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
    
}
