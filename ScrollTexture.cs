using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollTexture : MonoBehaviour
{
    public float scrollSpeed = 2.5f;
    private float offset;
    private float rotate;

    void Update()
    {
        // This is how far the texture will be pushed
        // Updates constantly which makes the texture move
        offset += (Time.deltaTime * scrollSpeed) / 10.0f;

        // Update material offset with calculated offset
        // This only really works with repeating textures
        GetComponent<Renderer>().material.SetTextureOffset("_MainTex", new Vector2(offset, 0));
    }
}
