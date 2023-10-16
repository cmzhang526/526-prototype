using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spike : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
        {
            return;
        }

        AnalyticsTestforCoin atest = other.GetComponent<AnalyticsTestforCoin>();
        if (atest != null)
        {
            float posX =other.transform.position.x;
            float posY =other.transform.position.y;
            atest.SendSpike(posX, posY);
        }

        int currScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currScene);
    }
}
