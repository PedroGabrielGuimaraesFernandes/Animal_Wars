using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainManager {

    private static TerrainManager Instance;

    //Eventos: Mudou o valor do terren0o de uma celula

    private Grid<TerrainObject> terrainMap;

    public TerrainManager(int width, int height, int cellSize, Vector3 origin, bool showDebug)
    {
        terrainMap = new Grid<TerrainObject>(width, height, cellSize, origin,( Grid<TerrainObject> g, int x,int y) =>  new TerrainObject(g,x,y), showDebug);
        Instance = this;
    }

    public Grid<TerrainObject> GetGrid()
    {
        return terrainMap;
    }

    public void SetTilemapObjectSprite(Vector3 worldPos, Terrain terrianType)
    {
        TerrainObject tilemapObject = terrainMap.GetGridObject(worldPos);
        if (tilemapObject != null)
            tilemapObject.SetTerrainType(terrianType);
    }
}
