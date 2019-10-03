using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DockingCrystalMaterials : MonoBehaviour
{
    public Material[] matColours;
    public Sprite[] toolSprites;
    Material mat;
    Sprite toolSprite;

    public Material SetMaterial(Takeable.Colour colour)
    {
        if (colour == Takeable.Colour.red)
        {
            mat = matColours[0];
        }      
        if (colour == Takeable.Colour.orange)
        {
            mat = matColours[1];
        }
        if (colour == Takeable.Colour.yellow) 
        {
            mat = matColours[2];
        }

        if (colour == Takeable.Colour.green)
        {
            mat = matColours[3];
        }

        if (colour == Takeable.Colour.blue) 
        {
            mat = matColours[4];
        }

        if (colour == Takeable.Colour.indigo)
        {
            mat = matColours[5];
        }

        if (colour == Takeable.Colour.violet)
        {
            mat = matColours[6];
        }

        return mat;
    }
    public Sprite SetSprite(Takeable.Colour colour)
    {
        if (colour == Takeable.Colour.red)
        {
            toolSprite = toolSprites[0];
        }
        if (colour == Takeable.Colour.orange)
        {
            toolSprite = toolSprites[1];
        }
        if (colour == Takeable.Colour.yellow)
        {
            toolSprite = toolSprites[2];
        }

        if (colour == Takeable.Colour.green)
        {
            toolSprite = toolSprites[3];
        }

        if (colour == Takeable.Colour.blue)
        {
            toolSprite = toolSprites[4];
        }

        if (colour == Takeable.Colour.indigo)
        {
            toolSprite = toolSprites[5];
        }

        if (colour == Takeable.Colour.violet)
        {
            toolSprite = toolSprites[6];
        }

        return toolSprite;
    }

}
