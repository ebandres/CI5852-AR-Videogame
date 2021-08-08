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
        GameHandler game_handler = gh.GetComponent<GameHandler>();

        game_handler.SetCarbon(game_handler.GetCarbon() + planet_generator.GatherCarbon());
        game_handler.SetIron(game_handler.GetIron() + planet_generator.GatherIron());
        game_handler.SetSilver(game_handler.GetSilver() + planet_generator.GatherSilver());
        game_handler.SetGold(game_handler.GetGold() + planet_generator.GatherGold());
        game_handler.SetDiamond(game_handler.GetDiamond() + planet_generator.GatherDiamond());
        game_handler.Save();
    }
}
