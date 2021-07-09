using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{   
    // Public variables
    public float rotateSpeed;
    public float minRotateSpeed = 10f;
    public float maxRotateSpeed = 20f;
    // Private variables
    private GameObject menu;
    private Vector3 direction;
    private bool active = false;
    private VisibilityManager vis_manager;

    void Start()
    {

        rotateSpeed = Random.Range(minRotateSpeed, maxRotateSpeed);
        transform.rotation = Random.rotation;
        direction = Random.insideUnitSphere.normalized;

        // Get gameObject that will be clamped with the menu HUD        
        if (gameObject.tag == "Cloud") {
            menu = GameObject.Find(gameObject.transform.parent.gameObject.name + " Menu").GetComponent<ClampPlanetMenu>().menu_hud.gameObject;
        }
        else {
            menu = GameObject.Find(gameObject.name + " Menu").GetComponent<ClampPlanetMenu>().menu_hud.gameObject;
            vis_manager = GetComponent<VisibilityManager>();
        }
        // Hide menu HUD when starting game
        menu.SetActive(active);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(direction * rotateSpeed * Time.deltaTime);
        
        /*
        if (Input.touchCount > 0) {
            Touch touch = Input.GetTouch(0);
            Debug.Log(touch.phase);
        }*/

        if (gameObject.tag != "Cloud") {
            // If planet gets despawned and the menu HUD was active, we hide the menu HUD
            if (!vis_manager.GetSpawned() && menu.activeSelf) {
                active = false;
                menu.SetActive(active);
            }
        }
    }

    // IMPORTANT: We are using this to test on PC, on mobile we use Touch Controls
    void OnMouseDown() {
        active = !active;
        menu.SetActive(active);
    }
}
