using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUp : MonoBehaviour
{
    public enum Upgrades
    {
        healthIncreaseLarge, OffenseBoost, healthIncreaseMedium, DefenseBoost, healthIncreaseSmall, FirmHandShake
    }
    public Upgrades upgrade;
    public string Upgrade;
    public int Value;
    

    // Start is called before the first frame update
    void Start()
    {
        
        switch (gameObject.tag)
        {
            case "15":
                Value = 15;
                if (Random.value > 0.5f)
                {
                    upgrade = Upgrades.healthIncreaseLarge;
                    Upgrade = "Large Health Increase!";
                }
                else
                {
                    upgrade = Upgrades.OffenseBoost;
                    Upgrade = "Offense Boost!";
                }
                break;
            case "10":
                Value = 10;
                if (Random.value > 0.5f)
                {
                    upgrade = Upgrades.healthIncreaseMedium;
                    Upgrade = "Medium Health Increase!";
                }
                else
                {
                    upgrade = Upgrades.DefenseBoost;
                    Upgrade = "Defense Boost!";
                }
                break;
            case "5":
                Value = 5;
                if (Random.value > 0.5f)
                {
                    upgrade = Upgrades.healthIncreaseSmall;
                    Upgrade = "Small Health Increase!";
                }
                else
                {
                    upgrade = Upgrades.FirmHandShake;
                    Upgrade = "You Get A Firm Handshake!";
                }
                break;
        }
        print(gameObject.name + " " + upgrade);
    }
}
