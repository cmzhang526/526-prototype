using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionHandler : MonoBehaviour
{
    public List<GameObject> instructionsToShow;
    public List<GameObject> instructionsToHide;

    private void Start()
    {
        foreach (var instruction in instructionsToShow)
        {
            instruction.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            foreach (var instruction in instructionsToShow)
            {
                instruction.gameObject.SetActive(true);
            }
            foreach (var instruction in instructionsToHide)
            {
                instruction.gameObject.SetActive(false);
            }
            gameObject.SetActive(false);
        }
    }
}
