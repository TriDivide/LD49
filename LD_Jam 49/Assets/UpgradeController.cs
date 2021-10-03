using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeController : MonoBehaviour {
    public float upgradePoints = 0f;

    public Text upgradeText;

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.collider.gameObject.tag == "Scientist") {
            upgradePoints += 0.2f;
            
            upgradeText.text = upgradePoints.ToString("0");
        }
    }
}
