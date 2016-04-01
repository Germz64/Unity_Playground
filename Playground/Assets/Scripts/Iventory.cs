using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Iventory : MonoBehaviour {

    //Debug
    public bool inventoryDebug;

    //The Game's Item DB
    public ItemDatabase database;

    //The Player's Stats
    public PlayerStats ps;

    //Containers
    public List<Item> inventory = new List<Item>();
    public List<Item> slots = new List<Item>();
    public int slotX, slotY;//Inventory layout "slots"

    //Functional variables
    private bool showInventory;
    private bool showPause;
    private bool showToolTip;
    private string toolTip;
    private bool draggingItem;
    private Item draggedItem;
    private int draggedIndex;
    private Item item;
    //Skin
    public GUISkin skin;

	// Use this for initialization
	void Start () {
        //Get the DB of Items
        database = GameObject.FindGameObjectWithTag("Item Database").GetComponent<ItemDatabase>();
        ps = GameObject.FindGameObjectWithTag("Player Stats").GetComponent<PlayerStats>();

        //Create slots for inventory GUI
        for (int i = 0; i < (slotX * slotY); i++)
        {
            slots.Add(new Item());
            inventory.Add(new Item());
        }//for

        //Add items to inventory
        //inventory[0] = database.items[0];
        //inventory[1] = database.items[1];
        AddItem(0);
        AddItem(1);
        AddItem(1);
        AddItem(1);
        AddItem(1);
        //Debug
        if (inventoryDebug) {
            print("Iventory Count: " + inventory.Count + "\n\n\n\n");
            print("Iventory contains :\n\n\n\n");
            for (int i = 0; i < inventory.Count; i++)
            {
                print(inventory[i].itemName + "\n\n\n\n");
            }//for
        }//if
    }//Start
	
    void Update()
    {
        //Check for inventory Key (to be changed with Input Manager
        if (Input.GetButtonDown("Inventory")) { 
            showInventory = !showInventory;
        }//if

        if (Input.GetButtonDown("Pause"))
        {
            showPause = !showPause;
        }//if
    }//Update	

    void SaveInventory()
    {
        for (int i = 0; i < inventory.Count; i++)
        {
            PlayerPrefs.SetInt("Inventory " + i, inventory[i].itemID);
        }//for
    }//SaveInventory

    void LoadInventory()
    {
        for (int i = 0; i < inventory.Count; i++)
        {
            inventory[i] = PlayerPrefs.GetInt("Inventory " + i, -1) >= 0 ? database.items[PlayerPrefs.GetInt("Inventory " + i)] : new Item();
        }//for
    }//SaveInventory

    string CreateToolTip(Item item)
    {
        toolTip = "<color=red>"+item.itemName+"</color>" + "\n\n" + item.ItemDesc;
        return toolTip;
    }//CreateToolTip

    void AddItem(int itemId)
    {
        for(int i = 0; i < inventory.Count; i++)
        {
            if (inventory[i].itemName == null)
            {
                for (int j = 0; j < database.items.Count; j++)
                {
                    if(database.items[j].itemID == itemId)
                    {
                        inventory[i] = database.items[j];
                    }//if
                }//for
                break;
            }//if
        }//for
    }//AddItem

    void RemoveItem(int itemID)
    {
        for(int i = 0; i < inventory.Count; i++)
        {
            if(inventory[i].itemID == itemID)
            {
                inventory[i] = new Item();
                break;
            }
        }//for
    }//RemoveItem

    //Search inventory for itemID.
    bool InventoryContains(int id)
    {
        bool contains = false;
        for(int i = 0; i < inventory.Count; i++)
        {
            if (inventory[i].itemID == id)
            {
                contains = true;
                break;
            }
        }
        return contains;
    }//Iventory Contains

    private void UseConsumable(Item item, int slot, bool deleteItem)
    {
        switch (item.itemID)
        {
            case 1://Potion of Lesser Healing
                {
                    ps.restoreHealth(15);
                    print("Used consumable " + item.itemName);
                    break;
                }//case1
        }//switch
        if (deleteItem)
        {
            inventory[slot] = new Item();
        }//if
    }//UseConsumable

    void OnGUI()
    {
        toolTip = "";
        GUI.skin = skin;
        //Check if Inventory windows is toggeled on or off
        if (showInventory)
        {
            DrawInventory();

            if (showToolTip && !draggingItem)
            {
                GUI.Box(new Rect(Event.current.mousePosition.x, Event.current.mousePosition.y + 20, 200, 100), toolTip, skin.GetStyle("ToolTip")); //Draw Tooltip at Mouse Position
            }//if

            //Dragging item
            if (draggingItem)
            {
                GUI.DrawTexture(new Rect(Event.current.mousePosition.x, Event.current.mousePosition.y, 50, 50), draggedItem.itemIcon);
            }//if
        }//if

        if (showPause)
        {
            //Save & Load buttons + their button events
            if (GUI.Button(new Rect(40, 250, 100, 40), "Save"))
            {
                SaveInventory();
            }
            if (GUI.Button(new Rect(40, 300, 100, 40), "Load"))
            {
                LoadInventory();
            }//if
        }//if

        //DEBUG
        if (inventoryDebug)
        {
            for (int i = 0; i < inventory.Count; i++)
            {
                GUI.Label(new Rect(10, i * 20, 200, 250), inventory[i].itemName);//Draw inventory text - Top Right
            }//for
        }//if
    }//OnGUI

    //Draw inventory slots
    void DrawInventory()
    {
        int i = 0;//Loop counter
        Event e = Event.current; //Store current event for ease
                                 //Iteration over inventory slots
        
        GUIStyle centeredStyle = GUI.skin.GetStyle("Label");
        //centeredStyle.alignment = TextAnchor.UpperCenter;

        int inventoryWidth = 800;
        int inventoryHeight = 800;

        Rect backgroundRect = new Rect(Screen.width / 2 - (inventoryWidth/2), Screen.height / 2 - (inventoryHeight/2), inventoryWidth, inventoryHeight);
        GUI.Box(backgroundRect, "", skin.GetStyle("Box"));

        for (int y = 0; y < slotY; y++)
        {
            for(int x = 0; x < slotX; x++)
            {
                //Create rect, apply our skin, equalize slots with inventory, draw icon if item exists
                Rect test = new Rect(backgroundRect.center.x + 300 - x * 60, backgroundRect.center.y + 300 - y * 60, 50, 50);
                Rect slotRect = new Rect(x * 60, y * 60, 50, 50);
                GUI.Box(test, "",skin.GetStyle("Slot"));
                slots[i] = inventory[i];
                Item item = slots[i];
                if (slots[i].itemName != null)
                {
                    GUI.DrawTexture(test, slots[i].itemIcon);
                    if (test.Contains(e.mousePosition))
                    {
                        CreateToolTip(slots[i]);
                        showToolTip = true;
                        if(e.button == 0 && e.type == EventType.MouseDrag && !draggingItem)
                        {
                            //Drag and drop;
                            draggingItem = true;
                            draggedItem = slots[i];
                            draggedIndex = i;
                            inventory[i] = new Item();
                        }//if
                        if (e.type == EventType.mouseUp && draggingItem) {

                            inventory[draggedIndex] = inventory[i];
                            inventory[i] = draggedItem;
                            draggingItem = false;
                            draggedItem = null;
                        } //if

                        if(e.isMouse && e.type == EventType.mouseDown && e.button == 1)
                        {
                            if (item.itemType == Item.ItemType.Consumable)
                            {
                                UseConsumable(item, i, true);
                            }//if
                        }//if
                    }//if
                }//if
                else
                {   //Drag and drop item switch
                    if (test.Contains(e.mousePosition))
                    {
                        if (e.type == EventType.mouseUp && draggingItem)
                        {
                            inventory[draggedIndex] = inventory[i];
                            inventory[i] = draggedItem;
                            draggingItem = false;
                        }//if
                     }//if
                }//if
                if(toolTip == "")
                {
                    showToolTip = false;
                }//if   
                i++;
            }//for
        }//for
    }//DrawInventory
}//Inventory
