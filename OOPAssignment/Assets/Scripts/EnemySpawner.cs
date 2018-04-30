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

    }

}
