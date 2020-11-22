using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhasedOut : MonoBehaviour
{
    GameObject creator;

    string hinput, vinput;
    int time;

    public void initPrefs(GameObject c, string hi = "Horizontal", string vi = "Vertical", int t = 30)
    {
        creator = c;

        hinput = hi;
        vinput = vi;

        time = t;
    }

    // Update is called once per frame
    void Update()
    {
        time--;

        doMovement();

        if(time == 0)
        {
            Rigidbody2D crb = creator.GetComponent<Rigidbody2D>();
            Rigidbody2D porb = gameObject.GetComponent<Rigidbody2D>();

            crb.transform.position = porb.transform.position;
            crb.transform.rotation = porb.transform.rotation;
            crb.velocity = porb.velocity;

            creator.SetActive(true);

            Destroy(gameObject);
        }
    }

    void doMovement()
    {
        //use forward/turn instead of left/right so you can turn and aim shots/dashes etc.
        float turnSpeed = 0.0f, forwardSpeed = 0.0f;

        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        Vector2 forward = rb.transform.forward;

        forwardSpeed = Input.GetAxis(vinput) * 5;
        turnSpeed = Input.GetAxis(hinput) * 5;

        rb.SetRotation(rb.rotation - turnSpeed);
        rb.angularVelocity = 0; //clear angular velocity from collisions with walls/etc       

        rb.velocity = rb.transform.up.normalized * forwardSpeed;
    }
}
