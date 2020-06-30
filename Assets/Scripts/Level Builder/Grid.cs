using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class Grid {

    public int width;
    public int height;
    public int[,] gridArray;

    public Grid(int width, int height)
    {
        this.width = width;
        this.height = height;

        gridArray = new int[width, height];
        //passa por todos os elementos de colina
        for(int gridX = 0; gridX < gridArray.GetLength(0); gridX++)
        {
            //passa por todos os elementos de linha dentro da coluna
            for(int gridY = 0; gridY < gridArray.GetLength(1); gridY++)
            {
                UtilsClass.CreateWorldText();
            }
        }
    }

}
