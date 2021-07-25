using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUpButtonManager : MonoBehaviour
{
    // Private variables
    private UpgradesManager upgrades_manager;
    private GameHandler game_handler;
    // Public variables
    public GameObject Planet;

    // Start is called before the first frame update
    void Start()
    {
        upgrades_manager = Planet.GetComponent<UpgradesManager>();
        game_handler = GameObject.Find("Game Handler").GetComponent<GameHandler>();
    }

    // Function to level up carbon generator on a given planet
    public void LvlUpCarbonGeneratorButton() {
        UpgradesManager.ResourcesRequired resources_requiered = upgrades_manager.GetResourcesRequiredCarbon();
        // If the user has the required resources to level up
        if (
            resources_requiered.carbon <= game_handler.GetCarbon() &&
            resources_requiered.iron <= game_handler.GetIron() &&
            resources_requiered.silver <= game_handler.GetSilver() &&
            resources_requiered.gold <= game_handler.GetGold() &&
            resources_requiered.diamond <= game_handler.GetDiamond()
        ) { 
            // Level up
            upgrades_manager.SetCarbonLvl( upgrades_manager.GetCarbonLvl() + 1 );
            // Consume the required resources gathered by the user
            game_handler.SetCarbon( game_handler.GetCarbon() - resources_requiered.carbon );
            game_handler.SetIron( game_handler.GetIron() - resources_requiered.iron );
            game_handler.SetSilver( game_handler.GetSilver() - resources_requiered.silver );
            game_handler.SetGold( game_handler.GetGold() - resources_requiered.gold );
            game_handler.SetDiamond( game_handler.GetDiamond() - resources_requiered.diamond );
            // Save the game
            game_handler.Save();
        }
    }

    // Function to level up iron generator on a given planet
    public void LvlUpIronGeneratorButton() {
        UpgradesManager.ResourcesRequired resources_requiered = upgrades_manager.GetResourcesRequiredIron();
        // If the user has the required resources to level up
        if (
            resources_requiered.carbon <= game_handler.GetCarbon() &&
            resources_requiered.iron <= game_handler.GetIron() &&
            resources_requiered.silver <= game_handler.GetSilver() &&
            resources_requiered.gold <= game_handler.GetGold() &&
            resources_requiered.diamond <= game_handler.GetDiamond()
        ) { 
            // Level up
            upgrades_manager.SetIronLvl( upgrades_manager.GetIronLvl() + 1 );
            // Consume the required resources gathered by the user
            game_handler.SetCarbon( game_handler.GetCarbon() - resources_requiered.carbon );
            game_handler.SetIron( game_handler.GetIron() - resources_requiered.iron );
            game_handler.SetSilver( game_handler.GetSilver() - resources_requiered.silver );
            game_handler.SetGold( game_handler.GetGold() - resources_requiered.gold );
            game_handler.SetDiamond( game_handler.GetDiamond() - resources_requiered.diamond );
            // Save the game
            game_handler.Save();
        }
    }

    // Function to level up silver generator on a given planet
    public void LvlUpSilverGeneratorButton() {
        UpgradesManager.ResourcesRequired resources_requiered = upgrades_manager.GetResourcesRequiredSilver();
        // If the user has the required resources to level up
        if (
            resources_requiered.carbon <= game_handler.GetCarbon() &&
            resources_requiered.iron <= game_handler.GetIron() &&
            resources_requiered.silver <= game_handler.GetSilver() &&
            resources_requiered.gold <= game_handler.GetGold() &&
            resources_requiered.diamond <= game_handler.GetDiamond()
        ) { 
            // Level up
            upgrades_manager.SetSilverLvl( upgrades_manager.GetSilverLvl() + 1 );
            // Consume the required resources gathered by the user
            game_handler.SetCarbon( game_handler.GetCarbon() - resources_requiered.carbon );
            game_handler.SetIron( game_handler.GetIron() - resources_requiered.iron );
            game_handler.SetSilver( game_handler.GetSilver() - resources_requiered.silver );
            game_handler.SetGold( game_handler.GetGold() - resources_requiered.gold );
            game_handler.SetDiamond( game_handler.GetDiamond() - resources_requiered.diamond );
            // Save the game
            game_handler.Save();
        }
    }

    // Function to level up gold generator on a given planet
    public void LvlUpGoldGeneratorButton() {
        UpgradesManager.ResourcesRequired resources_requiered = upgrades_manager.GetResourcesRequiredGold();
        // If the user has the required resources to level up
        if (
            resources_requiered.carbon <= game_handler.GetCarbon() &&
            resources_requiered.iron <= game_handler.GetIron() &&
            resources_requiered.silver <= game_handler.GetSilver() &&
            resources_requiered.gold <= game_handler.GetGold() &&
            resources_requiered.diamond <= game_handler.GetDiamond()
        ) { 
            // Level up
            upgrades_manager.SetGoldLvl( upgrades_manager.GetGoldLvl() + 1 );
            // Consume the required resources gathered by the user
            game_handler.SetCarbon( game_handler.GetCarbon() - resources_requiered.carbon );
            game_handler.SetIron( game_handler.GetIron() - resources_requiered.iron );
            game_handler.SetSilver( game_handler.GetSilver() - resources_requiered.silver );
            game_handler.SetGold( game_handler.GetGold() - resources_requiered.gold );
            game_handler.SetDiamond( game_handler.GetDiamond() - resources_requiered.diamond );
            // Save the game
            game_handler.Save();
        }
    }

    // Function to level up iron generator on a given planet
    public void LvlUpDiamondGeneratorButton() {
        UpgradesManager.ResourcesRequired resources_requiered = upgrades_manager.GetResourcesRequiredDiamond();
        // If the user has the required resources to level up
        if (
            resources_requiered.carbon <= game_handler.GetCarbon() &&
            resources_requiered.iron <= game_handler.GetIron() &&
            resources_requiered.silver <= game_handler.GetSilver() &&
            resources_requiered.gold <= game_handler.GetGold() &&
            resources_requiered.diamond <= game_handler.GetDiamond()
        ) { 
            // Level up
            upgrades_manager.SetDiamondLvl( upgrades_manager.GetDiamondLvl() + 1 );
            // Consume the required resources gathered by the user
            game_handler.SetCarbon( game_handler.GetCarbon() - resources_requiered.carbon );
            game_handler.SetIron( game_handler.GetIron() - resources_requiered.iron );
            game_handler.SetSilver( game_handler.GetSilver() - resources_requiered.silver );
            game_handler.SetGold( game_handler.GetGold() - resources_requiered.gold );
            game_handler.SetDiamond( game_handler.GetDiamond() - resources_requiered.diamond );
            // Save the game
            game_handler.Save();
        }
    }
}
