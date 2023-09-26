using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject PlayerLight;
    public float diminishingSpeed = .001f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerLight.transform.localScale -= new Vector3(diminishingSpeed, diminishingSpeed, diminishingSpeed);
        if (PlayerLight.transform.localScale.x < .1f)
        {
            PlayerLight.transform.localScale = new Vector3(.1f, .1f, .1f);
        }
    }
}
