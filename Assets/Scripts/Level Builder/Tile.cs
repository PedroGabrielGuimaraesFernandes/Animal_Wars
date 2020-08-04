using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tile
{
    // parte necessaria para saber onde no grid se encontra e interagir com ele 
    private Grid<Tile> grid;
    private int x;
    private int y;

    public enum TileType { Planice, Floresta, Montanha, Cidade, Estrada, Ponte, Pantano, BaseMilitar, Aeroporto, POrto, Oceano, Praia, Recife, Marbravo, Ruinas, TerraDevastada };
    public TileType tileType;

    //public string tileName = "Vazio";
    //public Sprite tileSprite;
    //public string specialEffect = "Vazio";
    //public int[] movementCost = new int[3];
    //public int[] defenseBonus = new int[3];

    public Tile(Grid<Tile> tileGrid, int x, int y)
    {
        this.grid = tileGrid;
        this.x = x;
        this.y = y;
        /*this.tileType = tileType;
        this.tileName = tileName;
        this.tileSprite = tileSprite;
        this.specialEffect = specialEffect;
        this.movementCost = movementCost;
        this.defenseBonus = defenseBonus;*/
    }

    public void SetTileType(TileType tileType)
    {

        this.tileType = tileType;
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
        }

    public SaveObject Save()
    {
        return new SaveObject
        {
            tileType = tileType,
            x = x,
            y = y,
        };
    }

    public void Load(SaveObject saveObject)
    {
        SetTileType(saveObject.tileType);
    }
}
