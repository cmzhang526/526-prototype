using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    float bounceTime = 0f;

    void Update()
    {
        bounceTime += Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (Input.GetKey(KeyCode.E))
            {
                if(bounceTime > .25f)
                {
                    bounceTime = 0f;
                    this.gameObject.GetComponent<WaypointFollower>().FlipWaypoints();
                }

                return;
            }
            var pc = other.gameObject.GetComponent<PlayerController>();
            StartCoroutine(pc.SpawnAtLastCheckpoint());
        }

        AnalyticsTestforCoin atest = other.gameObject.GetComponent<AnalyticsTestforCoin>();
        if (atest != null)
        {
            float posX = other.transform.position.x;
            float posY = other.transform.position.y;
            atest.SendSpike(posX, posY);
        }
    }
}
