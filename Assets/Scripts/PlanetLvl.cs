using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetLvl : MonoBehaviour
{
    public HumanityManager planetHumanity;
    public TextAsset planetJson;
    public ParticleSystem particles;
    public int planetLevel = 0;

    // Make sure the amount of levels is equal or higher than r.levels.Length in the inspector (check JSON)
    public int[] levels = new int[] { 10000, 100000, 250000, 500000, 750000, 1000000, 1500000 };
    private MapGenerator mg;
    private RegionLevels rl;

    void Start()
    {
        mg = GetComponent<MapGenerator>();

        rl = JsonUtility.FromJson<RegionLevels>(planetJson.text);
        mg.regions = rl.levels[0].regions;
        mg.GenerateMap();

    }

    // Update is called once per frame
    void Update()
    {
        if (planetLevel < rl.levels.Length - 1 && planetHumanity.GetHumanity() > levels[planetLevel])
        {
            planetLevel += 1;
            changePlanetLevel(planetLevel);
            particles.Play();
        }
    }

    void changePlanetLevel(int lvl)
    {
        mg.regions = rl.levels[lvl].regions;
        mg.GenerateMap();
    }
}
