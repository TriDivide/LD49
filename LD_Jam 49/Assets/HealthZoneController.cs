using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthZoneController : MonoBehaviour
{

    public void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Player") {
            AudioSource ac = GetComponent<AudioSource>();

            ac.Play();
        }
    }

    public void OnTriggerExit2D(Collider2D collision) {
        if (collision.gameObject.tag == "Player") {
            AudioSource ac = GetComponent<AudioSource>();

            ac.Stop();
        }
    }
}
