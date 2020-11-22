using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaPlayer : MonoBehaviour
{
    public ArenaManager manager;

    public bool isLocal;
    public Vector2 startingPos;
    public string hinput, vinput;

    public enum Attacks { Bomb, Bullet, Charge }
    public enum Defenses { Phaseout, Wall, Heal }

    public KeyCode attackKey, defendKey;

    public Attacks attack;
    public Defenses defense;


    public int atMax, deMax;
    private int attTimer, defTimer;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(startingPos.x, startingPos.y, 0);
        attTimer = 30;
        defTimer = 30;
    }

    // Update is called once per frame
    void Update()
    {
        doMovement();

        useAbilities();
    }

    void doMovement()
    {
        //use forward/turn instead of left/right so you can turn and aim shots/dashes etc.
        float turnSpeed = 0.0f, forwardSpeed = 0.0f;

        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        Vector2 forward = rb.transform.forward;

        if (isLocal)
        {
            forwardSpeed = Input.GetAxis(vinput) * 5;
            turnSpeed = Input.GetAxis(hinput) * 5;

            rb.SetRotation(rb.rotation - turnSpeed);
            rb.angularVelocity = 0; //clear angular velocity from collisions with walls/etc       

            rb.velocity = rb.transform.up.normalized * forwardSpeed;
        }
    }

    void useAbilities()
    {
        attTimer -= (attTimer < 1) ? 0 : 1;
        defTimer -= (defTimer < 1) ? 0 : 1;

        if (Input.GetKeyDown(attackKey) && attTimer == 0)
        {
            switch (attack)
            {
                case Attacks.Bomb:
                    Bomb();
                    break;

                case Attacks.Bullet:
                    Bullet();
                    break;

                case Attacks.Charge:
                    Charge();
                    break;

                default:
                    break;
            }

            attTimer = atMax;
        }

        if (Input.GetKeyDown(defendKey) && defTimer == 0) { 
            switch (defense)
            {
                case Defenses.Phaseout:
                    PhaseOut();
                    break;

                case Defenses.Wall:
                    Wall();
                    break;

                case Defenses.Heal:
                    Heal();
                    break;

                default:
                    break;
            }

            defTimer = deMax;
        }
    }


    void initAttackDefend(string shape)
    {
        if(transform.position.x > 0)
        {
            //assume player 2
            attackKey = KeyCode.RightControl;
            defendKey = KeyCode.Keypad0;
        }
        else
        {
            //asume player 1
            attackKey = KeyCode.LeftShift;
            defendKey = KeyCode.V;
        }

        switch(shape)
        {
            case "circle":
                attack = Attacks.Bomb;
                defense = Defenses.Phaseout;
                break;
            case "square":
                attack = Attacks.Bullet;
                defense = Defenses.Wall;
                break;
            case "triangle":
                attack = Attacks.Charge;
                defense = Defenses.Heal;
                break;

            default:
                break;
        }
    }

    //Circle moveset
    void Bomb()
    {
        GameObject bombToBe = Instantiate(manager.bombPref, transform.position, Quaternion.identity);

        bombToBe.GetComponent<Bomb>().initPref(this, manager);
    }
    void PhaseOut()
    {
        gameObject.SetActive(false);

        GameObject circleToBe = Instantiate(manager.phasePref, transform.position, transform.rotation);

        circleToBe.GetComponent<Rigidbody2D>().velocity = GetComponent<Rigidbody2D>().velocity;
        circleToBe.GetComponent<PhasedOut>().initPrefs(this.gameObject, hinput, vinput);
    }

    //Square moveset
    void Bullet()
    {
        GameObject bulletToBe = Instantiate(manager.bulletPref, transform.position + 1.1f * transform.up, transform.rotation);

        bulletToBe.GetComponent<Bullet>().initPrefs(this, manager);
    }
    void Wall()
    {
        GameObject wallToBe = Instantiate(manager.wallPref, transform.position, transform.rotation);

        wallToBe.GetComponent<Shield>().initPrefs(this, manager);
    }

    //Triangle moveset
    void Charge()
    {

    }
    void Heal()
    {

    }
}
