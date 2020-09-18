using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileManager
{
    private static TileManager Instance;

    //Eventos: Mudou o valor do terren0o de uma celula

    private Grid<TileObject> terrainMap;

    private Tilemap tilemap;
    public TileManager(int width, int height, int cellSize, Vector3 origin, Tilemap tilemap, bool showDebug)
    {
        terrainMap = new Grid<TileObject>(width, height, cellSize, origin, (Grid<TileObject> g, int x, int y) => new TileObject(g, x, y), showDebug);
        this.tilemap = tilemap;
        Instance = this;
        Vector3Int tilePos;
        for (int gridX = 0; gridX < terrainMap.GetWidth(); gridX++)
        {
            for (int gridY = 0; gridY < terrainMap.GetHeight(); gridY++)
            {
                tilePos = new Vector3Int(gridX, gridY, 0);
                tilemap.SetTile(tilePos, terrainMap.GetGridObject(gridX, gridY).CellTerrainType().GetTerrainTile());
            }
        }
    }
}
