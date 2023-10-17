using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
        {
            return;
        }

        PlayerController pc = other.gameObject.GetComponent<PlayerController>();
        pc.currentCoin++;
        if (pc.currentCoin == pc.totalCoin)
        {
            // collected all the coins, game over
            SceneManager.LoadScene(2);
        }
        pc.respawnPoint = gameObject.transform.position;
        Destroy(gameObject);
    }


}
