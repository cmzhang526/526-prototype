using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : MonoBehaviour
{
    bool beenCollected = false;

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player" && !beenCollected)
        {
            Debug.Log("Collecting torch");
            beenCollected = true;

            gameObject.transform.SetParent(col.gameObject.transform);
            gameObject.transform.localPosition = new Vector3(.3f, .1f, 0f);
        }
    }
}
