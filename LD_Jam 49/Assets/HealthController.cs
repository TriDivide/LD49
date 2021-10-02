using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour {

    public double playerHealth = 100;
    [SerializeField] private Text healthText;


    public void Update() {
        UpdateHealth();
    }

    public void UpdateHealth() {
        if(playerHealth > 0) { 
            playerHealth = playerHealth - 0.01;        

            healthText.text = playerHealth.ToString("0");
        }
        else {
            playerHealth = 0;
            healthText.text = "ah, you dead.";
        }
    }

}
