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
        Debug.Log("Entering Goal");
        if (col.gameObject.tag == "Player")
        {
            PlayerController pc = col.gameObject.GetComponent<PlayerController>();
            if (myShapeType == pc.currentShape)
            {
                LoadNextLevel();
            }
        }


    }

    public void LoadNextLevel()
    {
        int currScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currScene + 1);
    }
}
