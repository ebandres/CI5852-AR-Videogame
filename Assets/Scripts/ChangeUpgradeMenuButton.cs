using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeUpgradeMenuButton : MonoBehaviour
{
    public GameObject menu_2;
    public void ChangeUpgradeMenu() { 
        menu_2.SetActive(true);
        gameObject.transform.parent.gameObject.SetActive(false); 
    }
}