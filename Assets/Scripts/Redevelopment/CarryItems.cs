using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarryItems : MonoBehaviour
{
    public List<HeldItem> CarriedItems = new List<HeldItem>();
    
    public void AddItem(Takeable.Item item, Takeable.Colour colour)
    {
        CarriedItems.Add(new HeldItem(item, colour));
    }

    public void DropItem(Takeable.Item item, Takeable.Colour colour)
    {
        CarriedItems.Remove(new HeldItem(item, colour));
        print("Removing colour " + colour + "for item type " + item);
    }

    public bool HasItem(Takeable.Item item, Takeable.Colour colour)
    {
        foreach(var carriedItem in CarriedItems) //loops through determines if player has the item the socket needs
        {
            var colourMatch = carriedItem.colour == colour;
            var itemMatch = carriedItem.item == item;
            if(colourMatch && itemMatch)
            {
                return true;
            }
        }
        return false; 
    }

    public class HeldItem
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
            if (this == obj)
            {
                return true;
            }
            if (obj is HeldItem)
            {
                var testItem = obj as HeldItem;
                return testItem.colour == this.colour && testItem.item == this.item;
            }
            return false;
        }
    }
}
