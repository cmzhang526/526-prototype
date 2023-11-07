using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Coin : MonoBehaviour
{
    bool hasCollected = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player") || hasCollected)
        {
            return;
        }

        hasCollected = true;
        PlayerController pc = other.gameObject.GetComponent<PlayerController>();
        pc.currentCoin++;

        AnalyticsTestforCoin atest = other.GetComponent<AnalyticsTestforCoin>();
        if (atest != null)
        {
            atest.SendChckpointTime(Time.time);
        }

        if (pc.currentCoin == pc.totalCoin)
        {
            // collected all the coins, game over
            SceneManager.LoadScene(2);
        }
        pc.respawnPoint = gameObject.transform.position;
        Destroy(gameObject);
    }


}
