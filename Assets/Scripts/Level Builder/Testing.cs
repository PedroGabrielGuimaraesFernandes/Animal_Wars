using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;
using PedroG.UsefulFuncs;

public class Testing : MonoBehaviour
{
    [SerializeField] private HeatMapVisual heatMapVisual;
    private Grid grid;
    // Start is called before the first frame update
    void Start()
    {
        grid = new Grid(10, 10, 10f, new Vector3(0,0));

        heatMapVisual.SetGrid(grid);
    }

    private void Update()
    {
        //Vector3 mousePos;
        Vector3 worldPos;
        if (Input.GetMouseButtonDown(0))
        {
            /*mousePos = Input.mousePosition;            
            worldPos = Camera.main.ScreenToWorldPoint(mousePos);*/
            worldPos = UsefulFunctions.GetMouseWorldPosition();
            int value = grid.GetValue(worldPos);
            grid.SetValue(worldPos, value + 5);            
        }

        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log(grid.GetValue(UtilsClass.GetMouseWorldPosition()));
        }
    }

}
