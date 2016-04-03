using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Container : MonoBehaviour {
    List<int> items = new List<int>();

    public List<int> Items
    {
        get
        {
            return items;
        }

        set
        {
            items = value;
        }
    }//Items

    //ItemDatabase database;
    // Use this for initialization
    void Start () {
	        
	}//Start
	
	// Update is called once per frame
	void Update () {
        
    }//Update

    void addItem(int id)
    {
        Items.Add(id);

    }//adItem

    void removeItem(int id)
    {
        items.Remove(id);
    }//removeItem
}
