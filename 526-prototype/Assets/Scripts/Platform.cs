using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public enum PlatformType
    {
        Persistent,
        MustLight,
        MustDark
    };

    public PlatformType type = PlatformType.Persistent;
    public Collider2D nonTriggerCollider;
    public bool isActive = true;

    public Player player;

    void Start()
    {
        if (type == PlatformType.MustLight)
        {
            nonTriggerCollider.enabled = false;
            isActive = false;
        }
        else if (type == PlatformType.MustDark)
        {
            nonTriggerCollider.enabled = true;
            isActive = true;
        }

        player = GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<Player>();
    }

    public void LightPlatform()
    {
        if (type == PlatformType.MustLight)
        {
            nonTriggerCollider.enabled = true;
            isActive = true;
        }
        else if(type == PlatformType.MustDark)
        {
            nonTriggerCollider.enabled = false;
            isActive = false;
        }
    }

    public void DarkenPlatform()
    {
        if (type == PlatformType.MustLight)
        {
            nonTriggerCollider.enabled = false;
            isActive = false;
        }
        else if (type == PlatformType.MustDark)
        {
            nonTriggerCollider.enabled = true;
            isActive = true;
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        // = col.gameObject.GetComponent<Player>();
        if (col.gameObject.tag == "Light" && player.isLightActive)
        {
            LightPlatform();
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Light")
        {
            DarkenPlatform();
        }
    }
}
