using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject playerLight;
    public float diminishingSpeed = .001f;
    public bool isLightActive = true;

    public Vector3 startPosition;

    void Start()
    {
        //startPosition = transform.position;
    }


    // Update is called once per frame
    void Update()
    {
        //isLightActive = true;
        //playerLight.transform.localScale -= new Vector3(diminishingSpeed, diminishingSpeed, diminishingSpeed);

        //if (playerLight.transform.localScale.x < .1f)
        //{
        //    playerLight.transform.localScale = new Vector3(.1f, .1f, .1f);
        //    isLightActive = false;
        //}

        /*if(transform.position.y < -6f)
        {
            int currScene = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currScene);
        }*/
    }
}
