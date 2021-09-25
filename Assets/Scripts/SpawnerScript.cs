using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    public GameObject enemy;
    float randY;
    Vector2 whereToSpawn;
    public float spawnRate = 2f;
    float nextSpawn = 0.0f;
    public float upBoundary;
    public float lowBoundary;
    public float spawnX;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            randY = Random.Range(lowBoundary, upBoundary);
            whereToSpawn = new Vector2(spawnX , randY);
            Instantiate(enemy, whereToSpawn, Quaternion.identity);
        }
    }
}
