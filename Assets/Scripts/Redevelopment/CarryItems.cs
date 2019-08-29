using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarryItems : MonoBehaviour

{
    private bool hasItem;
    private Takeable.Item item;
    private Takeable.Colour colour;

    public void SetItem(Takeable.Item item, Takeable.Colour colour)
    {
        this.hasItem = true;
        this.item = item;
        this.colour = colour;
    }

    public void DropItem()
    {
        this.hasItem = false;
    }
}
