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

    public void LightPlatform()
    {
        if (type == PlatformType.MustLight)
        {
            nonTriggerCollider.enabled = true;
        }
        else if(type == PlatformType.MustDark)
        {
            nonTriggerCollider.enabled = false;
        }
    }

    public void DarkenPlatform()
    {
        if (type == PlatformType.MustLight)
        {
            nonTriggerCollider.enabled = false;
        }
        else if (type == PlatformType.MustDark)
        {
            nonTriggerCollider.enabled = true;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Light")
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
