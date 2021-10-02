using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScientistMovement : MonoBehaviour {

    public Rigidbody2D rigidBody;
    public float movementSpeed = 5f;
    public GameObject player;
    private Vector2 moveDirection;



    // Update is called once per frame
    void Update() {
        
    }

    void FixedUpdate() {
        Move();
    }

    private void HandlePlayerPosition() {

    }

    private void Move() {
        rigidBody.velocity = new Vector2(moveDirection.x * movementSpeed, moveDirection.y * movementSpeed);
    }
}
