using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillNPC : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject blood;

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.collider.GetType() == typeof(BoxCollider2D) && collision.collider.gameObject.tag == "Player") {
            GameObject newBlood = Instantiate(blood, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.Euler(0, 0, Random.Range(0, 365)));
            Destroy(gameObject);
        }
    }
}
