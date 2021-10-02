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

    void OnTriggerStay2D() {

        float y =  (player.transform.position.y > transform.position.y) ? -1f : 1;
        
        float x = (player.transform.position.x > transform.position.x) ? -1f : 1;
        
        moveDirection = new Vector2(x, y).normalized;
    }

    void OnTriggerExit2D() {
        moveDirection = new Vector2(0, 0);
    }

    private void Move() {
        rigidBody.velocity = new Vector2(moveDirection.x * movementSpeed, moveDirection.y * movementSpeed);
    }
}
