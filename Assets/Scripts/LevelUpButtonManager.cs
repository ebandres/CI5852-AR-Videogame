using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUpButtonManager : MonoBehaviour
{
    // Private variables
    private UpgradesManager upgrades_manager;
    private ResourcesGatheredManager game_handler_resource_gathered;
    private SaveHandler game_handler_save;
    // Public variables
    public GameObject Planet;

    // Start is called before the first frame update
    void Start()
    {
        upgrades_manager = Planet.GetComponent<UpgradesManager>();
        game_handler_resource_gathered = GameObject.Find("Game Handler").GetComponent<ResourcesGatheredManager>();
        game_handler_save = GameObject.Find("Game Handler").GetComponent<SaveHandler>();
    }

    // Function to level up carbon generator on a given planet
    public void LvlUpCarbonGeneratorButton() {
        if (upgrades_manager.GetCarbonLvl() <= 4) {
            UpgradesManager.ResourcesRequired resources_requiered = upgrades_manager.GetResourcesRequiredCarbon();
            // If the user has the required resources to level up
            if (
                resources_requiered.carbon <= game_handler_resource_gathered.GetCarbon() &&
                resources_requiered.iron <= game_handler_resource_gathered.GetIron() &&
                resources_requiered.silver <= game_handler_resource_gathered.GetSilver() &&
                resources_requiered.gold <= game_handler_resource_gathered.GetGold() &&
                resources_requiered.diamond <= game_handler_resource_gathered.GetDiamond()
            ) { 
                // Level up
                upgrades_manager.SetCarbonLvl( upgrades_manager.GetCarbonLvl() + 1 );
                // Consume the required resources gathered by the user
                game_handler_resource_gathered.SetCarbon( game_handler_resource_gathered.GetCarbon() - resources_requiered.carbon );
                game_handler_resource_gathered.SetIron( game_handler_resource_gathered.GetIron() - resources_requiered.iron );
                game_handler_resource_gathered.SetSilver( game_handler_resource_gathered.GetSilver() - resources_requiered.silver );
                game_handler_resource_gathered.SetGold( game_handler_resource_gathered.GetGold() - resources_requiered.gold );
                game_handler_resource_gathered.SetDiamond( game_handler_resource_gathered.GetDiamond() - resources_requiered.diamond );
                // Save the game
                game_handler_save.Save();
            }
        }
    }

    // Function to level up iron generator on a given planet
    public void LvlUpIronGeneratorButton() {
        if (upgrades_manager.GetIronLvl() <= 4) {
            UpgradesManager.ResourcesRequired resources_requiered = upgrades_manager.GetResourcesRequiredIron();
            // If the user has the required resources to level up
            if (
                resources_requiered.carbon <= game_handler_resource_gathered.GetCarbon() &&
                resources_requiered.iron <= game_handler_resource_gathered.GetIron() &&
                resources_requiered.silver <= game_handler_resource_gathered.GetSilver() &&
                resources_requiered.gold <= game_handler_resource_gathered.GetGold() &&
                resources_requiered.diamond <= game_handler_resource_gathered.GetDiamond()
            ) { 
                // Level up
                upgrades_manager.SetIronLvl( upgrades_manager.GetIronLvl() + 1 );
                // Consume the required resources gathered by the user
                game_handler_resource_gathered.SetCarbon( game_handler_resource_gathered.GetCarbon() - resources_requiered.carbon );
                game_handler_resource_gathered.SetIron( game_handler_resource_gathered.GetIron() - resources_requiered.iron );
                game_handler_resource_gathered.SetSilver( game_handler_resource_gathered.GetSilver() - resources_requiered.silver );
                game_handler_resource_gathered.SetGold( game_handler_resource_gathered.GetGold() - resources_requiered.gold );
                game_handler_resource_gathered.SetDiamond( game_handler_resource_gathered.GetDiamond() - resources_requiered.diamond );
                // Save the game
                game_handler_save.Save();
            }
        }
    }

    // Function to level up silver generator on a given planet
    public void LvlUpSilverGeneratorButton() {
        if (upgrades_manager.GetSilverLvl() <= 4) {
            UpgradesManager.ResourcesRequired resources_requiered = upgrades_manager.GetResourcesRequiredSilver();
            // If the user has the required resources to level up
            if (
                resources_requiered.carbon <= game_handler_resource_gathered.GetCarbon() &&
                resources_requiered.iron <= game_handler_resource_gathered.GetIron() &&
                resources_requiered.silver <= game_handler_resource_gathered.GetSilver() &&
                resources_requiered.gold <= game_handler_resource_gathered.GetGold() &&
                resources_requiered.diamond <= game_handler_resource_gathered.GetDiamond()
            ) { 
                // Level up
                upgrades_manager.SetSilverLvl( upgrades_manager.GetSilverLvl() + 1 );
                // Consume the required resources gathered by the user
                game_handler_resource_gathered.SetCarbon( game_handler_resource_gathered.GetCarbon() - resources_requiered.carbon );
                game_handler_resource_gathered.SetIron( game_handler_resource_gathered.GetIron() - resources_requiered.iron );
                game_handler_resource_gathered.SetSilver( game_handler_resource_gathered.GetSilver() - resources_requiered.silver );
                game_handler_resource_gathered.SetGold( game_handler_resource_gathered.GetGold() - resources_requiered.gold );
                game_handler_resource_gathered.SetDiamond( game_handler_resource_gathered.GetDiamond() - resources_requiered.diamond );
                // Save the game
                game_handler_save.Save();
            }
        }
    }

    // Function to level up gold generator on a given planet
    public void LvlUpGoldGeneratorButton() {
        if (upgrades_manager.GetGoldLvl() <= 4) {
            UpgradesManager.ResourcesRequired resources_requiered = upgrades_manager.GetResourcesRequiredGold();
            // If the user has the required resources to level up
            if (
                resources_requiered.carbon <= game_handler_resource_gathered.GetCarbon() &&
                resources_requiered.iron <= game_handler_resource_gathered.GetIron() &&
                resources_requiered.silver <= game_handler_resource_gathered.GetSilver() &&
                resources_requiered.gold <= game_handler_resource_gathered.GetGold() &&
                resources_requiered.diamond <= game_handler_resource_gathered.GetDiamond()
            ) { 
                // Level up
                upgrades_manager.SetGoldLvl( upgrades_manager.GetGoldLvl() + 1 );
                // Consume the required resources gathered by the user
                game_handler_resource_gathered.SetCarbon( game_handler_resource_gathered.GetCarbon() - resources_requiered.carbon );
                game_handler_resource_gathered.SetIron( game_handler_resource_gathered.GetIron() - resources_requiered.iron );
                game_handler_resource_gathered.SetSilver( game_handler_resource_gathered.GetSilver() - resources_requiered.silver );
                game_handler_resource_gathered.SetGold( game_handler_resource_gathered.GetGold() - resources_requiered.gold );
                game_handler_resource_gathered.SetDiamond( game_handler_resource_gathered.GetDiamond() - resources_requiered.diamond );
                // Save the game
                game_handler_save.Save();
            }
        }
    }

    // Function to level up iron generator on a given planet
    public void LvlUpDiamondGeneratorButton() {
        if (upgrades_manager.GetDiamondLvl() <= 4) {
            UpgradesManager.ResourcesRequired resources_requiered = upgrades_manager.GetResourcesRequiredDiamond();
            // If the user has the required resources to level up
            if (
                resources_requiered.carbon <= game_handler_resource_gathered.GetCarbon() &&
                resources_requiered.iron <= game_handler_resource_gathered.GetIron() &&
                resources_requiered.silver <= game_handler_resource_gathered.GetSilver() &&
                resources_requiered.gold <= game_handler_resource_gathered.GetGold() &&
                resources_requiered.diamond <= game_handler_resource_gathered.GetDiamond()
            ) { 
                // Level up
                upgrades_manager.SetDiamondLvl( upgrades_manager.GetDiamondLvl() + 1 );
                // Consume the required resources gathered by the user
                game_handler_resource_gathered.SetCarbon( game_handler_resource_gathered.GetCarbon() - resources_requiered.carbon );
                game_handler_resource_gathered.SetIron( game_handler_resource_gathered.GetIron() - resources_requiered.iron );
                game_handler_resource_gathered.SetSilver( game_handler_resource_gathered.GetSilver() - resources_requiered.silver );
                game_handler_resource_gathered.SetGold( game_handler_resource_gathered.GetGold() - resources_requiered.gold );
                game_handler_resource_gathered.SetDiamond( game_handler_resource_gathered.GetDiamond() - resources_requiered.diamond );
                // Save the game
                game_handler_save.Save();
            }
        }
    }

    // Function to level up upgrade1 on a given planet
    public void LvlUpUpgrade1Button() {
        if (upgrades_manager.GetUpgrade1Lvl() <= 4) {
            UpgradesManager.ResourcesRequired resources_requiered = upgrades_manager.GetResourcesRequiredUpgrade1();
            // If the user has the required resources to level up
            if (
                resources_requiered.carbon <= game_handler_resource_gathered.GetCarbon() &&
                resources_requiered.iron <= game_handler_resource_gathered.GetIron() &&
                resources_requiered.silver <= game_handler_resource_gathered.GetSilver() &&
                resources_requiered.gold <= game_handler_resource_gathered.GetGold() &&
                resources_requiered.diamond <= game_handler_resource_gathered.GetDiamond()
            ) { 
                // Level up
                upgrades_manager.SetUpgrade1Lvl( upgrades_manager.GetUpgrade1Lvl() + 1 );
                // Consume the required resources gathered by the user
                game_handler_resource_gathered.SetCarbon( game_handler_resource_gathered.GetCarbon() - resources_requiered.carbon );
                game_handler_resource_gathered.SetIron( game_handler_resource_gathered.GetIron() - resources_requiered.iron );
                game_handler_resource_gathered.SetSilver( game_handler_resource_gathered.GetSilver() - resources_requiered.silver );
                game_handler_resource_gathered.SetGold( game_handler_resource_gathered.GetGold() - resources_requiered.gold );
                game_handler_resource_gathered.SetDiamond( game_handler_resource_gathered.GetDiamond() - resources_requiered.diamond );
                // Save the game
                game_handler_save.Save();
            }
        }
    }

    // Function to level up upgrade2 on a given planet
    public void LvlUpUpgrade2Button() {
        if (upgrades_manager.GetUpgrade2Lvl() <= 4) {
            UpgradesManager.ResourcesRequired resources_requiered = upgrades_manager.GetResourcesRequiredUpgrade2();
            // If the user has the required resources to level up
            if (
                resources_requiered.carbon <= game_handler_resource_gathered.GetCarbon() &&
                resources_requiered.iron <= game_handler_resource_gathered.GetIron() &&
                resources_requiered.silver <= game_handler_resource_gathered.GetSilver() &&
                resources_requiered.gold <= game_handler_resource_gathered.GetGold() &&
                resources_requiered.diamond <= game_handler_resource_gathered.GetDiamond()
            ) { 
                // Level up
                upgrades_manager.SetUpgrade2Lvl( upgrades_manager.GetUpgrade2Lvl() + 1 );
                // Consume the required resources gathered by the user
                game_handler_resource_gathered.SetCarbon( game_handler_resource_gathered.GetCarbon() - resources_requiered.carbon );
                game_handler_resource_gathered.SetIron( game_handler_resource_gathered.GetIron() - resources_requiered.iron );
                game_handler_resource_gathered.SetSilver( game_handler_resource_gathered.GetSilver() - resources_requiered.silver );
                game_handler_resource_gathered.SetGold( game_handler_resource_gathered.GetGold() - resources_requiered.gold );
                game_handler_resource_gathered.SetDiamond( game_handler_resource_gathered.GetDiamond() - resources_requiered.diamond );
                // Save the game
                game_handler_save.Save();
            }
        }
    }

    // Function to level up upgrade3 on a given planet
    public void LvlUpUpgrade3Button() {
        if (upgrades_manager.GetUpgrade3Lvl() <= 4) {
            UpgradesManager.ResourcesRequired resources_requiered = upgrades_manager.GetResourcesRequiredUpgrade3();
            // If the user has the required resources to level up
            if (
                resources_requiered.carbon <= game_handler_resource_gathered.GetCarbon() &&
                resources_requiered.iron <= game_handler_resource_gathered.GetIron() &&
                resources_requiered.silver <= game_handler_resource_gathered.GetSilver() &&
                resources_requiered.gold <= game_handler_resource_gathered.GetGold() &&
                resources_requiered.diamond <= game_handler_resource_gathered.GetDiamond()
            ) { 
                // Level up
                upgrades_manager.SetUpgrade3Lvl( upgrades_manager.GetUpgrade3Lvl() + 1 );
                // Consume the required resources gathered by the user
                game_handler_resource_gathered.SetCarbon( game_handler_resource_gathered.GetCarbon() - resources_requiered.carbon );
                game_handler_resource_gathered.SetIron( game_handler_resource_gathered.GetIron() - resources_requiered.iron );
                game_handler_resource_gathered.SetSilver( game_handler_resource_gathered.GetSilver() - resources_requiered.silver );
                game_handler_resource_gathered.SetGold( game_handler_resource_gathered.GetGold() - resources_requiered.gold );
                game_handler_resource_gathered.SetDiamond( game_handler_resource_gathered.GetDiamond() - resources_requiered.diamond );
                // Save the game
                game_handler_save.Save();
            }
        }
    }

    // Function to level up upgrade4 on a given planet
    public void LvlUpUpgrade4Button() {
        if (upgrades_manager.GetUpgrade4Lvl() <= 4) {
            UpgradesManager.ResourcesRequired resources_requiered = upgrades_manager.GetResourcesRequiredUpgrade4();
            // If the user has the required resources to level up
            if (
                resources_requiered.carbon <= game_handler_resource_gathered.GetCarbon() &&
                resources_requiered.iron <= game_handler_resource_gathered.GetIron() &&
                resources_requiered.silver <= game_handler_resource_gathered.GetSilver() &&
                resources_requiered.gold <= game_handler_resource_gathered.GetGold() &&
                resources_requiered.diamond <= game_handler_resource_gathered.GetDiamond()
            ) { 
                // Level up
                upgrades_manager.SetUpgrade4Lvl( upgrades_manager.GetUpgrade4Lvl() + 1 );
                // Consume the required resources gathered by the user
                game_handler_resource_gathered.SetCarbon( game_handler_resource_gathered.GetCarbon() - resources_requiered.carbon );
                game_handler_resource_gathered.SetIron( game_handler_resource_gathered.GetIron() - resources_requiered.iron );
                game_handler_resource_gathered.SetSilver( game_handler_resource_gathered.GetSilver() - resources_requiered.silver );
                game_handler_resource_gathered.SetGold( game_handler_resource_gathered.GetGold() - resources_requiered.gold );
                game_handler_resource_gathered.SetDiamond( game_handler_resource_gathered.GetDiamond() - resources_requiered.diamond );
                // Save the game
                game_handler_save.Save();
            }
        }
    }

    // Function to level up upgrade5 on a given planet
    public void LvlUpUpgrade5Button() {
        if (upgrades_manager.GetUpgrade5Lvl() <= 4) {
            UpgradesManager.ResourcesRequired resources_requiered = upgrades_manager.GetResourcesRequiredUpgrade5();
            // If the user has the required resources to level up
            if (
                resources_requiered.carbon <= game_handler_resource_gathered.GetCarbon() &&
                resources_requiered.iron <= game_handler_resource_gathered.GetIron() &&
                resources_requiered.silver <= game_handler_resource_gathered.GetSilver() &&
                resources_requiered.gold <= game_handler_resource_gathered.GetGold() &&
                resources_requiered.diamond <= game_handler_resource_gathered.GetDiamond()
            ) { 
                // Level up
                upgrades_manager.SetUpgrade5Lvl( upgrades_manager.GetUpgrade5Lvl() + 1 );
                // Consume the required resources gathered by the user
                game_handler_resource_gathered.SetCarbon( game_handler_resource_gathered.GetCarbon() - resources_requiered.carbon );
                game_handler_resource_gathered.SetIron( game_handler_resource_gathered.GetIron() - resources_requiered.iron );
                game_handler_resource_gathered.SetSilver( game_handler_resource_gathered.GetSilver() - resources_requiered.silver );
                game_handler_resource_gathered.SetGold( game_handler_resource_gathered.GetGold() - resources_requiered.gold );
                game_handler_resource_gathered.SetDiamond( game_handler_resource_gathered.GetDiamond() - resources_requiered.diamond );
                // Save the game
                game_handler_save.Save();
            }
        }
    }

    // Function to level up upgrade6 on a given planet
    public void LvlUpUpgrade6Button() {
        if (upgrades_manager.GetUpgrade6Lvl() <= 4) {
            UpgradesManager.ResourcesRequired resources_requiered = upgrades_manager.GetResourcesRequiredUpgrade6();
            // If the user has the required resources to level up
            if (
                resources_requiered.carbon <= game_handler_resource_gathered.GetCarbon() &&
                resources_requiered.iron <= game_handler_resource_gathered.GetIron() &&
                resources_requiered.silver <= game_handler_resource_gathered.GetSilver() &&
                resources_requiered.gold <= game_handler_resource_gathered.GetGold() &&
                resources_requiered.diamond <= game_handler_resource_gathered.GetDiamond()
            ) { 
                // Level up
                upgrades_manager.SetUpgrade6Lvl( upgrades_manager.GetUpgrade6Lvl() + 1 );
                // Consume the required resources gathered by the user
                game_handler_resource_gathered.SetCarbon( game_handler_resource_gathered.GetCarbon() - resources_requiered.carbon );
                game_handler_resource_gathered.SetIron( game_handler_resource_gathered.GetIron() - resources_requiered.iron );
                game_handler_resource_gathered.SetSilver( game_handler_resource_gathered.GetSilver() - resources_requiered.silver );
                game_handler_resource_gathered.SetGold( game_handler_resource_gathered.GetGold() - resources_requiered.gold );
                game_handler_resource_gathered.SetDiamond( game_handler_resource_gathered.GetDiamond() - resources_requiered.diamond );
                // Save the game
                game_handler_save.Save();
            }
        }
    }
}
