using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        int childrenCount = transform.childCount;
        for (int i = 0; i < childrenCount; i++) 
        {
            var child = transform.GetChild(i);
            child.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player") && col.GetComponent<SpriteRenderer>().enabled)
        {
            int childrenCount = transform.childCount;
            for (int i = 0; i < childrenCount; i++)
            {
                var child = transform.GetChild(i);
                child.gameObject.SetActive(true);
            }
            GetComponent<SpriteRenderer>().enabled = false;
        }

    }
}
