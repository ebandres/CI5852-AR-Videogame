using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Starfield : MonoBehaviour
{
    public int starAmount = 100;
    public float rotateSpeed = 1f;
    
    void Start()
    {
        for (int i = 0; i < starAmount; i++)
        {
            Vector3 randomPoint = Random.insideUnitSphere * 10 - new Vector3(20f, 0, 0);
            randomPoint.z = 30f;
            GameObject star = Instantiate(Resources.Load("Prefabs/star", typeof(GameObject)), randomPoint, Quaternion.identity) as GameObject;
            star.transform.parent = gameObject.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward * rotateSpeed * Time.deltaTime);
    }
}
