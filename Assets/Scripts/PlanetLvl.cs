using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetLvl : MonoBehaviour
{
    public HumanityManager planetHumanity;
    public TextAsset planetJson;
    public int planetLevel = 0;
    public int[] levels = new int[] {100, 1000, 10000};
    private MapGenerator mg;
    private RegionLevels rl;
    public float tt = 0f;
    public int curr_lvl = 0;

    void Start()
    {
        mg = GetComponent<MapGenerator>();

        rl = JsonUtility.FromJson<RegionLevels>(planetJson.text);
        mg.regions = rl.levels[0].regions;
    }

    // Update is called once per frame
    void Update()
    {
        if (curr_lvl < rl.levels.Length - 1)
        {
            tt += Time.deltaTime;
            if (tt >= 5f) {
                tt = 0f;
                curr_lvl += 1;
                changePlanetLevel(curr_lvl);
            }
        }
    }

    void changePlanetLevel(int lvl)
    {
        mg.regions = rl.levels[lvl].regions;
        mg.GenerateMap();
    }
}
