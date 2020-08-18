using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainObject : MonoBehaviour
{
    private Grid<TerrainObject> grid;
    private int x;
    private int y;

    private Terrain cellTerrain = Resources.Load<Terrain>("Terrenos/Planice");

    /*public TerrainObject(Grid<TerrainObject> terrainGrid, int x, int y)
    {
        TerrainObject(Grid(terrainGrid, x, y))
    }*/

    public TerrainObject(Grid<TerrainObject> terrainGrid, int x, int y)
    {
        this.grid = terrainGrid;
        this.x = x;
        this.y = y;
    }

    public Grid<TerrainObject> GetGrid()
    {
        return grid;
    }

    public void SetTerrainType(Terrain terrianType)
    {
        this.cellTerrain = terrianType;
        grid.TriggerGridObjectChanged(x, y);
    }

    public string GetTerrainName()
    {
        return cellTerrain.name;
    }

    public void CreateTerrainTile()
    {
//        Instantiate(cellTerrain.terrainPrefab, grid.GetWorldPosition(x, y), Quaternion.identity);
    }
}
