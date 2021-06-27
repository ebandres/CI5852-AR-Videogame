using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    public float rotateSpeed;
    private Vector3 direction;

    void Start()
    {
        rotateSpeed = Random.Range(10f, 20f);
        transform.rotation = Random.rotation;
        direction = Random.insideUnitSphere.normalized;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(direction * rotateSpeed * Time.deltaTime);
    }
}
