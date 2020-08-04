using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilemapVisual : MonoBehaviour
{

    //Referencia ao grid que vai ser usado
    private Grid<Tile> grid;
    public bool updateMesh;

    public GameObject[] tilesPrefab;

    private int listIndex;
    public List<Tile.TileType> tileTypesList = new List<Tile.TileType>();
    [SerializeField]private GameObject[] tileObjects;
    private int totalCellCount;

    public void Awake()
    {
        /*mesh = new Mesh();

        GetComponent<MeshFilter>().mesh = mesh;*/
    }

    private void LateUpdate()
    {
        if (updateMesh)
        {
            updateMesh = false;
            UpdateNodeVisual();
        }
    }

    public void SetGrid(Tilemap tilemap, Grid<Tile> grid)
    {
        this.grid = grid;
        //totalCellCount = this.grid.GetWidth() * this.grid.GetHeight();
        
        UpdateNodeVisual();

        grid.OnGridCellValueChanged += Grid_OnGridCellValueChanged;
        tilemap.OnLoaded += Grid_OnGridLoaded;
    }

    public void Grid_OnGridCellValueChanged(object sender, Grid<Tile>.OnGridCellValueChangedEventArgs e)
    {
        updateMesh = true;
    }

    private void Grid_OnGridLoaded(object sender, EventArgs e)
    {
        updateMesh = true;
    }

    public void ChangeTotalCellCount(int width, int height)
    {
        if(totalCellCount != 0)
        {
            if(totalCellCount != width * height)
            {
                totalCellCount = width * height;
                Debug.Log("Testing");
                tileObjects = new GameObject[totalCellCount];
            }
            
        }
        else
        {
            totalCellCount = width * height;
            tileObjects = new GameObject[totalCellCount];
        }
    }

    private void UpdateNodeVisual()
    {           
        listIndex = 0;
        ChangeTotalCellCount(grid.width, grid.height);
        for (int x = 0; x < grid.GetWidth(); x++)
        {
            for (int y = 0; y < grid.GetHeight(); y++)
            {
                int index = x * grid.GetHeight() + y;
                Vector3 quadSize = new Vector3(1, 1) * grid.GetCellSize(); ;

                // Pegar o valor do grid alterado                
                //Debug.Log("tileTypesList.Count = " + tileTypesList.Count + ", totalCellCount = " + totalCellCount.ToString());
                Tile currentTile = grid.GetGridObject(x, y);
                if (tileTypesList.Count < totalCellCount)
                {
                    tileTypesList.Add(Tile.TileType.Planice);
                    int enumIndex = (int)currentTile.tileType;
                    GameObject tileObject = Instantiate(tilesPrefab[enumIndex], grid.GetWorldPosition(x, y) + quadSize * .5f, Quaternion.identity);
                    tileObject.transform.localScale = new Vector3(tileObject.transform.localScale.x * grid.GetCellSize(), tileObject.transform.localScale.y * grid.GetCellSize(), 1);
                    tileObjects[listIndex] = tileObject;
                }
                //Debug.Log("tileTypesList.Count = " + tileTypesList.Count + ", totalCellCount = " + totalCellCount.ToString());
                if (tileTypesList[listIndex] != currentTile.tileType)
                {

                    tileTypesList[listIndex] = currentTile.tileType;
                    int enumIndex = (int)currentTile.tileType;
                    GameObject tileObject = Instantiate(tilesPrefab[enumIndex], grid.GetWorldPosition(x, y) + quadSize * .5f, Quaternion.identity);
                    tileObject.transform.localScale = new Vector3(tileObject.transform.localScale.x * grid.GetCellSize(), tileObject.transform.localScale.y * grid.GetCellSize(), 1);
                    if (tileObjects[listIndex] != null)
                        Destroy(tileObjects[listIndex]);
                    tileObjects[listIndex] = tileObject;
                }

                listIndex++;
            }
        }
    }
}
