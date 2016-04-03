using System;
using UnityEngine;

namespace Assets.Scripts
{
    public class LootGenerator : MonoBehaviour
    {
        public ItemDatabase database;
        public Iventory inventory;

        public Item generateLoot()
        {
            System.Random rnd = new System.Random();
            int randomItemID = rnd.Next(0, database.items.Count);
            inventory.AddItem(randomItemID);
            return database.items[randomItemID];
        }
    }
}
