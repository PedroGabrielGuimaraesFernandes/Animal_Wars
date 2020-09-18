using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ObjectGrid : MonoBehaviour
{
    public GameObject[,] objetosGrid;
    public GameObject empty;

    public int width = 5;
    public int height = 5;
    public int cellSize = 1;

    // Start is called before the first frame update
    void Start()
    {
        empty = new GameObject();
        objetosGrid = new GameObject[width, height];
        Vector3 cellPos = new Vector3(1, 1) * cellSize;
         
        for (int gridX = 0; gridX < width; gridX++)
        {
            for (int gridY = 0; gridY < height; gridY++)
            {
                objetosGrid[gridX, gridY] = Instantiate( empty , Vector3.zero +( new Vector3(gridX, gridY) + cellPos * .5f),Quaternion.identity);
                objetosGrid[gridX, gridY].name = "Objeto " + gridX + " " + gridY;
                
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
