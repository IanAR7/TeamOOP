using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//based on the code by Blackthornprod
//https://www.youtube.com/watch?v=OG7vHstkZqM&t=26s

public class SlotFunctionality : MonoBehaviour
{   

    private SlotInventory slotInventory;

    /// Start is called before the first frame update
    // the variable slotInventory is set to the player's SlotInventory
    void Start()
    {
        slotInventory = GameObject.FindGameObjectWithTag("Player").GetComponent<SlotInventory>();

    }

    
    // Update is called once per frame
    void Update()
    {
        
    }
    // to make the cross erase the item when you click it
    public void DropItem() {
        foreach (Transform child in transform){
            GameObject.Destroy(child.gameObject);
        }
    }
}
