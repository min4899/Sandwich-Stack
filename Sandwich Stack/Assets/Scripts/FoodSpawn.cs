using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawn : MonoBehaviour
{
    public Sandwich sandwich;
    public GameObject food; // future: replace with food array
    public float spawnRate;
    public float offsetHeight;

    private float currentHeight;
    private float nextSpawn;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (food != null && Time.time > nextSpawn)
        {
            // future: choose a random ingredient to spawn 
            nextSpawn = Time.time + spawnRate;
            currentHeight = offsetHeight + sandwich.height;
            Vector3 spawnPosition = new Vector3(Random.Range(1.0f, 9.0f), currentHeight, Random.Range(1.0f, 9.0f));
            Instantiate(food, spawnPosition, Quaternion.identity);
        }
    }
}
