using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sprimehider : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void HideSprite()
    {
        spriteRenderer.enabled = false;  // Hide the sprite
    }
    public void ShowSprite()
    {
        spriteRenderer.enabled = true;  //show the sprite
    }
}

