using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PedroG.UsefulFuncs;

public class Tilemap
{
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
    /// <summary>
    /// /////////////////////////////////////////////////////////
    /// </summary>
    public class TilemapObject
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
    }
}


