using UnityEngine;
using System.Collections;

public class TerrainManager : MonoBehaviour {

    Vector2 itemPOS;
    ItemDatabase itemDB;
    // Use this for initialization
    void Start()
    {
        itemDB = new ItemDatabase();

    }
	// Update is called once per frame
	void Update () {

    }//Update

    void OnGUI()
    {
    //placeItem(new Item("Bronze Sword", 0, "A sword that is made of bronze.", 2, 1, Item.ItemType.Weapon), new Vector2(400, 400));
    }

    void placeItem(Item item, Vector2 itemPosition)
    {
        GUI.DrawTexture(new Rect(itemPosition.x, itemPosition.x, 50, 50), item.itemIcon);
    }//placeItem
}
