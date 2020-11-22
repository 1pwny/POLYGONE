using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaManager : MonoBehaviour
{
    public ArenaPlayer p1, p2;
    public GameObject hp1, hp2;

    private int p1HP, p2HP;
    public float hpmax = 100.0f;

    //prefabs
    public GameObject bombPref, phasePref, bulletPref, wallPref, chargePref, healPref;

    private int p1_invincible, p2_invincible;

    private void Start()
    {
        p1HP = 100;
        p2HP = 100;
    }

    void Update()
    {
        //start position of bar: x = -4
        //decrease 10% -> x = -4.2 -> 100% = -2
        //-4 - 2 * (max - hp / max)

        //starting scale: x = 20
        //decrease 10% -> x = 18 -> 100% = 20
        //20 - 20 * (hp / max)

        //print(p1HP);

        p1_invincible -= (p1_invincible < 1) ? 0 : 1;
        p2_invincible -= (p2_invincible < 1) ? 0 : 1;

        hp1.transform.localScale = new Vector3(20 * (p1HP / hpmax), 5.25f, 1);
        hp1.transform.position = new Vector3(-6 + 2 * (p1HP / hpmax), 4.15f, 0);

        hp2.transform.localScale = new Vector3(20 * (p2HP / hpmax), 5.25f, 1);
        hp2.transform.position = new Vector3(6 - 2 * (p2HP / hpmax), 4.15f, 0);

        //takeDamage(p1, 1);
    }

    public void takeDamage(ArenaPlayer damaged, int damage)
    {
        if (p1 == damaged && p1_invincible == 0)
        {
            if(damage > 0 || p1HP - damage < 100)
                p1HP -= damage;

            if(p1HP < 1)
            {
                p1HP = 0;
                win(2);
            }

            p1_invincible = 10;
        }
        else if(p2 == damaged && p2_invincible == 0)
        {
            if (damage > 0 || p2HP - damage < 100)
                p2HP -= damage;

            if(p2HP < 1)
            {
                p2HP = 0;
                win(1);
            }

            p2_invincible = 30;
        }

        //print("damage");
    }

    public void checkDamage(ArenaPlayer creator, ArenaPlayer possiblyHit, int damage)
    {
        if (creator != possiblyHit)
            takeDamage(possiblyHit, damage);
    }


    public void win(int winningPlayer)
    {

    }
}
