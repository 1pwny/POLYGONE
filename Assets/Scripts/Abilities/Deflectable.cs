using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deflectable : MonoBehaviour
{
    protected ArenaPlayer creator;

    protected int bounces, maxBounces;

    public void Deflect(ArenaPlayer deflector)
    {
        creator = deflector;
    }

    protected void addBounces(int num = 1)
    {
        bounces += num;
        if (bounces >= maxBounces)
            Destroy(gameObject);
    }
}
