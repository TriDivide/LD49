using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float movementSpeed = 0f;
    public Rigidbody2D rigidBody;

    private Vector2 moveDirection;


    void Update() {
        HandlePlayerInputs();
    }

    void FixedUpdate() {
        MovePlayer();
    }

    private void HandlePlayerInputs() {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(moveX, moveY).normalized;
    }

    private void MovePlayer() {
        rigidBody.velocity = new Vector2(moveDirection.x * movementSpeed, moveDirection.y * movementSpeed);
    }


}
