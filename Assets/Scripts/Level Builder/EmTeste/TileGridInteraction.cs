using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PedroG.UsefulFuncs;
using CodeMonkey.Utils;

public class TileGridInteraction : MonoBehaviour
{
    public int selectedTileIndex = 0;
    private Tilemap tilemap;
    [SerializeField] TilemapVisual tilemapVisual;
    [Header("Diz se alo se iniciar a cena ele deve desenhar o grid para referencia")] public bool showDebug = true;
    [Header("Largura dos grids")] public int width = 10;
    [Header("Altura dos grids")] public int height = 10;
    [Header("Tamanho da celula do grid")] public int cellSize = 5;
    [HideInInspector]public int rotValue;
    [HideInInspector]public bool rotatePreview;

    private void Start()
    {

        tilemap = new Tilemap(width, height, cellSize, Vector3.zero, showDebug);
        tilemapVisual = GetComponent<TilemapVisual>();
        tilemapVisual.SetGrid(tilemap, tilemap.GetGrid());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            rotatePreview = true;
            int check = selectedTileIndex;
            if (++check <= Enum.GetValues(typeof(Tile.TileType)).Length - 1)
                selectedTileIndex++;
            else
                selectedTileIndex = 0;

            rotValue = 0;
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            rotatePreview = true;
            int check = selectedTileIndex;
            if (--check >= 0)
                selectedTileIndex--;
            else
                selectedTileIndex = Enum.GetValues(typeof(Tile.TileType)).Length - 1;
            rotValue = 0;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            rotatePreview = true;
            Vector3 worldPos = UsefulFunctions.GetMouseWorldPosition();
            if (rotValue < 3)
                rotValue++;
            else
                rotValue = 0;
            //tilemap.SetTilemapObjectRotation(worldPos, rotValue);
            
        }

        /*if (Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("Pre call");
            tilemap.Save();
            Debug.Log("Pos call");
            CodeMonkey.CMDebug.TextPopupMouse("Salvou!");
        }*/

        /*if (Input.GetKeyDown(KeyCode.L))
        {
            tilemap.Load();
            CodeMonkey.CMDebug.TextPopupMouse("Salvou!");
        }*/

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 worldPos = UsefulFunctions.GetMouseWorldPosition();
            Tile tile = tilemap.GetGrid().GetGridObject(worldPos);
            if (tile != null) {
            string enumm = Enum.GetName(typeof(Tile.TileType), 2);
                tilemap.SetTilemapObjectSprite(worldPos, EnumHelper.GetEnumValue<Tile.TileType>(selectedTileIndex));
                tilemap.SetTilemapObjectRotation(worldPos, rotValue);
            }
        }
    }
}
