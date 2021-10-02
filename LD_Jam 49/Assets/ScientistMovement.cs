using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScientistMovement : MonoBehaviour {

    public Rigidbody2D rigidBody;
    public float movementSpeed = 5f;
    public GameObject player;
    private Vector2 moveDirection;

    private bool isPassive = true;
    private Direction lastMovementDirection;
    public float passiveStationaryDuration = 1f;
    public float passiveMovingDuration = 0.5f;
    private bool doPassiveMove = true; 

    private bool startPassiveMovement = true;

    // Update is called once per frame
    void Update() {
        
    }

    void FixedUpdate() {
        Move();
    }

    void OnTriggerEnter2D(Collider2D collision) {

        isPassive = false;
    }

    void OnTriggerStay2D() {

        float y =  (player.transform.position.y > transform.position.y) ? -1f : 1;
        
        float x = (player.transform.position.x > transform.position.x) ? -1f : 1;
        
        moveDirection = new Vector2(x, y).normalized;
    }

    void OnTriggerExit2D() {

        isPassive = true;
        moveDirection = new Vector2(0, 0);
        startPassiveMovement = true;
    }

    private void Move() {
        if (!isPassive) {
            StopAllCoroutines();
            rigidBody.velocity = new Vector2(moveDirection.x * movementSpeed, moveDirection.y * movementSpeed);
            
        }
        else {
            if (startPassiveMovement) {
                startPassiveMovement = false;
                StartCoroutine(passiveMovement());
            }
        }
    }

    IEnumerator passiveMovement() {
        while ( 1 > 0) {
            float elapsedTime = 0f;
            
            int movement = Random.Range(0, 3);
            Direction lmd = (Direction)movement;

            while (lmd == lastMovementDirection) {
                int m = Random.Range(0, 3);
                print(m);
                lmd = (Direction)m;
                yield return null;
            }

            lastMovementDirection = lmd;

            if (doPassiveMove) {
                switch (lastMovementDirection) {
                    case Direction.Left: { moveDirection = new Vector2(-1, 0).normalized; break; }
                    case Direction.Right: { moveDirection = new Vector2(1, 0).normalized; break; }
                    case Direction.Up: { moveDirection = new Vector2(0, 1).normalized; break; }
                    case Direction.Down: { moveDirection = new Vector2(0, -1).normalized; break; }
                }

                while(elapsedTime < passiveMovingDuration) {
                        rigidBody.velocity = new Vector2(moveDirection.x * movementSpeed, moveDirection.y * movementSpeed);
                        elapsedTime += Time.deltaTime;
                        yield return null;
                }
                doPassiveMove = false;
                
            }
            else {
                while(elapsedTime < passiveStationaryDuration) {
                    rigidBody.velocity = new Vector2(0, 0);
                    elapsedTime += Time.deltaTime;
                    yield return null;
                }
                doPassiveMove = true;
            }

            yield return null;
        }
    } 

}

enum Direction {
    Left = 0,
    Right = 1,
    Up = 2, 
    Down = 3
}
