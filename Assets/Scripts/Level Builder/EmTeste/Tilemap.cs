using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PedroG.UsefulFuncs;

public class Tilemap
{
    public EventHandler OnLoaded;

    private Grid<Tile> tileGrid;


    public Tilemap(int width, int height, int cellSize, Vector3 origin, bool showDebug)
    {
        tileGrid = new Grid<Tile>(width, height, cellSize, origin, (Grid<Tile> g, int x, int y) => new Tile(g, x, y), showDebug);
    }

    public Grid<Tile> GetGrid()
    {
        return tileGrid;
    }

    public void SetTilemapObjectSprite(Vector3 worldPos, Tile.TileType tipeType)
    {
        Tile tilemapObject = tileGrid.GetGridObject(worldPos);
        if (tilemapObject != null)
            tilemapObject.SetTileType(tipeType);
    }

    public void Save()
    {
        List<Tile.SaveObject> tileSaveObjectList = new List<Tile.SaveObject>();
        for (int x = 0; x < tileGrid.GetWidth(); x++)
        {
            for (int y = 0; y < tileGrid.GetHeight(); y++)
            {
                Tile tile = tileGrid.GetGridObject(x, y);
                tileSaveObjectList.Add(tile.Save());
            }
        }

        SaveObject saveObject = new SaveObject { tileSaveObjectArray = tileSaveObjectList.ToArray()};

        SaveSystem.SaveObject(saveObject);
    }

    public void Load()
    {
        SaveObject saveObject = SaveSystem.LoadMostRecentSaveObject<SaveObject>();
        foreach (Tile.SaveObject tileSaveObject in saveObject.tileSaveObjectArray)
        {
            Tile tile = tileGrid.GetGridObject(tileSaveObject.x, tileSaveObject.y);
            tile.Load(tileSaveObject);
        }

        OnLoaded?.Invoke(this, EventArgs.Empty) ;
    }

    public class SaveObject
    {
        public Tile.SaveObject[] tileSaveObjectArray;
    }

   
}


    /// <summary>
    /// /////////////////////////////////////////////////////////
    /// </summary>
   /* public class TilemapObject
    {
        //Tipos de terreno
        public enum TileType { Planice, Floresta, Montanha, };
        public TileType tileType;

        private Grid<TilemapObject> grid;
        private int x;
        private int y;

        public TilemapObject(Grid<TilemapObject> tileGrid, int x, int y)
        {
            this.grid = tileGrid;
            this.x = x;
            this.y = y;

        }

        public void SetTileType(TileType tileType)
        {
            this.tileType = tileType;
            //Debug.Log(x +"," + y);
            grid.TriggerGridObjectChanged(x, y);
        }

        public override string ToString()
        {
            return tileType.ToString();
        }
    }*/



