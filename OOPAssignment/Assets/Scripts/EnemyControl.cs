using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    //enemy speed
    float speed;

	// Use this for initialization
	void Start ()
    {
        //set speed
        speed = 2f;
	}
	
	// Update is called once per frame
	void Update ()
    {
        //get enemy current position
        Vector2 position = transform.position;

        //compute the new position
        position = new Vector2(position.x, position.y - speed * Time.deltaTime);

        //update enemy position
        transform.position = position;

        //bottom left point of screen - control var
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        //if enemy exits on bottom of screen destroy enemy
        if (transform.position.y < min.y)
        {
            Destroy(gameObject);
        }
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        //detect collisions with player ship or player bullets
        if ((col.tag == "PlayerShipTag") || (col.tag == "PlayerBulletTag")) 
        {
            Destroy(gameObject);//destroy enemy ship
        }
    }
}
