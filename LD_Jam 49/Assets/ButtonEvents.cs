using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonEvents : MonoBehaviour
{

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

        if (s.upgradePoints >= 5) {
            s.upgradePoints -= 5f;

            PlayerMovement m = player.GetComponent<PlayerMovement>();
            m.movementSpeed += 1;

            HealthController h = player.GetComponent<HealthController>();
            h.maxHealth -= 10;
        }
    }
}
