using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TripPlayer : MonoBehaviour
{
    public bool isLocal;
    public Vector2 startingPos;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(startingPos.x, startingPos.y, 0);
    }

    // Update is called once per frame
    void Update()
    {
        float hSpeed = 0.0f, vSpeed = 0.0f;

        if (isLocal)
        {
            
            hSpeed = Input.GetAxis("Horizontal") * 10;
            vSpeed = Input.GetAxis("Vertical") * 10;
            
        }

        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        //Rigidbody rb = GetComponent<Rigidbody>();
        rb.velocity = new Vector2(hSpeed, vSpeed);
    }

    protected void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("collided with " + collision.gameObject);
    }
}
