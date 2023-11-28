using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    [SerializeField] public GameObject[] waypoints;
    int currWaypointIndex = 0;

    [SerializeField] public float speed = 2f;
    void Update()
    {
        if (Vector2.Distance(waypoints[currWaypointIndex].transform.position, transform.position) < .1f)
        {
            ++currWaypointIndex;
            if (currWaypointIndex >= waypoints.Length)
            {
                currWaypointIndex = 0;
            }
        }

        transform.position = Vector2.MoveTowards(transform.position, waypoints[currWaypointIndex].transform.position, Time.deltaTime * speed);
    }

    public void FlipWaypoints()
    {
        if (currWaypointIndex == 0)
        { 
            currWaypointIndex = 1;
        }
        else if (currWaypointIndex == 1)
        {
            currWaypointIndex = 0;
        }
    }
}