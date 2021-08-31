using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatherButtonHandler : MonoBehaviour
{
    public GameObject planet;
    private GameObject gh;

    void Start()
    {
        gh = GameObject.Find("Game Handler");
    }

    public void GatherResources() 
    {
        ResourceGenerator planet_generator = planet.GetComponent<ResourceGenerator>();
        ResourcesGatheredManager game_handler_resource_gathered = gh.GetComponent<ResourcesGatheredManager>();
        SaveHandler game_handler_save = gh.GetComponent<SaveHandler>();

        game_handler_resource_gathered.SetCarbon(game_handler_resource_gathered.GetCarbon() + planet_generator.GatherCarbon());
        game_handler_resource_gathered.SetIron(game_handler_resource_gathered.GetIron() + planet_generator.GatherIron());
        game_handler_resource_gathered.SetSilver(game_handler_resource_gathered.GetSilver() + planet_generator.GatherSilver());
        game_handler_resource_gathered.SetGold(game_handler_resource_gathered.GetGold() + planet_generator.GatherGold());
        game_handler_resource_gathered.SetDiamond(game_handler_resource_gathered.GetDiamond() + planet_generator.GatherDiamond());
        game_handler_save.Save();
    }
}
