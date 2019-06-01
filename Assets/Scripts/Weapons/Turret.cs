using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {
    private WorldManager worldManager;
    public GameObject bulletPrefab;

	// Use this for initialization
	void Start () {
        worldManager = WorldManager.GetInstance();
    }
	
	// Update is called once per frame
	void Update () {
        if(!worldManager.inBattleMode)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            var wolrdMousePosition = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
            var position = gameObject.transform.position;
            var baseVelocity = 10f;
            var direction = (Vector2)(wolrdMousePosition - gameObject.transform.position);
            direction.Normalize();
            var velocity = direction * baseVelocity;

            GameObject bullet = Instantiate(bulletPrefab);
            bullet.name = "Player Bullet";
            bullet.transform.position = gameObject.transform.position;
            var rigidbody = bullet.AddComponent<Rigidbody2D>();
            rigidbody.gravityScale = 0;
            rigidbody.AddForce(velocity, ForceMode2D.Impulse);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name.Contains("Enemy Bullet"))
        {
            Destroy(gameObject);
        }
    }
}
