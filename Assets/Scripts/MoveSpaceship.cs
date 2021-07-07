using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSpaceship : MonoBehaviour
{
    // Public variables
    public GameObject target;
    public int speed = 15;

    // Update is called once per frame
    void Update()
    {   
        // The spaceship moves towards target position (and updates the rotation)
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
        transform.LookAt(target.transform);
        // If the spaceship gets to the target position, it gets destroyed
        if (Vector3.Distance(transform.position, target.transform.position) < 2)
        {
            Destroy(gameObject);
        }
    }
}
