using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawOneFrame : MonoBehaviour
{
    Sprite sprite;
    SpriteRenderer spriteRenderer;
    GameObject spriteImage;
    private readonly string imageString = "Images/jjl";

    void Start()
    {
        spriteImage = GameObject.Find("SublimeFrame");
        spriteRenderer = spriteImage.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // On press of 't' draw a random image onto sprite
        if (Input.GetKeyDown("t"))
        {
            DrawRandom();
        }
        else
        {
            spriteImage.GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    // Pick a random image and Load into Sprite for 1 the current frame
    private void DrawRandom()
    {
        sprite = Resources.Load<Sprite>(imageString);
        spriteRenderer.sprite = sprite;
        spriteRenderer.enabled = true;
    }
}
