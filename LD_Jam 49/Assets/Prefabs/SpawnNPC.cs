using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnNPC : MonoBehaviour
{

    public GameObject spawnObject;
    public string tagRef;
    public int maxNumberInScene = 10;
    private int npcsInScene = 0;

    

    // Start is called before the first frame update
    void Start() {
        InvokeRepeating("Spawn", 30f, 30f);
    }

    // Update is called once per frame
    void Update() {
        
    }

    void FixedUpdate() {
        if (tagRef != null) {
            npcsInScene = GameObject.FindGameObjectsWithTag(tagRef).Length;
        }
    }

    private void Spawn() {
        if (npcsInScene <= 30) {
            Instantiate(spawnObject, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
        }
    }
    
}
