using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public GameObject PlayerBulletGo;//players bullet prefab
    public GameObject BulletPosition01;
    public GameObject BulletPosition02;

    public float speed;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        //fire bullet when spacebar is pressed
        if (Input.GetKeyDown("space"))
        {
            //instantiate the first bullet object
            GameObject bullet01 = (GameObject)Instantiate(PlayerBulletGo);
            //set bullet initial position
            bullet01.transform.position = BulletPosition01.transform.position;

            //instantiate the second bullet object
            GameObject bullet02 = (GameObject)Instantiate(PlayerBulletGo);
            //set bullet initial position
            bullet02.transform.position = BulletPosition02.transform.position;
        }

        float x = Input.GetAxisRaw("Horizontal");//value will be -1, 0, 1(left no imput and right)
        float y = Input.GetAxisRaw("Vertical");//value will be -1, 0, 1(down no input and up)

        //compute a directional vector based on input, normalize to get a unit vector
        Vector2 direction = new Vector2(x, y).normalized;

        //call function to compute and set players position
        Move(direction);
    }

    //create move function
    void Move(Vector2 directioin)
    {
        //find the screen limits to the players movement(left right top and bottom)
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));//bottom left corner
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));//top right corner

        //take into account width and height of player ship
        max.x = max.x - 0.225f;//subtract the player sprites half width
        min.x = min.x + 0.225f;//add the player sprite half width

        max.y = max.y - 0.285f;//subtract the player sprite half height
        max.y = max.y + 0.285f;//add the player sprite half height

        //get the plkayers current position
        Vector2 pos = transform.position;

        //calculate new position
        pos += directioin * speed * Time.deltaTime;

        //ensure new pos is within screen limits
        pos.x = Mathf.Clamp(pos.x, min.x, max.x);
        pos.y = Mathf.Clamp(pos.y, min.y, max.y);

        //update player position
        transform.position = pos;
    }
}
