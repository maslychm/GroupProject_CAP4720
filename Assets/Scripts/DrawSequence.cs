using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawSequence : MonoBehaviour
{
    GameObject spriteImage;
    Sprite sprite;
    SpriteRenderer spriteRenderer;
    private bool sequenceOn = false;
    private int currentFrameIndex = 0;
    private readonly string[] imagesString = { "MASK1", "image4", "MASK1" };

    void Start()
    {
        spriteImage = GameObject.Find("SublimeSequence");
        spriteRenderer = spriteImage.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Display a sequence of pictures on 'e' press
        if (Input.GetKeyDown("e"))
        {
            sequenceOn = true;
            spriteRenderer.enabled = true;
        }

        if (sequenceOn)
        {
            // Reset the sequence when got throug all images
            if (currentFrameIndex > 2)
            {
                sequenceOn = false;
                spriteRenderer.enabled = false;
                currentFrameIndex = 0;
                return;
            }

            // Load sprite, increment counter
            Debug.Log("Frame: " + currentFrameIndex + ", sequenceOn: " + sequenceOn + ", spriteRenderer on: " + spriteRenderer.enabled);
            sprite = Resources.Load<Sprite>("Images/" + imagesString[currentFrameIndex]);
            spriteRenderer.sprite = sprite;
            currentFrameIndex++;
        }
    }
}
