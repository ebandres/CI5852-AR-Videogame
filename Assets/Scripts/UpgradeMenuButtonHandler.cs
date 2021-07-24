using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeMenuButtonHandler : MonoBehaviour
{
    // Public variable
    public GameObject upgrade_menu;
    public GameObject main_menu;

    public void ShowUpgradeMenu() 
    {
        upgrade_menu.SetActive(true);
        main_menu.SetActive(false);
    }

    public void ShowMainMenu() 
    {
        main_menu.SetActive(true);
        upgrade_menu.SetActive(false);
    }
}
