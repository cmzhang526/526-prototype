using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ramp : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (!other.gameObject.CompareTag("Player"))
        {
            return;
        }
        PlayerController pc = other.gameObject.GetComponent<PlayerController>();
        PlayerMovement pm = other.gameObject.GetComponent<PlayerMovement>();
        pm.canJump = false;
        if (pc.currentShape != Shape.ShapeType.Circle)
        {
            pc.rb.constraints = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionY;
        }
        else
        {
            pc.rb.gravityScale = 0;
            pc.rb.drag = 0;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (!other.gameObject.CompareTag("Player"))
        {
            return;
        }
        PlayerController pc = other.gameObject.GetComponent<PlayerController>();
        PlayerMovement pm = other.gameObject.GetComponent<PlayerMovement>();
        pm.canJump = true;
        pc.rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        pc.rb.gravityScale = 9.8f;
        pc.rb.drag = 0.05f;
    }
}
