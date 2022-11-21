using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Based on the code by Blackthornprod
//https://www.youtube.com/watch?v=DLAIYSMYy2g

public class Pickup : MonoBehaviour
{
    // Start is called before the first frame update

    private SlotInventory slotInventory;
    public GameObject itemButton;

    void Start()
    {
        //setting the variable equal to the player's inventory
        slotInventory = GameObject.FindGameObjectWithTag("Player").GetComponent<SlotInventory>();
          
    }

    //If what the object colided with has the player tag we add it to the inventory
    void OnTriggerEnter2D(Collider2D other){

        if(other.CompareTag("Player")){
            //checking if the inventory is fool
            for(int i = 0; i < slotInventory.slots.Length; i++){
                if(slotInventory.isFull[i] == false){
                    slotInventory.isFull[i] = true;
                    Instantiate(itemButton, slotInventory.slots[i].transform, false);// spawns the object image with the inventory slot
                    Destroy(gameObject);
                    break;
                }
            }
        }
    }

    /*
    // Update is called once per frame
    void Update()
    {
        
    }*/
    
}
