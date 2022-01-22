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
        destinations = GameObject.FindGameObjectsWithTag("Waypoints");
        player = GameObject.FindGameObjectWithTag("Player");

        destination = destinations[Random.Range(0, destinations.Length)].transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
