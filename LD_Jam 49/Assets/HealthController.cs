using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthController : MonoBehaviour {

    public double playerHealth = 100;
    public Text healthText;

    private bool isStable = false;

    private bool hasDied = false;

    private SpriteRenderer spriteRenderer;
    public Sprite blood;

    public void Start() {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    public void Update() {
        UpdateHealth();
    }

    public void UpdateHealth() {
        if (!isStable) {
            if(playerHealth > 0) { 
                playerHealth = playerHealth - 0.01;        

                healthText.text = playerHealth.ToString("0");
            }
            else {
                playerHealth = 0;
                healthText.text = "ah, you dead.";

                if (!hasDied) {
                    hasDied = true;
                        spriteRenderer.sprite = blood;
                        PlayerMovement movementScript = gameObject.GetComponent<PlayerMovement>();
                        Destroy(movementScript);
                        Invoke("GameOver", 10);
                    
                }
            }
        }
        else {
            if(playerHealth < 100) { 
                playerHealth = playerHealth + 0.1;        

                healthText.text = playerHealth.ToString("0");
            }
            else {
                playerHealth = 100;
                healthText.text = "100";
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
