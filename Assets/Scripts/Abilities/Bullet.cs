using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Deflectable
{
    ArenaManager manager;

    int damage;
    public int velocity = 10;

    //bounces till it hits max or hits a player
    public void initPrefs(ArenaPlayer c, ArenaManager m, int damage = 5, int mB = 2)
    {
        creator = c;
        manager = m;

        bounces = 0;
        maxBounces = mB;

        gameObject.GetComponent<Rigidbody2D>().velocity = transform.up * velocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        manager.checkDamage(creator, collision.gameObject.GetComponent<ArenaPlayer>(), 10);
        addBounces(maxBounces);
    }
}
