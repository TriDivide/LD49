using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthController : MonoBehaviour {

    public double playerHealth = 100;
    public Text healthText;
    public double maxHealth = 100;

    private bool isStable = false;

    private bool hasDied = false;

    private SpriteRenderer spriteRenderer;
    public Sprite blood;
    public int deathWait = 5;

    public void Start() {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    public void FixedUpdate() {
        UpdateHealth();
    }

    public void UpdateHealth() {
        if (!isStable) {
            if(playerHealth > 0) { 
                playerHealth = playerHealth - 0.1;        

                healthText.text = playerHealth.ToString("0") + "%";
            }
            else {
                playerHealth = 0;
                healthText.text = "ah, you dead.";

                if (!hasDied) {
                    AudioSource ac = GetComponent<AudioSource>();
                    ac.Play();
                    hasDied = true;
                    spriteRenderer.sprite = blood;
                    PlayerMovement movementScript = gameObject.GetComponent<PlayerMovement>();
                    Rigidbody2D rigidBody = gameObject.GetComponent<Rigidbody2D>();
                    rigidBody.velocity = new Vector2(0, 0);
                    Destroy(movementScript);
                    Invoke("GameOver", deathWait);
                    
                }
            }
        }
        else {
            if(playerHealth < maxHealth) { 
                playerHealth = playerHealth + 0.5;        

                healthText.text = playerHealth.ToString("0") + "%";
            }
            else {
                playerHealth = maxHealth;
                healthText.text = maxHealth.ToString("0") + "%";
            } 
        }
    }

    public void OnTriggerStay2D(Collider2D collision) {
        if (collision.gameObject.name == "healthZone") {
            isStable = true;   
        }   
    }

    private void GameOver() {
        SceneManager.LoadScene (sceneName:"GameOver");

    }

    public void OnTriggerExit2D(Collider2D collision) {
        if (collision.gameObject.name == "healthZone") {
            isStable = false;
        }
    }


}
