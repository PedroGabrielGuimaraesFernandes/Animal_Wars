using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;
using CodeMonkey.MonoBehaviours;

public class HeatMapVisual : MonoBehaviour
{
    //Referencia ao grid que vai ser usado
    private Grid grid;
    private Mesh mesh;
    public bool updateMesh;

    public void Awake()
    {
        mesh = new Mesh();

        GetComponent<MeshFilter>().mesh = mesh;
    }

    private void LateUpdate()
    {
        if (updateMesh)
        {
            updateMesh = false;
           // UpdateHeatMapVisual();
        }
    }

    public void SetGrid(Grid grid)
    {
        this.grid = grid;
        //UpdateHeatMapVisual();

        //grid.OnGridCellValueChanged += Grid_OnGridCellValueChanged;
    }

    /*public void Grid_OnGridCellValueChanged(object sender, Grid.OnGridCellValueChangedEventArgs e)
    {
        //UpdateHeatMapVisual();
        updateMesh = true;
    }

    private void UpdateHeatMapVisual()
    {
        MeshUtils.CreateEmptyMeshArrays(grid.GetWidth() * grid.GetHeight(), out Vector3[] vertices, out Vector2[] uv, out int[] triangles);

        for (int x = 0; x < grid.GetWidth(); x++)
        {
            for (int y = 0; y < grid.GetHeight(); y++)
            {
                int index = x * grid.GetHeight() + y;
                Vector3 quadSize = new Vector3(1, 1) * grid.GetCellSize(); ;

                // Pegar o valor do grid alterado
                int gridValue = grid.GetValue(x, y);
                // Fao calculo da porcentagem do valor equivalente
                float gridValueNormalized = (float)gridValue / Grid.HEAT_MAP_MAX_VALUE;
                Vector2 gridValueUv = new Vector2(gridValueNormalized, 0f);
                MeshUtils.AddToMeshArrays(vertices, uv, triangles, index, grid.GetWorldPosition(x, y) + quadSize * .5f, 0f, quadSize, gridValueUv, gridValueUv);
            }
        }

        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangles;
    }*/
}
