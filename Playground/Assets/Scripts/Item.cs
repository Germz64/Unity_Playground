using UnityEngine;
using System.Collections;

[System.Serializable]
public class Item {

    // Name of the item
    public string itemName;

    //Unqiue Item Identifier
    public int itemID;
    public string ItemDesc;
    public Texture2D itemIcon;
    public ItemType itemType;

    //stats
    public int itemPower;
    public int itemSpeed;
    
    //type
    public enum ItemType
    {
        Weapon,
        Consumable,
        Quest,
        Ingredient,
        Armor
    }//enum

    public Item(string name, int ID, string description,int power, int speed, ItemType type)
    {
        itemName = name;
        itemID = ID;
        itemIcon = Resources.Load<Texture2D>("Item Icons/" + name);
        ItemDesc = description;
        itemPower = power;
        itemSpeed = speed;
        itemType = type;
    }//Item

    public Item()
    {
        itemID = -1;
    }
}
