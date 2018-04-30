using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    float speed;//bullet speed
    Vector2 _direction;//bullet direction
    bool isReady;//to know when bullet direction is set

    //set default values in awake function
    void Awake()
    {
        speed = 5f;
        isReady = false;
    }

    // Use this for initialization
    void Start ()
    {
		
	}

    //function to set bullet direction
    public void SetDirection(Vector2 direction)
    {
        //set direction normalized to get a unit vector
        _direction = direction.normalized;

        //set flag to true
        isReady = true;
    }

	// Update is called once per frame
	void Update ()
    {
        if (isReady)
        {
            //get bullets current position
            Vector2 position = transform.position;

            //compute new position
            position += _direction * speed * Time.deltaTime;

            //update bullet position
            transform.position = position;

            //destroy bullet if it goes outside screen boundaries

            //bottom left of screen
            Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
            //top right of screen
            Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

            //destroy bullet if outside
            if ((transform.position.x < min.x) || (transform.position.x > max.x) || 
                (transform.position.y < min.y) || (transform.position.y > max.y))
            {
                Destroy(gameObject);
            }
        }
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        //detect collisions of the enemy bullets with the player ship
        if (col.tag == "PlayerShipTag")
        {
            Destroy(gameObject);//destroy bullet
        }
    }
}
