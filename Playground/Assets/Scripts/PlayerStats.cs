using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour {

    public int strength; //raw damage
    public int dexterity; //crit chance
    public int wisdom; //mana regen, spell damage
    public int constitution; //raw HP
    public int luck; //chance for loot, mob spawnrate, etc

    private int hpPerConstitution = 10;//hp gained per Constitution point
    private int manaPerWisdom = 5;//mana gained per Wisdom

    public int maxHitPoints; //Base of 50HP + (10HP * constitation value)
    public int currentHitPoints; //current amount of HP

    public int maxMana; //Base of 5 + (5 * wisdom value)
    public int currentMana; //current amount of mana

    public int manaRegenInterval;
    public int manaRegenAmount;

    public int hpRegenInterval;
    public int manaRegenAmhpRegenInterval;

	// Use this for initialization
	public PlayerStats() {
        strength = 500;
        dexterity = 5;
        wisdom = 5;
        constitution = 5;
        luck = 5;

        maxHitPoints = 50 + (hpPerConstitution * constitution);
        maxMana = 5 + (manaPerWisdom * wisdom);

        currentHitPoints = maxHitPoints;
        currentMana = maxMana;
    }//PlayerStats

    // Update is called once per frame
    void Update () {
        //HP & Mana will need to be calculated based off of gear.
        maxHitPoints = 50 + (hpPerConstitution * constitution);
        maxMana = 5 + (constitution * wisdom);  
    }//update

    public void restoreHealth(int healAmount)
    {
        currentHitPoints += healAmount;
        if(currentHitPoints > maxHitPoints)
        {
            currentHitPoints = maxHitPoints;
        }//if
        print("You were healed for " + healAmount + " health!");
        print("HP: " + currentHitPoints);
    }//restoreHealth;

    public void takeDamage(int damageAmount)
    {
        currentHitPoints = currentHitPoints - damageAmount;
        print("You took " + damageAmount + " points damage!");
        if(currentHitPoints <= 0)
        {
            print("You just died bro.");
        }//if
        print("HP: " + currentHitPoints);
    }//takeDamage
}//PlayerStats
