using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClampPlanetMenu : MonoBehaviour
{
    public Image menu_hud;

    // Update is called once per frame
    void Update()
    {
        menu_hud.transform.position = Camera.main.WorldToScreenPoint(this.transform.position);
    }
}
