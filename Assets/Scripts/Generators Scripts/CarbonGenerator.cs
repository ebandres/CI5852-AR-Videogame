using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarbonGenerator : MonoBehaviour
{   
    // Public variables
    public bool gen_enabled = true;
    public int carbon = 0;
    // Private variables
    private float multiplier = 1;
    private Text UI_carbon_value;

    // Start is called before the first frame update
    void Start()
    {
        UI_carbon_value = GameObject.Find("Value Carbono " + gameObject.name).GetComponent<Text>();
        StartCoroutine("CarbonCoroutine");
    }

    IEnumerator CarbonCoroutine() {
        while(true){
            // If generator is enabled, it produces the resource based on a given multiplier
            if (gen_enabled) {
                carbon += (int)(1 * multiplier);
                // Show it on the planet menu UI
                UI_carbon_value.text = carbon.ToString();
            }
            yield return new WaitForSeconds(1);
        }
    }
}
