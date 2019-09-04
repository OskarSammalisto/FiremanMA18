using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(GameManager))]  //kräv att det finns en game manager på samma object.
public class JumperSpawner : MonoBehaviour {
    
   
    public GameObject jumperPrefab;

    private float lastSpawnTime;
    private bool stop = false;
    private List<GameObject> jumpers = new List<GameObject>();
    
    [Range(0,5)]
    public float spawnDelay = 3.0f;
    [Range(0,2)]
    public float deltaRandomSpawn = 0.5f;

    
    
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
        
        if (!stop && Time.time > lastSpawnTime + randomSpawnDelay) {
            SpawnJumper();
        }
    }

    void SpawnJumper() {
        lastSpawnTime = Time.time;
        randomSpawnDelay = Random.Range(spawnDelay - deltaRandomSpawn, spawnDelay + deltaRandomSpawn);
        GameObject jumper = Instantiate(jumperPrefab);
        
        jumpers.Add(jumper);
        JumperController jumperController = jumper.GetComponentInChildren<JumperController>();
        jumperController.jumperSpawner = this;

    }

    public void DestroyJumper(GameObject jumper) {
        
        // ta bort jumper från listan
        jumpers.Remove(jumper);
        
        //destroy jumper
        Destroy(jumper);
    }

    public void Stop() {
        stop = true;
        
        //gå igenom listan av jumpers och Destroy
        for (int i = jumpers.Count - 1; i >= 0; i--) {
           DestroyJumper(jumpers[i]);
        }
        
//        foreach (var VARIABLE in jumpers) {
//            jumpers.Remove(VARIABLE);
//            Destroy(VARIABLE);
//        }
    }
    
}
