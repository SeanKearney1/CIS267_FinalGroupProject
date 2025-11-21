using System;
using System.Reflection;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.Tilemaps;
using static UnityEditor.FilePathAttribute;

public class TilePlacment : MonoBehaviour
{
    
    public Tilemap buildingLayer;

    public TileBase BarrierTile;//replaces the tile on the tilemaps with a tower tile, this has no visual effect as the physical scripted tower will be placed above it
    //public TileBase buildableTile; tower objects need to set the tile back to buildable when they die

    // this takes the tiles in the tile folder with the purple icon to their side

    public GameObject[] TowerToPlace;// the first in this array is selection = 0, ++0 for each subsequent selection

    private int selection=0;// this is the  selection of tileToPlace[selection]
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
            Vector3Int cellPos = buildingLayer.WorldToCell(mousePos);

            placeTower(cellPos);



        }
    }
    private void placeTower(Vector3Int cellPos)
    {
        TileBase tile = buildingLayer.GetTile(cellPos);
        Vector3 placePos = buildingLayer.GetCellCenterWorld(cellPos);//get centre of the cell
        if (tile != BarrierTile)// if the selected tile can be placed on
        {
            buildingLayer.SetTile(cellPos, BarrierTile);
            Instantiate(TowerToPlace[selection], placePos, Quaternion.identity);//create the physical tile
        }
        
    }

    public void switchSelection(int index)//probably place this on ui buttons onclick
    {
        if (index >= 0 && index < TowerToPlace.Length)
            selection = index;
        else
            Debug.LogWarning("Invalid tile index!");
    }


}
