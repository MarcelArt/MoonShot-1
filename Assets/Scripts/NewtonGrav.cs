using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewtonGrav : MonoBehaviour
{
    private const float G = 66f;
    private Rigidbody2D rb;
    private Collider2D celestialObject;

    public float radius;
    public LayerMask bulletLayer;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        celestialObject = Physics2D.OverlapCircle(transform.position, radius, bulletLayer);
        if(celestialObject != null) {
            attract(celestialObject.GetComponent<Rigidbody2D>());
        }
    }

    private void FixedUpdate() {
        // Rigidbody2D[] rbToAttracts = FindObjectsOfType<Rigidbody2D>();

        // foreach(Rigidbody2D rbToAttract in rbToAttracts) {
        //     if(rbToAttract != rb) {
        //         attract(rbToAttract);
        //     }
        // }
    }

    public void attract(Rigidbody2D rbToAttract) {
        Vector2 direction = rb.position - rbToAttract.position;
        float distance = direction.magnitude;

        float forceMagnitude = G * (rb.mass * rbToAttract.mass) / Mathf.Pow(distance, 2);
        Vector2 force = direction.normalized * forceMagnitude;

        rbToAttract.AddForce(force);
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
