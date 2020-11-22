using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    ArenaPlayer creator;
    ArenaManager manager;
    int time, heal;

    public void initPrefs(ArenaPlayer c, ArenaManager m, int t = 30, int h = 5)
    {
        creator = c;
        manager = m;

        time = t;
        heal = h;
    }

    // Update is called once per frame
    void Update()
    {
        time--;

        if (time == 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag != "Obstacle")
        {
            manager.takeDamage(creator, -1 * heal);
            Destroy(gameObject);
        }
    }
}
