using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public SpriteRenderer spriteRenderer;

    public Vector2 respawnPoint;

    public Shape.ShapeType currentShape = Shape.ShapeType.Square;
    public int currentCoin = 0;
    public int totalCoin = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        respawnPoint = gameObject.transform.position;
    }

    public void SpawnAtLastCheckpoint()
    {
        gameObject.transform.position = respawnPoint;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z)) 
        {
            Camera cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
            if (cam.orthographicSize == 25)
            {
                cam.orthographicSize = 60;
            }
            else
            {
                cam.orthographicSize = 25;
            }
        }
    }
}
