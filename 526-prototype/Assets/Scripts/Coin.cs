using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        pc.respawnPoint = gameObject.transform.position;
        Destroy(gameObject);
    }
}
