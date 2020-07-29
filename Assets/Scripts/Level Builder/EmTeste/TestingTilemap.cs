using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PedroG.UsefulFuncs;

public class TestingTilemap : MonoBehaviour
{
    //private Grid<Tile> grid;
    public int testInt = 0;
    private Tilemap tilemap;
    [SerializeField] TilemapVisual tilemapVisual;
    [Header("Diz se alo se iniciar a cena ele deve desenhar o grid para referencia")]public bool showDebug = true;
    [Header("Largura dos grids")] public int width = 10;
    [Header("Altura dos grids")] public int height = 10;
    [Header("Tamanho da celula do grid")] public int cellSize = 5;

    private void Start()
    {

        tilemap = new Tilemap(width, height, cellSize, Vector3.zero, showDebug);

        tilemapVisual.SetGrid(tilemap.GetGrid());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            int check = testInt;
            if (++check <= Enum.GetValues(typeof(Tile.TileType)).Length - 1)
                testInt++;
            else
                testInt = 0;           
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            int check = testInt;
            if (--check >= 0)
                testInt--;
            else
                testInt = Enum.GetValues(typeof(Tile.TileType)).Length - 1;
        }

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 worldPos = UsefulFunctions.GetMouseWorldPosition();
            string enumm = Enum.GetName(typeof(Tile.TileType), 2);
            tilemap.SetTilemapObjectSprite(worldPos, EnumHelper.GetEnumValue<Tile.TileType>(testInt));            
        }
    }
}
