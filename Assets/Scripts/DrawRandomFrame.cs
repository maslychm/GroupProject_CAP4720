using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawRandomFrame : MonoBehaviour
{
    Sprite sprite;
    SpriteRenderer spriteRenderer;
    //GameObject spriteImage;
    private readonly string imageString = "Images/jjl";

    void Start()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;
        //spriteImage = GameObject.Find("SublimeFrame");
        //spriteRenderer = spriteImage.GetComponent<SpriteRenderer>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Application.targetFrameRate != 60)
            Application.targetFrameRate = 60;
        // On press of 't' draw a random image onto sprite
        if (Input.GetKeyDown("t"))
        {
            DrawRandom();
        }
        else
        {
            spriteRenderer.enabled = false;
        }
    }

    // Pick a random image and Load into Sprite for 1 the current frame
    private void DrawRandom()
    {
        sprite = Resources.Load<Sprite>(imageString);
        spriteRenderer.sprite = sprite;
        spriteRenderer.size = new Vector2(1,1);

        spriteRenderer.enabled = true;
    }
}
