using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowDestination : MonoBehaviour
{
    GameObject[] destinations;
    private Transform destination;
    public float speed = 5.0f;
    private GameObject player;
    
    // Start is called before the first frame update
    void Start()
    {
        destinations = GameObject.FindGameObjectsWithTag("Waypoint");
        player = GameObject.FindGameObjectWithTag("Player");

        destination = destinations[Random.Range(0, destinations.Length)].transform;
    }

    // Update is called once per frame
    void Update()
    {
        // Translation
        float space = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, destination.position, space);

        // Rotation
        
        Vector3 targetDirection = destination.position - transform.position;
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, space, 0);
        
        Debug.DrawRay(transform.position, newDirection, Color.red);
        transform.rotation = Quaternion.LookRotation(newDirection);
    }
}
