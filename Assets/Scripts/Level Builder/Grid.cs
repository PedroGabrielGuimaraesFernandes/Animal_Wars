using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using CodeMonkey.Utils;
using PedroG.UsefulFuncs;

public class Grid {

    public const int HEAT_MAP_MAX_VALUE = 100;
    public const int HEAT_MAP_MIN_VALUE = 0;

    public event EventHandler<OnGridCellValueChangedEventArgs> OnGridCellValueChanged;
    public class OnGridCellValueChangedEventArgs : EventArgs
    {
        public int gridX;
        public int gridY;
    }

    public int width;
    public int height;
    private float cellSize;
    public Vector3 originPosition;
    public int[,] gridArray;    

    public Grid(int width, int height, float cellSize, Vector3 originPosition)
    {
        //Definimos a largura, a altura e o tamnho da celula
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;
        this.originPosition = originPosition;

        // Passamos a largura e a altura para o grid 
        gridArray = new int[width, height];

        bool showDebug = true;
        if (showDebug)
        {
            TextMesh[,] debugTextArray = new TextMesh[width, height];
            //Parte de montagem do grid
            //passa por todos os elementos de colina
            for (int gridX = 0; gridX < gridArray.GetLength(0); gridX++)
            {
                //passa por todos os elementos de linha dentro da coluna
                for (int gridY = 0; gridY < gridArray.GetLength(1); gridY++)
                {
                    //Cria dento da celula correspondente o texto e arruma ele para ficar no seu centro
                    debugTextArray[gridX, gridY] = UsefulFunctions.CreateWorldText(gridArray[gridX, gridY].ToString(), null, GetWorldPosition(gridX, gridY) + new Vector3(cellSize, cellSize) * .5f, 20, Color.white, TextAnchor.MiddleCenter);
                    Debug.DrawLine(GetWorldPosition(gridX, gridY), GetWorldPosition(gridX + 1, gridY), Color.white, 100f);
                    Debug.DrawLine(GetWorldPosition(gridX, gridY), GetWorldPosition(gridX, gridY + 1), Color.white, 100f);
                }
            }
            Debug.DrawLine(GetWorldPosition(0, height), GetWorldPosition(width, height), Color.white, 100f);
            Debug.DrawLine(GetWorldPosition(width, 0), GetWorldPosition(width, height), Color.white, 100f);

            OnGridCellValueChanged += (object sender, OnGridCellValueChangedEventArgs eventArgs) =>
            {
                debugTextArray[eventArgs.gridX, eventArgs.gridY].text = gridArray[eventArgs.gridX, eventArgs.gridY].ToString();
            };
        }
    }

    /*private void Grid_OnGridCellValueChanged(object sender, EventArgs e)
    {
        
    }*/

    public int GetWidth()
    {
        return width;
    }

    public int GetHeight()
    {
        return height;
    }

    public float GetCellSize()
    {
        return cellSize;
    }

    //Transforma o X e o Y do grid em um ponto do mundo
    public Vector3 GetWorldPosition(int x, int y)
    {
        return new Vector3(x, y) * cellSize + originPosition;
    }

    private void GetXY(Vector3 worldPosition, out int x, out int y)
    {
        //Se o cellsize for 10 então tudo de 0 a 10 sera dentro do grid 0, de 10 a 20 sera no grid 1...
        x = Mathf.FloorToInt((worldPosition - originPosition).x / cellSize);
        y = Mathf.FloorToInt((worldPosition - originPosition).y / cellSize);
    }

    //Altera o valor de uma celula especifica para o valor mandado
    public void SetValue(int x, int y, int value)
    {
        //Garante que o número é valido
        if (x >= 0 && y >= 0 && x < width && y < height)
        {
            gridArray[x, y] = Mathf.Clamp(value,HEAT_MAP_MIN_VALUE, HEAT_MAP_MAX_VALUE);
            //if (OnGridCellValueChanged != null) OnGridCellValueChanged(this, new OnGridCellValueChangedEventArgs { gridX = x, gridY = y });
            OnGridCellValueChanged?.Invoke(this, new OnGridCellValueChangedEventArgs { gridX = x, gridY = y });
        }
    }

    public void SetValue(Vector3 worldPosition, int value)
    {
        int x, y;
        GetXY(worldPosition, out x, out y);
        SetValue(x, y, value);
    }

    public int GetValue(int x, int y)
    {
        if(x >= 0 && y >= 0 && x < width && y < height)
        {
            return gridArray[x, y];
        }
        else
        {
            return 0;
        }
    }

    public int GetValue(Vector3 worldPosition)
    {
        int x, y;
        GetXY(worldPosition, out x, out y);
        return GetValue(x, y);
    }
}
