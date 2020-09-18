using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PedroG.UsefulFuncs;

public class Tilemaps
{
    private static Tilemaps instance;

    public EventHandler OnLoaded;

    private Grid<Tiles> tileGrid;



    public Tilemaps(int width, int height, int cellSize, Vector3 origin, bool showDebug)
    {
        tileGrid = new Grid<Tiles>(width, height, cellSize, origin, (Grid<Tiles> g, int x, int y) => new Tiles(g, x, y), showDebug);
        instance = this;
    }

    public Grid<Tiles> GetGrid()
    {
        return tileGrid;
    }

    public void SetTilemapObjectSprite(Vector3 worldPos, Tiles.TileType tipeType)
    {
        Tiles tilemapObject = tileGrid.GetGridObject(worldPos);
        if (tilemapObject != null)
            tilemapObject.SetTileType(tipeType);
    }

    public void SetTilemapObjectRotation(Vector3 worldPos, int tileRot)
    {
        Tiles tilemapObject = tileGrid.GetGridObject(worldPos);
        tileGrid.GetXY(worldPos, out int x, out int y);
        tileGrid.TriggerGridObjectChanged(x, y);
       /* if (tilemapObject.tileRotation < 3)
            tilemapObject.tileRotation++;
        else
            tilemapObject.tileRotation = 0;*/
        tilemapObject.SetTileRotation(tileRot);
    }

    public void Save(string filename, bool overwrite)
    {
        List<Tiles.SaveObject> tileSaveObjectList = new List<Tiles.SaveObject>();
        for (int x = 0; x < tileGrid.GetWidth(); x++)
        {
            for (int y = 0; y < tileGrid.GetHeight(); y++)
            {
                Tiles tile = tileGrid.GetGridObject(x, y);
                tileSaveObjectList.Add(tile.Save());
            }
        }

        SaveObject saveObject = new SaveObject { tileSaveObjectArray = tileSaveObjectList.ToArray()};
        //if(filename.Length >= 1)
        SaveSystem.SaveObject(filename, saveObject, overwrite);
        //else 
    }

    public void Load(string filename)
    {
        //SaveObject saveObject = SaveSystem.LoadMostRecentSaveObject<SaveObject>();
        SaveObject saveObject = SaveSystem.LoadObject<SaveObject>(filename);
        foreach (Tiles.SaveObject tileSaveObject in saveObject.tileSaveObjectArray)
        {
            Tiles tile = tileGrid.GetGridObject(tileSaveObject.x, tileSaveObject.y);
            tile.Load(tileSaveObject);
        }

        OnLoaded?.Invoke(this, EventArgs.Empty) ;
    }

    public class SaveObject
    {
        public Tiles.SaveObject[] tileSaveObjectArray;
    }

   
    public static void Static_Save(string filename)
    {
        instance.Save(filename, false);
    }

    public static void Static_Save_Overwrite(string filename)
    {
        instance.Save(filename, true);
    }

    public static void  Static_Load(string filename)
    {
        instance.Load(filename);
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



