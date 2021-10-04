using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float movementSpeed = 0f;
    public Rigidbody2D rigidBody;

    public Sprite stationary;
    public Sprite left;
    public Sprite right;

    private SpriteRenderer spriteRenderer; 

    private Vector2 moveDirection;

    void Start() {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    void Update() {
        HandlePlayerInputs();
    }

    void FixedUpdate() {
        MovePlayer();
    }

    private void HandlePlayerInputs() {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        if (spriteRenderer != null) {
            if (moveX < 0) {
                spriteRenderer.sprite = left;
            }
            else if (moveX > 0) {
                spriteRenderer.sprite = right;
            }
            else {
                spriteRenderer.sprite = stationary;
            }
        }
        
        moveDirection = new Vector2(moveX, moveY).normalized;
    }

    private void MovePlayer() {
        rigidBody.velocity = new Vector2(moveDirection.x * movementSpeed, moveDirection.y * movementSpeed);
    }


}
