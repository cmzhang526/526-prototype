using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StickyPlatform : MonoBehaviour
{
    PlayerMovement pm;
    bool isJumping = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !isJumping)
        {
            pm = collision.gameObject.GetComponent<PlayerMovement>();
            collision.gameObject.transform.SetParent(transform);
            StartCoroutine(CheckJump(collision));
        }
    }

    IEnumerator CheckJump(Collider2D collision)
    {
        while (true)
        {
            if (pm != null)
            {
                if (pm.jump)
                {
                    isJumping = true;
                    collision.gameObject.GetComponent<CharacterController2D>().DoJump();
                    collision.gameObject.transform.SetParent(null);
                    SceneManager.MoveGameObjectToScene(collision.gameObject, SceneManager.GetSceneByBuildIndex(1));
                    break;
                }
            }
            else
            {
                break;
            }
            yield return null;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        StopAllCoroutines();
        if (collision.gameObject.CompareTag("Player"))
        {
            isJumping = false;
            collision.gameObject.transform.SetParent(null);
            SceneManager.MoveGameObjectToScene(collision.gameObject, SceneManager.GetSceneByBuildIndex(1));
        }
    }
}
