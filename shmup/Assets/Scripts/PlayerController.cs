﻿using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public Transform bullet;

    Rigidbody2D rigidbody2d;
    public float speedScalar;

    Vector2 screenBounds;

	void Start() {
	    rigidbody2d = GetComponent<Rigidbody2D>();

        Vector3 upperCorner = new Vector3(Screen.width, Screen.height, 0.0f);
        Vector3 worldCorner = Camera.main.ScreenToWorldPoint(upperCorner);
        screenBounds = new Vector2(worldCorner.x, worldCorner.y);
	}
	
	void FixedUpdate() {
	    float hMovement = Input.GetAxis("Horizontal");
	    float vMovement = Input.GetAxis("Vertical");
        rigidbody2d.velocity = new Vector2(hMovement * speedScalar, vMovement * speedScalar);

        float xPos = Mathf.Clamp(rigidbody2d.position.x, -screenBounds.x, screenBounds.x);
        float yPos = Mathf.Clamp(rigidbody2d.position.y, -screenBounds.y, screenBounds.y);
        rigidbody2d.position = new Vector2(xPos, yPos);
	}

    void Update() {
        if(Input.GetKeyDown("space")) {
            ShootBullet();
        }
    }

    void ShootBullet() {
        Vector3 yOffset = new Vector3(0.0f, 0.5f, 0.0f);
        Instantiate(bullet, transform.position - yOffset, transform.rotation);
        Instantiate(bullet, transform.position + yOffset, transform.rotation);
    }
}
