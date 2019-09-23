using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarryItems : MonoBehaviour
{
    List<HeldItem> carriedItems = new List<HeldItem>();
    
    public void SetItem(Takeable.Item item, Takeable.Colour colour)
    {
        carriedItems.Add(new HeldItem(item, colour));
    }

    public void DropItem(Takeable.Item item, Takeable.Colour colour)
    {
        print("DropItem Method called...but its not got anything in it yet");
        //carriedItems.Remove(new HeldItem(item, colour));
    }

    public bool HasItem(Takeable.Item item, Takeable.Colour colour)
    {
        foreach(var carriedItem in carriedItems)
        {
            var colourMatch = carriedItem.colour == colour;
            var itemMatch = carriedItem.item == item;
            if(colourMatch && itemMatch)
            {
                return true;
            }
        }
        return false;//loops through determines if player has the item the socket needs
    }

    private class HeldItem
    {
        public Takeable.Item item;
        public Takeable.Colour colour;

        public HeldItem(Takeable.Item item, Takeable.Colour colour)
        {
            this.item = item;
            this.colour = colour;
        }

        public override bool Equals(object obj)
        {
            if (obj is HeldItem)
            {
                var testItem = obj as HeldItem;
                // check if test item equals this item's item and colour
            }
            return false;
        }
    }
}
