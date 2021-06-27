using UnityEngine;
using System.Collections;

public class MapGenerator : MonoBehaviour
{

    public enum DrawMode { NoiseMap, ColourMap };
    public DrawMode drawMode;

    public int mapWidth;
    public int mapHeight;
    public float noiseScale;

    public int octaves;
    [Range(0, 1)]
    public float persistance;
    public float lacunarity;

    public int seed;
    public int size;
    public Vector2 offset;
    private float offsetTargetX;
    private float offsetTargetY;
    public bool isCloud = false;
    [Range(0f, 0.0001f)]
    public float cloudSpeed = 0.0001f;

    public bool autoUpdate;

    public TerrainType[] regions;

    private void Start()
    {
        seed = Random.Range(-1000000, 1000000);
        offset.x = Random.Range(-10000f, 10000f);
        offset.y = Random.Range(-10000f, 10000f);
        GenerateMap();

        // Cloud stuff
        offsetTargetX = Random.Range(-1000f, 1000f);
        offsetTargetY = Random.Range(-1000f, 1000f);
    }

    private void Update()
    {
        if (isCloud) 
        {
            offset.x = Mathf.Lerp(offset.x, offsetTargetX, cloudSpeed * Time.deltaTime);
            offset.y = Mathf.Lerp(offset.y, offsetTargetY, cloudSpeed * Time.deltaTime);
            GenerateMap();

            if (Mathf.Abs(offset.x - offsetTargetX) < 5)
            {
                offsetTargetX = Random.Range(-1000f, 1000f);
            }

            if (Mathf.Abs(offset.y - offsetTargetY) < 5)
            {
                offsetTargetY = Random.Range(-1000f, 1000f);
            }
        }
    }

    public void GenerateMap()
    {
        float[,] noiseMap = Noise.GenerateNoiseMap(mapWidth, mapHeight, seed, noiseScale, octaves, persistance, lacunarity, offset);

        float halfWidth = mapWidth / 2f;
        float halfHeight = mapHeight / 2f;

        Color[] colourMap = new Color[mapWidth * mapHeight];
        for (int y = 0; y < mapHeight; y++)
        {
            for (int x = 0; x < mapWidth; x++)
            {
                float distance_x = Mathf.Abs(x - halfWidth);
                float distance_y = Mathf.Abs(y - halfHeight);
                //float distance = Mathf.Sqrt(distance_x * distance_x + distance_y * distance_y); // circular mask
                float distance = Mathf.Max(distance_x, distance_y); // square mask

                float max_width = size * 0.5f - 10.0f;
                float delta = distance / max_width;
                float gradient = delta * delta;

                noiseMap[x, y] *= Mathf.Max(0.0f, 1.0f - gradient);

                float currentHeight = noiseMap[x, y];
                for (int i = 0; i < regions.Length; i++)
                {
                    if (currentHeight <= regions[i].height)
                    {
                        colourMap[y * mapWidth + x] = regions[i].colour;
                        break;
                    }
                }
            }
        }

        MapDisplay display = GetComponent<MapDisplay>();
        if (drawMode == DrawMode.NoiseMap)
        {
            display.DrawTexture(TextureGenerator.TextureFromHeightMap(noiseMap));
        }
        else if (drawMode == DrawMode.ColourMap)
        {
            display.DrawTexture(TextureGenerator.TextureFromColourMap(colourMap, mapWidth, mapHeight));
        }
    }

    void OnValidate()
    {
        if (mapWidth < 1)
        {
            mapWidth = 1;
        }
        if (mapHeight < 1)
        {
            mapHeight = 1;
        }
        if (lacunarity < 1)
        {
            lacunarity = 1;
        }
        if (octaves < 0)
        {
            octaves = 0;
        }
    }
}

[System.Serializable]
public struct TerrainType
{
    public string name;
    public float height;
    public Color colour;
}