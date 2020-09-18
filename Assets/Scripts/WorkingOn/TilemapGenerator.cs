using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilemapGenerator : MonoBehaviour
{
    public GameManager gameManager;
    private static TilemapGenerator instance;
    private TileManager tileManager;
    [Header("Diz se alo se iniciar a cena ele deve desenhar o grid para referencia")] public bool showDebug = true;
    [Header("Largura dos grids")] public int width = 16;
    [Header("Altura dos grids")] public int height = 8;
    [Header("Tamanho da celula do grid")] public int cellSize = 1;

    private void Start()
    {
        instance = this;        
    }

    public void CreateLevel()
    {
        tileManager = new TileManager(width, height, cellSize, Vector3.zero, gameManager.terrainMap, showDebug);
    }
}
