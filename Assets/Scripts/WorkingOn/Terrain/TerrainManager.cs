using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TerrainManager {

    private static TerrainManager Instance;

    //Eventos: Mudou o valor do terren0o de uma celula

    private Grid<TerrainObject> terrainMap;

    private Tilemap tilemap;

    public TerrainManager(int width, int height, int cellSize, Vector3 origin, Tilemap tilemap, bool showDebug)
    {
        terrainMap = new Grid<TerrainObject>(width, height, cellSize, origin,( Grid<TerrainObject> g, int x,int y) =>  new TerrainObject(g,x,y), showDebug);
        this.tilemap = tilemap;
        Instance = this;
        Vector3Int tilePos;
        for (int gridX = 0; gridX < terrainMap.GetWidth(); gridX++)
        {
            for (int gridY = 0; gridY < terrainMap.GetHeight(); gridY++)
            {
                tilePos = new Vector3Int(gridX, gridY,0);
                tilemap.SetTile(tilePos, terrainMap.GetGridObject(gridX, gridY).CellTerrainType().GetTerrainTile());
            }
        }
    }

    public Grid<TerrainObject> GetGrid()
    {
        return terrainMap;
    }

    public void ReconstructTilemap()
    {
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

    public void SetTilemapObjectSprite(Vector3 worldPos, Terrain terrianType)
    {
        TerrainObject tilemapObject = terrainMap.GetGridObject(worldPos);
        if (tilemapObject != null)
            tilemapObject.SetTerrainType(terrianType);
    }
}
