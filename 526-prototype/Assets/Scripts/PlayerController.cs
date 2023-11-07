using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public SpriteRenderer spriteRenderer;

    public Vector2 respawnPoint;
    public GameObject respawnTextObj;
    public TextMeshProUGUI respawnMsg;

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

    public void Respawn()
    {
        gameObject.transform.position = respawnPoint;
    }

    public IEnumerator SpawnAtLastCheckpoint()
    {
        Time.timeScale = 0;
        int time = 4;
        respawnTextObj.SetActive(true);
        while (time > 0)
        {
            time--;
            respawnMsg.text = "Respawning in " + time + "...";
            yield return new WaitForSecondsRealtime(1);
        }
        respawnTextObj.SetActive(false);
        Time.timeScale = 1;
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
                AnalyticsTestforCoin atest = GetComponent<AnalyticsTestforCoin>();
                if (atest != null)
                {
                    float posX = transform.position.x;
                    float posY = transform.position.y;
                    atest.SendCamera(posX, posY);
                }
            }
            else
            {
                cam.orthographicSize = 25;
            }
        }
    }
}
