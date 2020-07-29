using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;
using PedroG.UsefulFuncs;

public class Testing : MonoBehaviour
{
    [SerializeField] private HeatMapVisual heatMapVisual;
    [SerializeField] private HeatMapBoolVisual heatMapBoolVisual;
    [SerializeField] private HeatMapGenericVisual heatMapGenericVisual;
    
    private Grid<HeatMapGridObject> grid;
    private Grid<bool> boolGrid;
    private Grid<StringGridMapObject> stringGrid;
    public bool showDebug = true;
    [Header("Largura dos grids")]public int width = 10;
    [Header("Altura dos grids")] public int height = 10;
    [Header("Tamalho de uma celula")]public int cellsize = 5;
    // Start is called before the first frame update
    void Start()
    {
        grid = new Grid<HeatMapGridObject>(20, 20, 10f, new Vector3(0,0), (Grid<HeatMapGridObject> g, int x, int y) => new HeatMapGridObject(g, x, y), showDebug);
        boolGrid = new Grid<bool>(width, height, cellsize, new Vector3(0,0), (Grid<bool> g, int x, int y) => new bool(), showDebug);
        stringGrid = new Grid<StringGridMapObject>(width, height, cellsize, new Vector3(0, 0), (Grid<StringGridMapObject> g, int x, int y) => new StringGridMapObject(g, x, y), showDebug);
        //heatMapVisual.SetGrid(grid);
        heatMapBoolVisual.SetGrid(boolGrid);
        //heatMapGenericVisual.SetGrid(grid);        grid = new Grid<bool>(20, 20, 10f, new Vector3(0,0), new bool, showDebug);

    }

