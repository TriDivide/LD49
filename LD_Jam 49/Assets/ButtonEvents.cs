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
}
