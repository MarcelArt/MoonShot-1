using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rb;

    public float speed;
    public GameObject trajectoryMarker;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.right * speed, ForceMode2D.Impulse);
        StartCoroutine(placeMarkers());
        Destroy(gameObject, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator placeMarkers() {
        while(true) {
            yield return new WaitForSeconds(.1f);
            Instantiate(trajectoryMarker, transform.position, Quaternion.identity);
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Planet") {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Target") {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
