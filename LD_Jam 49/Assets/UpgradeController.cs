using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeController : MonoBehaviour {
    public float upgradePoints = 0f;

    public Text upgradeText;

    public Text warningText;

    public Text enhanceNotificationText;
    
    public Button upgradeButton;
    private bool touchingHealthZone = false;

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.collider.gameObject.tag == "Scientist") {
            upgradePoints += 0.2f;
        }
    }

    void FixedUpdate() {
        upgradeText.text = "DNA Aquired: " + upgradePoints.ToString("0");

        if (upgradePoints >= 5) {
            enhanceNotificationText.gameObject.SetActive(!touchingHealthZone);

        }
    }

    void OnTriggerStay2D(Collider2D collider) {
        if(collider.gameObject.tag == "HealthZone") {
            touchingHealthZone = true;
            if (upgradePoints >= 5) {
                enhanceNotificationText.gameObject.SetActive(false);
                warningText.gameObject.SetActive(true);
                upgradeButton.gameObject.SetActive(true);
            }
            else {
                enhanceNotificationText.gameObject.SetActive(false);
                warningText.gameObject.SetActive(false);
                upgradeButton.gameObject.SetActive(false);
            }
        }
    }

    void OnTriggerExit2D(Collider2D collider) {
        if (collider.gameObject.tag == "HealthZone") {
            touchingHealthZone = false;
            if (upgradePoints >= 5) {
                enhanceNotificationText.gameObject.SetActive(true);
                warningText.gameObject.SetActive(false);
                upgradeButton.gameObject.SetActive(false);
            }
            else {
                enhanceNotificationText.gameObject.SetActive(false);
                warningText.gameObject.SetActive(false);
                upgradeButton.gameObject.SetActive(false);
            }
        }
    }


}
