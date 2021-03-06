﻿using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float speed;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");

        Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();

        rigidbody.velocity = new Vector3(horizontal, vertical, 0.0f) * speed;
	
        if(Input.GetKeyDown("space"))
            BroadcastMessage("fire", null, SendMessageOptions.DontRequireReceiver);
	}

    void died()
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
            BroadcastMessage("died", null, SendMessageOptions.DontRequireReceiver);
            other.gameObject.BroadcastMessage("died", null, SendMessageOptions.DontRequireReceiver);
    }
}
