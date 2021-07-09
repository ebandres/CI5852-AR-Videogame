using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipsProximity : MonoBehaviour
{

    // Private variables
    private float timePassed = 0f;
    private Vector3 distance;
    private List<GameObject> planets;
    private VisibilityManager vis_manager;
    // Public variables
    public GameObject spaceship_prefab;
    public float max_distance_limit = 15f;
    public float spawn_offset = 2f;
    public int spawn_interval = 4;

    // Start is called before the first frame update
    void Start()
    {
        planets = new List<GameObject>( GameObject.FindGameObjectsWithTag("Planet") );
        planets.Remove(gameObject);

        vis_manager = GetComponent<VisibilityManager>();
    }

    // Update is called once per frame
    void Update()
    {   
        // If planets are spawned in game, calculate distance between it and other planets
        if (vis_manager.GetSpawned()){
            foreach (var planet in planets as List<GameObject>) {
                // If planet is close and is spawned
                if ((Vector3.Distance(planet.transform.position, transform.position) <= max_distance_limit) 
                    && planet.GetComponent<VisibilityManager>().GetSpawned()) {
                    // The function that "launches" the spaceships gets called repeately within a given time range
                    timePassed += Time.deltaTime;
                    if(timePassed > Random.Range(spawn_interval-2f, spawn_interval))
                    {
                        CreateSpaceship(planet);
                        timePassed = 0;
                    } 
                }
            }
        }
    }

    // Function that creates a spaceship and assigns its target planet
    void CreateSpaceship(GameObject planet) {

        var spaceship = Instantiate(
            spaceship_prefab,
            new Vector3(
                Random.Range(transform.position.x - spawn_offset, transform.position.x + spawn_offset),          // We do this to create spaceships in different 
                Random.Range(transform.position.y - spawn_offset, transform.position.y + spawn_offset),          // locations on the origin planet
                Random.Range(transform.position.z - spawn_offset, transform.position.z + spawn_offset)           // 
            ), 
            Quaternion.LookRotation(planet.transform.position - transform.position)      // Set the rotation towards target planet
        );
        // Assigns target planet
        spaceship.GetComponent<MoveSpaceship>().target = planet;

    }
}
