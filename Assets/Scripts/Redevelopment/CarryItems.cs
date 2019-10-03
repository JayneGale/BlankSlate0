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
        carriedItems.Remove(new HeldItem(item, colour));
    }

    public bool HasItem(Takeable.Item item, Takeable.Colour colour)
    {
        foreach(var carriedItem in carriedItems) //loops through determines if player has the item the socket needs
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
    //public List<> MatchingItems(Takeable.Item item, Takeable.Colour colour)
    //{
    //    foreach (var carriedItem in carriedItems) //loops through determines if player has the item the socket needs
    //    {
    //        var colourMatch = carriedItem.colour == colour;
    //        var itemMatch = carriedItem.item == item;
    //        if (colourMatch && itemMatch)
    //        {
    //            return colourMatch(i);
    //        }
    //    }
    //    return false;
    //}



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
