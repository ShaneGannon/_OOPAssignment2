using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour {

    float speed; 

	// Use this for initialization
	void Start ()
    {
        speed = 8f;
	}
	
	// Update is called once per frame
	void Update ()
    {
        //bullet will move toward top of screen
        //get the bullets current position
        Vector2 position = transform.position;

        //compute the bullets new position
        position = new Vector2(position.x, position.y + speed * Time.deltaTime);

        //update bullet position
        transform.position = position;

        //top right point on screen
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        //if bullet goes above top point on the screen destroy it
        if (transform.position.y > max.y)
        {
            Destroy(gameObject);
        }
	}
}
