using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisibilityManager : MonoBehaviour
{   
    //Private variables
    [ReadOnly] [SerializeField]
    public bool spawned;

    // Start is called before the first frame update
    void Start() { spawned = false; }

    // Visibility on screen managers
    void OnBecameVisible() { spawned = true; }
    void OnBecameInvisible() { spawned = false; }

    // Getter
    public bool GetSpawned() { return spawned; }
}
