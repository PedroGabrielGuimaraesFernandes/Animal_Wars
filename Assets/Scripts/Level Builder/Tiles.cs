using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tiles
{
    // parte necessaria para saber onde no grid se encontra e interagir com ele 
    private Grid<Tiles> grid;
    private int x;
    private int y;

    public enum TileType { Planice, Floresta, Montanha, Cidade, Estrada, Ponte, Pantano, BaseMilitar, Aeroporto, Porto, Oceano, Praia, Recife, Marbravo, Ruinas, TerraDevastada };
    public TileType tileType;
    public int tileRotation;

    public BasicUnit unit;
    public BasicTerrain terrain;



    public Tiles(Grid<Tiles> tileGrid, int x, int y)
    {
        this.grid = tileGrid;
        this.x = x;
        this.y = y;
    }

    public void SetTileType(TileType tileType)
    {

        this.tileType = tileType;
        grid.TriggerGridObjectChanged(x, y);

    }

    public void SetTileRotation(int rot)
    {
        this.tileRotation = rot;
        grid.TriggerGridObjectChanged(x, y);
    }



    public override string ToString()
    {
        return tileType.ToString();
    }
    [Serializable]
    public class SaveObject{
    public TileType tileType;
    public int x;
    public int y;
    public int tileRotation;
        }

    public SaveObject Save()
    {
        return new SaveObject
        {
            tileType = tileType,
            x = x,
            y = y,
            tileRotation = tileRotation,
        };
    }

    public void Load(SaveObject saveObject)
    {
        SetTileType(saveObject.tileType);
        SetTileRotation(saveObject.tileRotation);
    }
}
