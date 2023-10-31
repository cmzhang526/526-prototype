using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            var pc = other.gameObject.GetComponent<PlayerController>();
            pc.SpawnAtLastCheckpoint();
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
