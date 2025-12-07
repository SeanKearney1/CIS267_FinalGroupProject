using UnityEngine;
using UnityEngine.Tilemaps;

public class buildableOnDestroy : MonoBehaviour
{
    private Tilemap tilemap;
    private Vector3Int tilePos;

    void Start()
    {
        // Get the Tilemap from the parent
        tilemap = GetComponentInParent<Tilemap>();
        if (tilemap == null)
        {
            Debug.LogError("No Tilemap found in parent!");
            return;
        }
        // Get the tile cell this tower occupies
        tilePos = tilemap.WorldToCell(transform.position);
    }
    private void OnDestroy()
    {
        tilemap.SetTile(tilePos, null);
    }
}
