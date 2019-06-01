using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    private Vector2 direction;
    private float lastTimeFired;
    public GameObject bulletPrefab;
    
	// Use this for initialization
	void Start () {
        gameObject.transform.position = new Vector2(Random.Range(-3, 3), Random.Range(-2, 3));
        gameObject.AddComponent<Rigidbody2D>();
        direction = new Vector2(Random.Range(-1, 1), Random.Range(1, 1));
        lastTimeFired = Time.time;
    }
	
	// Update is called once per frame
	void Update () {
        var xDirection = 0;
        var yDirection = 0;
        var relativePosition = Camera.main.WorldToScreenPoint((Vector2)gameObject.transform.position);
        var screenThreshold = .3f;
        

        if(relativePosition.x < Screen.width * screenThreshold)
        {
            xDirection = Random.Range(1, 2);
        }
        else if(relativePosition.x > Screen.width * (1 - screenThreshold))
        {
            xDirection = Random.Range(-1, -2);
        }

        if(relativePosition.y > Screen.height * (1 - screenThreshold))
        {
            yDirection = Random.Range(-1, -2);
        }
        else if(relativePosition.y < Screen.height * screenThreshold)
        {
            yDirection = Random.Range(1, 2);
        }

        if(xDirection != 0 && yDirection != 0)
        {
            direction = new Vector2(xDirection, yDirection);
        }

        gameObject.GetComponent<Rigidbody2D>().velocity = direction;
        Debug.Log(relativePosition.x + ", " + relativePosition.y);
        Debug.Log(direction.x + ", " + direction.y);

        if(Time.time - lastTimeFired > 2)
        {
            var bullet = Instantiate(bulletPrefab);
            bullet.name = "Enemy Bullet";
            bullet.transform.position = gameObject.transform.position;
            var rigidBody = bullet.AddComponent<Rigidbody2D>();
            rigidBody.gravityScale = 0;
            rigidBody.velocity = new Vector2(0, -10);
            lastTimeFired = Time.time;
        }

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.name.Contains("Player Bullet"))
        {
            Destroy(this.gameObject);
            Destroy(col.gameObject);
            WorldManager.GetInstance().IncreaseMoney();
        }
    }
}
