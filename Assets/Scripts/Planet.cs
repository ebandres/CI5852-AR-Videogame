using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    public float rotateSpeed;
    private Vector3 direction;
    public float minRotateSpeed = 10f;
    public float maxRotateSpeed = 20f;


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
