using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    [SerializeField]
    Shape.ShapeType myShapeType = Shape.ShapeType.None;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            PlayerController pc = col.gameObject.GetComponent<PlayerController>();
            if (myShapeType == pc.currentShape)
            {
                Debug.Log("Unlock door");

                UnlockDoor();
            }
        }


    }

    public void UnlockDoor()
    {
        if (gameObject.transform.childCount > 0)
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
        }
        gameObject.SetActive(false);
        Destroy(gameObject);
    }
}
