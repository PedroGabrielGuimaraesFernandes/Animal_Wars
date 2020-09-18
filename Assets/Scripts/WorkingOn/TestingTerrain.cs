using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using PedroG.UsefulFuncs;

public class TestingTerrain : MonoBehaviour
{
    private TerrainManager terrainMap;

    public Tilemap tilemap;

    public TileBase testTile1;
    public TileBase testTile2;

    [Header("Diz se alo se iniciar a cena ele deve desenhar o grid para referencia")] public bool showDebug = true;
    [Header("Largura dos grids")] public int width = 10;
    [Header("Altura dos grids")] public int height = 10;
    [Header("Tamanho da celula do grid")] public int cellSize = 5;

    public Terrain testTerrain1;
    public Terrain testTerrain2;

    private void Awake()
    {
        tilemap.origin = Vector3Int.zero;
        tilemap.size = new Vector3Int(width, height, 1);
        tilemap.ResizeBounds();
        tilemap.RefreshAllTiles();
    }

    private void Start()
    {
        terrainMap = new TerrainManager(width, height, cellSize, Vector3.zero, tilemap, showDebug);
        UI_GridStats.ChangeWidthText("Width: " + width.ToString());
        UI_GridStats.ChangeHeightText("Height: " + height.ToString());
    }

    // Update is called once per frame
    void LateUpdate()
    {

        int intx, inty;        

        if (Input.GetKeyDown(KeyCode.R))
        {
            terrainMap.GetGrid().ResizeGrid(width, height, (Grid<TerrainObject> g, int x, int y) => new TerrainObject(g, x, y));
            tilemap.size = new Vector3Int(width, height, 1);            
            tilemap.ResizeBounds();
            tilemap.RefreshAllTiles();
            terrainMap.ReconstructTilemap();
        }

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 worldPos = UsefulFunctions.GetMouseWorldPositionWithZ();
            terrainMap.GetGrid().GetXY(worldPos, out intx, out inty);
            Vector3Int worldPosInt = tilemap.WorldToCell(worldPos);
            if (worldPos.x >= 0 && worldPos.y >= 0 && worldPos.x < tilemap.size.x && worldPos.y < tilemap.size.y)
            {                
                tilemap.SetTile(worldPosInt, testTile1);
            }
        }


        if (Input.GetMouseButtonDown(1))
        {
            Vector3 worldPos = UsefulFunctions.GetMouseWorldPositionWithZ();
            Vector3Int worldPosInt = tilemap.WorldToCell(worldPos);
            if (worldPos.x >= 0 && worldPos.y >= 0 && worldPos.x < tilemap.size.x && worldPos.y < tilemap.size.y)
            {
                tilemap.SetTile(worldPosInt, testTile2);             
            }            
        }              
    }

    public void DecreaseWidth()
    {
        if (width > 1)
        {
            width--;
        }
        UI_GridStats.ChangeWidthText("Width: " + width.ToString());
    }

    public void DecreaseHeight()
    {
        if (height > 1)
        {
            height--;
        }
        UI_GridStats.ChangeHeightText("Height: " + height.ToString());
    }

    public void IncreaseWidth()
    {        
            width++;        
        UI_GridStats.ChangeWidthText("Width: " + width.ToString());
    }

    public void IncreaseHeight()
    {
            height++;        
        UI_GridStats.ChangeHeightText("Height: " + height.ToString());
    }
}
