using UnityEngine;
using System;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(MapGenerator))]
public class MapGeneratorEditor : Editor
{

    public override void OnInspectorGUI()
    {
        MapGenerator mapGen = (MapGenerator)target;

        if (DrawDefaultInspector())
        {
            if (mapGen.autoUpdate)
            {
                mapGen.GenerateMap();
            }
        }

		if (GUILayout.Button("Reorder Regions"))
		{
            Array.Sort(mapGen.regions, delegate (TerrainType x, TerrainType y) { return x.height.CompareTo(y.height); });
		}

        if (GUILayout.Button("Generate"))
        {
            mapGen.GenerateMap();
        }
    }
}
