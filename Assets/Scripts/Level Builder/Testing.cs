using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class Testing : MonoBehaviour
{

    private Grid grid;
    // Start is called before the first frame update
    void Start()
    {
        grid = new Grid(4, 2, 10f, new Vector3(0,0));        

    }

    private void Update()
    {
        Vector3 mousePos;
        Vector3 worldPos;
        if (Input.GetMouseButtonDown(0))
        {
            mousePos = Input.mousePosition;            
            worldPos = Camera.main.ScreenToWorldPoint(mousePos);
            //grid.SetValue(worldPos, 56);
            grid.SetValue(UtilsClass.GetMouseWorldPosition(), 56);
        }

        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log(grid.GetValue(UtilsClass.GetMouseWorldPosition()));
        }
    }

}
