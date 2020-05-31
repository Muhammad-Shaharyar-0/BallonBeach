using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject player;
    public GameObject[] trianglePrefebs;
    public GameObject[] VegetationPrefebs;
    private Vector3 spawnLocation;
    private int TriangleSpawned;
    int XaxisofTree;
   
    // Update is called once per frame
    void Update()
    {
        float DistanceToHorizon = Vector3.Distance(player.gameObject.transform.position, spawnLocation);
        if(DistanceToHorizon<120)
        {
           
            SpawnTriangles();
            SpawnVegetation();
        }
    }
    void SpawnTriangles()
    {
      
        
        spawnLocation = new Vector3(0, 0, spawnLocation.z + 40);
        TriangleSpawned = Random.Range(0, trianglePrefebs.Length);
        Instantiate(trianglePrefebs[TriangleSpawned], spawnLocation, Quaternion.identity);
    }
    void SpawnVegetation()
    {
       
        spawnLocation = new Vector3(0, -0.61f, spawnLocation.z + 20);
        Instantiate(VegetationPrefebs[Random.Range(0, VegetationPrefebs.Length)], spawnLocation, Quaternion.identity);
    }
}
