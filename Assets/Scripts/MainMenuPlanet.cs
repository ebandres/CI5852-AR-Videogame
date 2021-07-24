using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MainMenuPlanet : MonoBehaviour
{   
    // Public variables
    public float rotateSpeed;
    public float minRotateSpeed = 10f;
    public float maxRotateSpeed = 20f;
    // Private variables
    private Vector3 direction;

    void Start()
    {

        rotateSpeed = Random.Range(minRotateSpeed, maxRotateSpeed);
        transform.rotation = Random.rotation;
        direction = Random.insideUnitSphere.normalized;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(direction * rotateSpeed * Time.deltaTime);
    }
}
