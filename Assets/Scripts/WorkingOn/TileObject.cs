using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileObject
{
    //Precisa conter referncia ao terreno, referencia a unidade(Mesmo que a casa esteja vazia)
    //Parte de identificação da celula

    private Grid<TileObject> tileGrid;
    private int tileX;
    private int tileY;

    private List<TileObject> neighbors = new List<TileObject>();

    //parte do terreno
    private Terrain cellTerrain = Resources.Load<Terrain>("Terrenos/Planice");

    //parte da unidade
    private Unit cellUnit;

    public TileObject(Grid<TileObject> grid, int x, int y)
    {
        tileGrid = grid;
        tileX = x;
        tileY = y;

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
