using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PedroG.UsefulFuncs;

public class TestingTerrain : MonoBehaviour
{
    private TerrainManager terrainMap;

    [Header("Diz se alo se iniciar a cena ele deve desenhar o grid para referencia")] public bool showDebug = true;
    [Header("Largura dos grids")] public int width = 10;
    [Header("Altura dos grids")] public int height = 10;
    [Header("Tamanho da celula do grid")] public int cellSize = 5;

    public Terrain testTerrain1;
    public Terrain testTerrain2;

    // Start is called before the first frame update
    void Start()
    {
        terrainMap = new TerrainManager(width, height, cellSize, Vector3.zero, showDebug);        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 worldPos = UsefulFunctions.GetMouseWorldPosition();
            TerrainObject terrain = terrainMap.GetGrid().GetGridObject(worldPos);
            if (terrain != null)
            {                
                terrain.SetTerrainType(testTerrain2);
            }
        }

        if (Input.GetMouseButtonDown(1))
        {

            Vector3 worldPos = UsefulFunctions.GetMouseWorldPosition();
            TerrainObject terrain = terrainMap.GetGrid().GetGridObject(worldPos);
            if (terrain != null)
            {                
                //terrain.SetTerrainType(testTerrain);
                Debug.Log(terrain.GetTerrainName());
            }
        }
    }
}
