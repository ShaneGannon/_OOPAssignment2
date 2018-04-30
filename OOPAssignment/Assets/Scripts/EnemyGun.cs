using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGun : MonoBehaviour
{
    public GameObject EnemyBulletGo;//bullet prefab
	// Use this for initialization
	void Start ()
    {
        //fire an enemy bullet after 1 sec
        Invoke("FireEnemyBullet", 1f);
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    //function to fire an enemy bullet
    void FireEnemyBullet()
    {
        //get a reference to the players ship
        GameObject playerShip = GameObject.Find("PlayerGo");

        if (playerShip != null)//if player isnt dead
        {
            //instantiate an enemy bullet
            GameObject bullet = (GameObject)Instantiate(EnemyBulletGo);

            //set bullets initial position
            bullet.transform.position = transform.position;

            //Compute bullets direction towards player's ship
            Vector2 diretion = playerShip.transform.position - bullet.transform.position;

            //set bullets direction
            bullet.GetComponent<EnemyBullet>().SetDirection(diretion);
        }
    }
}
