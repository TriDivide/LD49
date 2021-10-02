using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour {

    public double playerHealth = 100;
    public Text healthText;

    private bool isStable = false;

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

    public void OnTriggerExit2D(Collider2D collision) {
        if (collision.gameObject.name == "healthZone") {
            isStable = false;
        }
    }


}
