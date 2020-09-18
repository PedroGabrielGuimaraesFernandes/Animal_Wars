using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainObject
{
    private Grid<TerrainObject> grid;
    private int x;
    private int y;    

    private List<TerrainObject> neighbors = new List<TerrainObject>();

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
        //cellTerrain.ItsPossible();
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

    public void SetNeighbors()
    {
        #region Horizontal, vertical e diagonal
        //Horizontal, vertical e diagonal
        /*if (neighbors.Count <= 0)
        {            
        int startX, startY, endX, endY;
        startX = (x - 1 >= 0) ? x-1 : x;
        startY = (y - 1 >= 0) ? y-1 : y;
        endX = (x + 1 <= grid.GetWidth() - 1) ? x + 1 : x;
        endY = (y +1 <= grid.GetHeight() - 1) ? y + 1 : y;
        for (int x = startX; x <= endX; x++)
        {
            for (int y = startY; y <= endY; y++)
            {
                if(x != this.x || y != this.y)
                neighbors.Add(grid.GetGridObject(x, y));
            }
        }
        Debug.Log("Setou os vizinhos" + neighbors.Count);
        }*/
        #endregion

        //Horizontal e vertical
        if (neighbors.Count <= 0)
        {
            //Esquerda
            if ((x - 1 >= 0))
                neighbors.Add(grid.GetGridObject(x - 1, y));
            //Direita
            if ((x + 1 <= grid.GetWidth() - 1))
                neighbors.Add(grid.GetGridObject(x + 1, y));
            //Em baixo
            if (y - 1 >= 0)
                neighbors.Add(grid.GetGridObject(x, y - 1));
            //Em cima
            if (y + 1 <= grid.GetHeight() - 1)
                neighbors.Add(grid.GetGridObject(x, y + 1));
        }
    }

    public List<TerrainObject> GetNeighbors()
    {
        if (neighbors.Count <= 0)
        {
            SetNeighbors();
        }
        return neighbors;
    }

    public void PrintNeighbors()
    {
        int neighborIndex = 0;
        foreach (TerrainObject neighbor in GetNeighbors())
        {
            Debug.Log("Origin : " + x + ", " + y + "| Vizinho " + neighborIndex + ": " + neighbor.x + ", " + neighbor.y);
            neighborIndex++;
        }
    }

    public string GetTerrainName()
    {
        return cellTerrain.name;
    }

    public Terrain CellTerrainType()
    {
        return cellTerrain;
    }
}
