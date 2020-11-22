using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public Vector2 velocity = new Vector2(0, -2);
    // Start is called before the first frame update
    void Start()
    {
        Physics2D.IgnoreLayerCollision(8, 8, true);
        GetComponent<Rigidbody2D>().velocity = velocity;
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.transform.position.y < -20f && gameObject.tag.Equals("Star"))
        {
            Destroy(gameObject);
        }
    }
}
