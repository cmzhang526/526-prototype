using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Shape : MonoBehaviour
{
    public enum ShapeType
    {
        None,
        Circle,
        Square,
        Triangle
    }

    private static Dictionary<ShapeType, Sprite> cacheShapeSprites;

    public ShapeType myShapeType = ShapeType.None;

    void Awake()
    {
        if (cacheShapeSprites == null)
        {
            cacheShapeSprites = new Dictionary<ShapeType, Sprite>();
            var circle = Resources.Load<Sprite>("ShapeSprites/Circle");
            var square = Resources.Load<Sprite>("ShapeSprites/Square");
            var triangle = Resources.Load<Sprite>("ShapeSprites/Triangle");
            cacheShapeSprites.Add(ShapeType.Circle, circle);
            cacheShapeSprites.Add(ShapeType.Square, square);
            cacheShapeSprites.Add(ShapeType.Triangle, triangle);
        }

    }

    private void UpdatePlayerShape(PlayerController pc)
    {
        ChangePlayerShape(pc);
    }

    private void ChangePlayerShape(PlayerController pc)
    {

        pc.spriteRenderer.sprite = cacheShapeSprites[myShapeType];
        pc.currentShape = myShapeType;
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
        {
            return;
        }

        PlayerController pc = other.gameObject.GetComponent<PlayerController>();
        UpdatePlayerShape(pc);
    }
}
