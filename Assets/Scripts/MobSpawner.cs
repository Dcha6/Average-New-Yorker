using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobSpawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject monster;
    public int randomSpawnPoint = 0;
    public int randomMonster;
    //public static bool spawnAllowed;
    public float spawnRate = 1f;

   
    // Start is called before the first frame update
    void Start()
    {
        //spawnAllowed = true;
        InvokeRepeating("SpawnAMonster", 0f, spawnRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnAMonster()
    {
        //if (spawnAllowed)
        //{
        //    randomSpawnPoint = Random.Range(0, spawnPoints.Length);
        //    randomMonster = Random.Range(0, monsters.Length);
        //    Instantiate(monsters[randomMonster], spawnPoints[randomSpawnPoint].position, Quaternion.identity);
        //}

        randomSpawnPoint = Random.Range(0, spawnPoints.Length);
        Instantiate(monster, spawnPoints[randomSpawnPoint].position, Quaternion.identity);
    }

    
}
