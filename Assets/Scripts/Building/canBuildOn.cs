using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(menuName = "Tiles/canBuildTile")]
public class BooleanTile : Tile
{
    public bool canBuildOn = true;
}