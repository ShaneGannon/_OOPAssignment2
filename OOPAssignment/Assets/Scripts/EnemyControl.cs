using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    GameObject scoreUITextGo;//reference to UI score text

    public GameObject ExplosionGo;//explosion prefab

    //enemy speed
    float speed;

	// Use this for initialization
	void Start ()
    {
        //set speed
        speed = 2f;

        //get the score text UI
        scoreUITextGo = GameObject.FindGameObjectWithTag("ScoreTextTag");
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
            PlayExplosion();

            //add 100 points to score
            scoreUITextGo.GetComponent< GameScore > ().Score += 100;

            Destroy(gameObject);//destroy enemy ship
        }
    }

    //function to instatiate explosion
    void PlayExplosion()
    {
        GameObject explosion = (GameObject)Instantiate(ExplosionGo);

        //set position of explosion to ship position
        explosion.transform.position = transform.position;
    }
}
