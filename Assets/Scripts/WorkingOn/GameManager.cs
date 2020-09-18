using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    [Header("Referencia ao tilmanager")] public TileManager tileManager;
    [Header("Referencia ao tilmap usado para desenha o mapa do jogo")] public Tilemap terrainMap;
    [Header("Referencia ao tilmap usado para o preview de movimento e de ataque")] public Tilemap previewMap;
    [Header("Referencia ao tilmap usado para a seta")] public Tilemap arrowMap;
    [Header("Referencia ao level generator")] public TilemapGenerator levelGenerator;



    public int[,] gridArray = new int[5,5];

    private void Start()
    {
        instance = this;
        levelGenerator = GetComponent<TilemapGenerator>();
        for (int x = 0; x < gridArray.GetLength(0); x++)
        {
            for (int y = 0; y < gridArray.GetLength(1); y++)
            {
                //bool teste = (gridArray[x, y] != null);
                //Debug.Log("x: " + x + " y: " + y + " Tem no grid Array" );
            }
        }
    }
}
