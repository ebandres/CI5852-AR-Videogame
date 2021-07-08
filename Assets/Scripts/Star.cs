using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    private float twinkleTime;
    private Color color1;
    private Color color2;
    private SpriteRenderer sr;

    void Start()
    {
        twinkleTime = Random.value / 5;
        if (Random.value > 0.5f)
        {
            color1 = Color.white;
            color2 = Color.gray;
        }
        else
        {
            color1 = Color.gray;
            color2 = Color.white;
        }

        sr = GetComponent<SpriteRenderer>();
        sr.color = color1;
    }

    // Update is called once per frame
    void Update()
    {
        sr.color = Color.Lerp(sr.color, color2, twinkleTime);

        if (sr.color == color2)
        {
            Color tmp = color1;
            color1 = color2;
            color2 = tmp;

            twinkleTime = Random.value / 5;
        }
    }
}