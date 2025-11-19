using System;
using System.Reflection;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.Tilemaps;
using static UnityEditor.FilePathAttribute;

public class TilePlacment : MonoBehaviour
{
    
    public Tilemap tileMapToPlaceOn;
    // this takes the tiles in the tile folder with the purple icon to their side

    public TileBase[] tileToPlace;// the first in this array is selection = 0, ++0 for each subsequent selection
    private int selection;// this is the  selection of tileToPlace[selection]
    private void Update()
    {
        placeTileOnMousePoint();
    }


    public void placeTileOnMousePoint()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // get the position of the cursor
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            // convert the cursor location to a grid location
            Vector3Int cellPos = tileMapToPlaceOn.WorldToCell(mousePos);

            //place the tile on the grid
            tileMapToPlaceOn.SetTile(cellPos, tileToPlace[selection]);
        }
    }
    public void switchSelection(int index)//probably place this on ui buttons onclick
    {// go to button in onclick() hit plus, drag the object with this script in, to the left of that select this function and type in a index number
        if (index >= 0 && index < tileToPlace.Length)
            selection = index;
        else
            Debug.LogWarning("Invalid tile index!");
    }


}
