using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    //enemy prefab
    public GameObject EnemyGo;

    //establish max number of enemies
    public float maxSpawnRateInSeconds = 5f;

	// Use this for initialization
	void Start ()
    {
        Invoke("SpawnEnemy", maxSpawnRateInSeconds);

        //increase spawn rate every 30 seconds
        InvokeRepeating("IncreaseSpawnRate", 0f, 30f);
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    //function to spawn an enemy
    void SpawnEnemy()
    {
        //bottom left point of screen
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        //top right point of screen
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        //instantiate enemy
        GameObject anEnemy = (GameObject)Instantiate(EnemyGo);

        //spawn enemy across top of the screen
        anEnemy.transform.position = new Vector2(Random.Range(min.x, max.x), max.y);

        //schedule enemy spawns
        ScheduleNextEnemySpawn();
    }

    //fucntion to schedule enemy spawn rate
    void ScheduleNextEnemySpawn()
    {
        float spawnInSeconds;

        if (maxSpawnRateInSeconds > 1f)
        {
            //pick a number between 1 and max respawn rate
            spawnInSeconds = Random.Range(1f, maxSpawnRateInSeconds);
        }

        else
            spawnInSeconds = 1f;

        Invoke("SpawnEnemy", spawnInSeconds);
    }

    //function to pregressively increase difficulty
    void IncreaseSpawnRate()
    {
        if (maxSpawnRateInSeconds > 1f)
        {
            maxSpawnRateInSeconds--;
        }

        if (maxSpawnRateInSeconds == 1f)
        {
            CancelInvoke("IncreaseSpawnRate");
        }
    }
}
