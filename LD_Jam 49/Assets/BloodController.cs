using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodController : MonoBehaviour
{


    // Start is called before the first frame update
    void Start() {
        AudioSource splatter = GetComponent<AudioSource>();

        splatter.Play();    

        Invoke("Kill", 10f);
    }

    private void Kill() {
        Destroy(gameObject);
    }

}