    private void Update()
    {
        
        Vector3 worldPos;
        worldPos = UsefulFunctions.GetMouseWorldPosition();
        if (Input.GetMouseButtonDown(0))
        {
            worldPos = UsefulFunctions.GetMouseWorldPosition();
            //HeatMapGridObject heatMapGridObject = grid.GetGridObject(worldPos);/*Retorna um HeatMapGridObject*/
            // Porque estamos instantiando um heatMapGridObject, é preciso fazer um null check
            /*if(heatMapGridObject != null)
            {
                heatMapGridObject.AddValue(5);
            }*/
             boolGrid.SetGridObject(worldPos, !boolGrid.GetGridObject(worldPos));

        }

        //Input das letras

        if (Input.GetKeyDown(KeyCode.A)){string temp; temp = Input.GetKey(KeyCode.LeftShift)? "A" : "a"; stringGrid.GetGridObject(worldPos).AddLetter(temp);}
        if (Input.GetKeyDown(KeyCode.B)){string temp; temp = Input.GetKey(KeyCode.LeftShift)? "B" : "b"; stringGrid.GetGridObject(worldPos).AddLetter(temp);}
        if (Input.GetKeyDown(KeyCode.C)){string temp; temp = Input.GetKey(KeyCode.LeftShift)? "C" : "c"; stringGrid.GetGridObject(worldPos).AddLetter(temp);}
        if (Input.GetKeyDown(KeyCode.D)){string temp; temp = Input.GetKey(KeyCode.LeftShift)? "D" : "d"; stringGrid.GetGridObject(worldPos).AddLetter(temp);}
        if (Input.GetKeyDown(KeyCode.E)){string temp; temp = Input.GetKey(KeyCode.LeftShift)? "E" : "e"; stringGrid.GetGridObject(worldPos).AddLetter(temp);}
        if (Input.GetKeyDown(KeyCode.F)){string temp; temp = Input.GetKey(KeyCode.LeftShift)? "F" : "f"; stringGrid.GetGridObject(worldPos).AddLetter(temp);}
        if (Input.GetKeyDown(KeyCode.G)){string temp; temp = Input.GetKey(KeyCode.LeftShift)? "G" : "g"; stringGrid.GetGridObject(worldPos).AddLetter(temp);}
        if (Input.GetKeyDown(KeyCode.H)){string temp; temp = Input.GetKey(KeyCode.LeftShift)? "H" : "h"; stringGrid.GetGridObject(worldPos).AddLetter(temp);}
        if (Input.GetKeyDown(KeyCode.I)){string temp; temp = Input.GetKey(KeyCode.LeftShift)? "I" : "i"; stringGrid.GetGridObject(worldPos).AddLetter(temp);}
        if (Input.GetKeyDown(KeyCode.J)){string temp; temp = Input.GetKey(KeyCode.LeftShift)? "J" : "j"; stringGrid.GetGridObject(worldPos).AddLetter(temp);}
        if (Input.GetKeyDown(KeyCode.K)){string temp; temp = Input.GetKey(KeyCode.LeftShift)? "K" : "k"; stringGrid.GetGridObject(worldPos).AddLetter(temp);}
        if (Input.GetKeyDown(KeyCode.L)){string temp; temp = Input.GetKey(KeyCode.LeftShift)? "L" : "l"; stringGrid.GetGridObject(worldPos).AddLetter(temp);}
        if (Input.GetKeyDown(KeyCode.M)){string temp; temp = Input.GetKey(KeyCode.LeftShift)? "M" : "m"; stringGrid.GetGridObject(worldPos).AddLetter(temp);}
        if (Input.GetKeyDown(KeyCode.N)){string temp; temp = Input.GetKey(KeyCode.LeftShift)? "N" : "n"; stringGrid.GetGridObject(worldPos).AddLetter(temp);}
        if (Input.GetKeyDown(KeyCode.O)){string temp; temp = Input.GetKey(KeyCode.LeftShift)? "O" : "o"; stringGrid.GetGridObject(worldPos).AddLetter(temp);}
        if (Input.GetKeyDown(KeyCode.P)){string temp; temp = Input.GetKey(KeyCode.LeftShift)? "P" : "p"; stringGrid.GetGridObject(worldPos).AddLetter(temp);}
        if (Input.GetKeyDown(KeyCode.Q)){string temp; temp = Input.GetKey(KeyCode.LeftShift)? "Q" : "q"; stringGrid.GetGridObject(worldPos).AddLetter(temp);}
        if (Input.GetKeyDown(KeyCode.R)){string temp; temp = Input.GetKey(KeyCode.LeftShift)? "R" : "r"; stringGrid.GetGridObject(worldPos).AddLetter(temp);}
        if (Input.GetKeyDown(KeyCode.S)){string temp; temp = Input.GetKey(KeyCode.LeftShift)? "S" : "s"; stringGrid.GetGridObject(worldPos).AddLetter(temp);}
        if (Input.GetKeyDown(KeyCode.T)){string temp; temp = Input.GetKey(KeyCode.LeftShift)? "T" : "t"; stringGrid.GetGridObject(worldPos).AddLetter(temp);}
        if (Input.GetKeyDown(KeyCode.U)){string temp; temp = Input.GetKey(KeyCode.LeftShift)? "U" : "u"; stringGrid.GetGridObject(worldPos).AddLetter(temp);}
        if (Input.GetKeyDown(KeyCode.V)){string temp; temp = Input.GetKey(KeyCode.LeftShift)? "V" : "v"; stringGrid.GetGridObject(worldPos).AddLetter(temp);}
        if (Input.GetKeyDown(KeyCode.W)){string temp; temp = Input.GetKey(KeyCode.LeftShift)? "W" : "w"; stringGrid.GetGridObject(worldPos).AddLetter(temp);}
        if (Input.GetKeyDown(KeyCode.X)){string temp; temp = Input.GetKey(KeyCode.LeftShift)? "X" : "x"; stringGrid.GetGridObject(worldPos).AddLetter(temp);}
        if (Input.GetKeyDown(KeyCode.Y)){string temp; temp = Input.GetKey(KeyCode.LeftShift)? "Y" : "y"; stringGrid.GetGridObject(worldPos).AddLetter(temp);}
        if (Input.GetKeyDown(KeyCode.Z)){string temp; temp = Input.GetKey(KeyCode.LeftShift)? "Z" : "z"; stringGrid.GetGridObject(worldPos).AddLetter(temp);}

        //Inputs do numeros
        if (Input.GetKeyDown(KeyCode.Alpha0)){ stringGrid.GetGridObject(worldPos).AddNumber("0");}
        if (Input.GetKeyDown(KeyCode.Alpha1)){ stringGrid.GetGridObject(worldPos).AddNumber("1");}
        if (Input.GetKeyDown(KeyCode.Alpha2)){ stringGrid.GetGridObject(worldPos).AddNumber("2");}
        if (Input.GetKeyDown(KeyCode.Alpha3)){ stringGrid.GetGridObject(worldPos).AddNumber("3");}
        if (Input.GetKeyDown(KeyCode.Alpha4)){ stringGrid.GetGridObject(worldPos).AddNumber("4");}
        if (Input.GetKeyDown(KeyCode.Alpha5)){ stringGrid.GetGridObject(worldPos).AddNumber("5");}
        if (Input.GetKeyDown(KeyCode.Alpha6)){ stringGrid.GetGridObject(worldPos).AddNumber("6");}
        if (Input.GetKeyDown(KeyCode.Alpha7)){ stringGrid.GetGridObject(worldPos).AddNumber("7");}
        if (Input.GetKeyDown(KeyCode.Alpha8)){ stringGrid.GetGridObject(worldPos).AddNumber("8");}
        if (Input.GetKeyDown(KeyCode.Alpha9)){ stringGrid.GetGridObject(worldPos).AddNumber("9");}

    }

}

public class HeatMapGridObject{

    private const int MIN = 0;
    private const int MAX = 100;

    private Grid<HeatMapGridObject> grid;
    private int x;
    private int y;
    private int value;

    public HeatMapGridObject(Grid<HeatMapGridObject> grid, int x, int y)
    {
        this.grid = grid;
        this.x = x;
        this.y = y;
    }

    public void AddValue(int valueToAdd)
    {
        value += valueToAdd;
        value = Mathf.Clamp(value, MIN, MAX);
        grid.TriggerGridObjectChanged(x, y);
    }

    public float GetValueNormalized()
    {
        return (float)value / MAX;
    }

    public override string ToString()
    {
        return value.ToString();
    }
}

public class StringGridMapObject
{
    private Grid<StringGridMapObject> grid;
    private int x;
    private int y;

    private string letters;
    private string numbers;

    public StringGridMapObject(Grid<StringGridMapObject> grid, int x, int y)
    {
        this.grid = grid;
        this.x = x;
        this.y = y;
        letters = "";
        numbers = "";
    }

    public void AddLetter(string letter)
    {
        letters += letter;
        grid.TriggerGridObjectChanged(x, y);
    }

    public void AddNumber(string number)
    {
        numbers += number;
        grid.TriggerGridObjectChanged(x, y);
    }

    public override string ToString()
    {
        return letters + "\n" + numbers;
    }
}
