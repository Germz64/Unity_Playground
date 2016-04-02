using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemDatabase : MonoBehaviour {
    public List<Item> items = new List<Item>();

    public bool DBDebug;

	void Start()
    {
        //Add Items to DB
        items.Add(new Item("Bronze Sword", 0, "A sword that is made of bronze.", 2, 1, Item.ItemType.Weapon));
        items.Add(new Item("Lesser healing Potion", 1, "This potions heal a small amount of HP.", 0, 0, Item.ItemType.Consumable));
        items.Add(new Item("Mushroom", 2, "This mushroom can be used in cooking.", 0, 0, Item.ItemType.Ingredient));
        items.Add(new Item("Stanshroom", 3, "This doesn't smell right...", 0, 0, Item.ItemType.Consumable));

        //Debug
        if (DBDebug)
        {
            print("DB ITEM COUNT: " + items.Count + "\n\n\n\n");

            print("DB contains :\n\n\n\n");
            for (int i = 0; i < items.Count; i++)
            {
                print(items[i].itemName + "\n\n\n\n");
            }//for
        }//if
    }//start
}//ItemDatabase
