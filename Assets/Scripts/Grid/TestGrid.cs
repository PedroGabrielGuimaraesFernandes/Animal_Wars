using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using PedroG.UsefulFuncs;

public class TestGrid : MonoBehaviour
{
    [Header("Numero de linha e colunas que formam o grid")]
    public int rows = 5;//linha
    public int columns = 5;//Colunas 
    [Header("Tamanho da celula do grid")]
    public int cellsize;

    public Tilemap tilemap;

    public GameObject spawnedObject;

    private void Awake()
    {
        /*Debug.Log("Tilemap: Width = " + tilemap.size + "");

        tilemap.origin = Vector3Int.zero;
        tilemap.size = new Vector3Int(columns, rows, 1);
        tilemap.ResizeBounds();
        tilemap.RefreshAllTiles();
        Debug.Log("Tilemap: Width = " + tilemap.size + "");*/
        //spawnedObject;
        /* for (int x = 0; x < columns; x++)
         {
             for (int y = 0; y < rows; y++)
             {
                 Debug.Log("Coluna: " + x + " Linha: " + y);

                 GameObject spawnedObj = Instantiate(spawnedObject, new Vector3(x + .5f + cellsize / 2, y + .5f + cellsize / 2),Quaternion.identity) ;
                 spawnedObj.name = "Objecto: x = " + x + ", y = " + y;
             }
         }*/
    }

    private void LateUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 worldPos = UsefulFunctions.GetMouseWorldPositionWithZ();
            Vector3Int worldPosInt = tilemap.WorldToCell(worldPos);
            if (tilemap.HasTile(worldPosInt)/*  .HasTile(worldPosInt)*/)
            {
                Debug.Log("Achou um tile em " + worldPosInt);
            }
            else
            {
                Debug.Log("Não achou nada em " + worldPosInt);
            }
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            rows++;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (rows > 1)
            {
                rows--;
            }
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            columns++;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (columns > 1)
            {
                columns--;
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            tilemap.origin = Vector3Int.zero;
            tilemap.size = new Vector3Int(columns, rows, 1);
            tilemap.ResizeBounds();
            tilemap.RefreshAllTiles();
        }
    }

}
