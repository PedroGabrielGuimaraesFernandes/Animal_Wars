using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;
using PedroG.UsefulFuncs;

public class Testing : MonoBehaviour
{
    [SerializeField] private HeatMapVisual heatMapVisual;
    private Grid grid;
    public bool showDebug = true;
    // Start is called before the first frame update
    void Start()
    {
        grid = new Grid(100, 100, 4f, new Vector3(0,0), showDebug);

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
            grid.AddValue(worldPos, 100, 5, 40);          
        }

        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log(grid.GetValue(UtilsClass.GetMouseWorldPosition()));
        }
    }

}
