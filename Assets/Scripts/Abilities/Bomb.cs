using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    ArenaPlayer creator;
    ArenaManager gm;

    int damage;
    int timer;
    float radius;

    private int stage = 0;

    public void initPref(ArenaPlayer c, ArenaManager manager, int d = 20, int t = 30, float r = 2.0f)
    {
        creator = c;
        gm = manager;

        stage = 0;
        damage = d;
        timer = t;
        radius = r;
        stage = 0;

        GetComponentInParent<BoxCollider2D>().enabled = false;

        transform.localScale = new Vector3(radius, radius, 1);
    }

    void Update()
    {
        
        timer -= 1;

        if (timer == 0 && stage == 0)
        {
            Explode();
        }

        if(timer == 0 && stage == 1)
        {
            stage = 2;
            Destroy(gameObject);
        }
    }

    private void Explode()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();

        char sep = System.IO.Path.DirectorySeparatorChar;
        sr.sprite = Resources.Load<Sprite>("Explosion");

        GetComponentInParent<BoxCollider2D>().enabled = true;

        stage = 1;
        timer += 5;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        //print("test");

        //print(collision.gameObject.GetComponent<ArenaPlayer>());

        gm.checkDamage(creator, collision.gameObject.GetComponent<ArenaPlayer>(), damage);
    }
}
