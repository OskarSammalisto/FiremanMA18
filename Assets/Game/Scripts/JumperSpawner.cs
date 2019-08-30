using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(GameManager))]  //kräv att det finns en game manager på samma object.
public class JumperSpawner : MonoBehaviour {
    
   
    public GameObject jumperPrefab;

    private float lastSpawnTime;
    
    [Range(0,5)]
    public float spawnDelay = 3.0f;
    [Range(0,2)]
    public float deltaRandomSpawn = 0.5f;

   // private GameManager gameManager;
    
    private float randomSpawnDelay;
    

    private void Start() {
        
        if (jumperPrefab == null) {
            return;
        }

        // gameManager = GetComponent<GameManager>();

        randomSpawnDelay = spawnDelay;
        SpawnJumper();

    }

    private void Update() {
        
        if (Time.time > lastSpawnTime + randomSpawnDelay) {
            SpawnJumper();
        }
    }

    void SpawnJumper() {
        lastSpawnTime = Time.time;
        randomSpawnDelay = Random.Range(spawnDelay - deltaRandomSpawn, spawnDelay + deltaRandomSpawn);
        GameObject jumper = Instantiate(jumperPrefab);

      // JumperController jumperController = jumper.GetComponentInChildren<JumperController>();
     //  jumperController.gameManager = gameManager;

    }

    
}
