using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSource : MonoBehaviour
{
    public GameObject lightCirclePrefab;
    public SpriteRenderer sprite;
    public float lightSize = 2.0f;
    public Vector3 MaxLightScale = new Vector3(6.66666698f, 13.333334f, 1f);
    public bool isLit = false;

    void OnStart()
    {
        sprite.enabled = false;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            Player player = col.gameObject.GetComponent<Player>();
            if (player.isLightActive && !isLit)
            {
                Light();
            }

            if (isLit)
            {
                player.isLightActive = true;
                player.playerLight.transform.localScale = new Vector3(1f, 1f, 1f);
            }
        }
    }

    void Light()
    {
        GameObject newLight = Object.Instantiate(lightCirclePrefab, transform.position, transform.rotation, transform);
        newLight.transform.localScale = MaxLightScale;
        isLit = true;
        sprite.enabled = true;
    }
}
