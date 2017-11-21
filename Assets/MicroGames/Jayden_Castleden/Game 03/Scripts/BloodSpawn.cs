using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodSpawn : MonoBehaviour {

    public GameObject bloodPrefab; // Prefab of Blood    
    public float spawnRate = 1f; // Rate of spawn
    public float spawnRadius = 1f; // Radius of spawn

    // Visualization code
    void OnDrawGizmos()
    {
        Gizmos.color = Color.black;
        // Draw a sphere to indicate the spawn radius
        Gizmos.DrawWireSphere(transform.position, spawnRadius);
    }

    void Spawn()
    {
        // LET clone = new instance of aiAgentPrefab
        GameObject clone = Instantiate(bloodPrefab);
        //Let rand = Random Inside Unit Sphere
        Vector3 rand = Random.insideUnitSphere;
        // SET rand.y = 0
        rand.y = 0;
        // SET clone's position to transform's position + rand x spawnRadius
        clone.transform.position = transform.position + rand * spawnRadius;     
        
    }

    // Use this for initialization
    void Start()
    {
        InvokeRepeating("Spawn", 0, spawnRate);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
