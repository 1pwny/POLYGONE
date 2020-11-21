using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBG : MonoBehaviour
{
    public Vector2 velocity = new Vector2(0, -2);
    private float spriteHeight;
    private Transform cameraTransform;

    void Start()
    {
        cameraTransform = Camera.main.transform;
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteHeight = spriteRenderer.sprite.bounds.size.y;
        GetComponent<Rigidbody2D>().velocity = velocity;
    }
    void Update()
    {
        if ((transform.position.y + spriteHeight) < cameraTransform.position.y)
        {
            Vector3 newPos = transform.position;
            newPos.y += 2.0f * spriteHeight;
            transform.position = newPos;
        }
    }
}
