using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform gun;
    public Transform shotPoint;
    public GameObject bulletPrefab;
    public GameObject shotMarkerPrefab;
    public LineRenderer laserSight;
    
    private GameObject[] activeMarkers;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion gunRotation = Quaternion.AngleAxis(angle, Vector3.forward);
        gun.rotation = gunRotation;

        laserSight.startColor = Color.red;
        laserSight.endColor = Color.red;

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f;

        laserSight.SetPosition(0, shotPoint.position);
        laserSight.SetPosition(1, mousePos);

        // Debug.DrawRay(shotPoint.position, shotPoint.right * 20f, Color.red);

        if(Input.GetMouseButtonDown(0)) {
            activeMarkers = GameObject.FindGameObjectsWithTag("Marker");
            
            foreach(GameObject marker in activeMarkers) {
                Destroy(marker);
            }

            Instantiate(shotMarkerPrefab, mousePos, Quaternion.identity);
            Instantiate(bulletPrefab, shotPoint.position, shotPoint.rotation);
        }
    }
}
