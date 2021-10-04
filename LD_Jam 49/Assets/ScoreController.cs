using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreController : MonoBehaviour {
    
    public int score = 0;

    public Text scoreText;

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.collider.gameObject.tag == "Scientist") {
            score += 1;
            
            scoreText.text = "Scientists dealt with: " + score.ToString("0");
        }
    }
}
