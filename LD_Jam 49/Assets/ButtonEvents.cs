using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonEvents : MonoBehaviour
{

    public Text health;

    public void exitGame() {
        Application.Quit();
    }

    public void restartGame() {
        SceneManager.LoadScene (sceneName:"SampleScene");
    }

    public void startGame() {
        SceneManager.LoadScene (sceneName: "SampleScene");
    }

    public void DoUpgradeSpeed() {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        UpgradeController s = player.GetComponent<UpgradeController>();

        Color unstableHealth = new Color(255, 69, 69);

        if (s.upgradePoints >= 5) {
            print("unstableHealth");
            health.color = unstableHealth; 
            s.upgradePoints -= 5;

            PlayerMovement m = player.GetComponent<PlayerMovement>();
            m.movementSpeed += 1;

            HealthController h = player.GetComponent<HealthController>();
            h.maxHealth -= 10;
        }
    }
}
