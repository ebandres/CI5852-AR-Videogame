using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Planet : MonoBehaviour
{   
    // Public variables
    public float rotateSpeed;
    public float minRotateSpeed = 10f;
    public float maxRotateSpeed = 20f;
    // Private variables
    private GameObject menu;
    private Vector3 direction;
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
        menu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(direction * rotateSpeed * Time.deltaTime);
        
        // When a click is made on screen, we cast a ray from the camera to the direction of the click
        if (Input.GetMouseButtonDown(0)) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            // If the ray hit the GameObject Planet that has this script attached, we show its menu
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.name == gameObject.transform.name)
                {
                    menu.SetActive(true);
                }
            }
            // If the ray didn't hit any GameObject, and the pointer isn't on any UI element, we hide the menu
            else if (!IsPointerOverUIObject()) {
                menu.SetActive(false);
            }
        }

        if (gameObject.tag != "Cloud") {
            // If planet gets despawned and the menu was active, we hide its menu
            if (!vis_manager.GetSpawned() && menu.activeSelf) {
                menu.SetActive(false);
            }
        }
    }

    // Cast a ray to test if Input.mousePosition is over any UI object in EventSystem.current
    private bool IsPointerOverUIObject() {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
    
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
    }
}
