using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HumanityManager : MonoBehaviour
{   
    // Public variables
    public int time = 2;
    public double nothing_prob = 0.23;
    public double humans_prob = 0.50;
    public Text UI_humanity_value;
    // Private variables
    private ulong humans = 1000;
    [SerializeField]
    private ulong humans_limit = 1000;

    // Getters
    public ulong GetHumanity() { return humans; }
    public ulong GetHumanityLimit() { return humans_limit; }

    // Setters
    public void SetHumanity(ulong h) { humans = h; UI_humanity_value.text = humans.ToString(); }
    public void SetHumanityLimit(ulong h) { humans_limit = h; }


    public void HumanPercentageDecrease(int percentage){
        SetHumanity(humans - (ulong)(humans*((float)percentage/100)));
    }


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("HumanityCoroutine");
    }

    IEnumerator HumanityCoroutine() {
        System.Random random = new System.Random();
        while (true){
            double resource = random.NextDouble();
            if (nothing_prob < resource && humans_limit > humans){
                if (resource <= humans_prob){
                    humans += (ulong)random.Next(20);
                    UI_humanity_value.text = humans.ToString();
                }
            }

            yield return new WaitForSeconds(time);
        }
    }

}
