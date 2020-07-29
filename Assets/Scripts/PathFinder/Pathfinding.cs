using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinding {


    private const int MOVE_STRAIGHT_COST = 10;
    private const int MOVE_DIAGONAL_COST = 14;

    private Grid<PathNode> grid;
    private List<PathNode> openList;
    private List<PathNode> closedList;
    public Pathfinding (int width, int height, bool showDebug)
    {
        grid = new Grid<PathNode>(width, height, 10f, Vector3.zero, (Grid<PathNode> g, int x, int y) => new PathNode(g, x, y), showDebug);
    }

    public Grid<PathNode> GetGrid()
    {
        return grid;
    }

    public List<PathNode> FindPath(int startX, int startY, int endX, int endY)
    {
        //Pega o nodulo inicial
        PathNode startNode = grid.GetGridObject(startX, startY);
        //Nodulo final
        PathNode endNode = grid.GetGridObject(endX, endY);
        // crias as listas que seram usadas
        openList = new List<PathNode> { startNode };
        closedList = new List<PathNode>();

        for (int x = 0; x < grid.GetWidth(); x++)
        {
            for (int y = 0; y < grid.GetHeight(); y++)
            {
                //referencia ao nodulo
                PathNode pathNode = grid.GetGridObject(x, y);
                //Coloca no valor no infinito para inicializar
                pathNode.gCost = int.MaxValue;
                pathNode.CalculateFCost();
                pathNode.cameFromNode = null;
            }
        }
        // iniciando o pathnode inicial
        startNode.gCost = 0; 
        startNode.hCost = CalculateDistanceCost(startNode, endNode);
        startNode.CalculateFCost();

        while (openList.Count > 0)
        {
            PathNode currentNode = LowestCostPathNode(openList);
            if(currentNode == endNode)
            {
                //Chegou no ultimo node
                return CalculatePath(endNode);
            }

            openList.Remove(currentNode);
            closedList.Add(currentNode);

            foreach(PathNode neighbourNode in GetNeighbourList(currentNode))
            {
                if (closedList.Contains(neighbourNode)) continue;
                if (!neighbourNode.isWalkable)
                {
                    closedList.Add(neighbourNode);
                    continue;
                }

                int tentativeGCost = currentNode.gCost + CalculateDistanceCost(currentNode, neighbourNode);
                // Serve para checar se ñ tem um caminho melhor
                if(tentativeGCost < neighbourNode.gCost)
                {
                    neighbourNode.cameFromNode = currentNode;
                    neighbourNode.gCost = tentativeGCost;
                    neighbourNode.hCost = CalculateDistanceCost(neighbourNode, endNode);
                    neighbourNode.CalculateFCost();

                    if (!openList.Contains(neighbourNode))
                    {
                        openList.Add(neighbourNode);
                    }
                }
            }
        }

        // Out of nodes on the open list
        return null;
    }



    private List<PathNode> GetNeighbourList(PathNode currentNode)
    {
        List<PathNode> neighbourList = new List<PathNode>();

        //Esquerda
        if (currentNode.x -1 >= 0)
        {
            neighbourList.Add(GetNode(currentNode.x - 1, currentNode.y));
        //Esquerda - Cima
            if(currentNode.y + 1 < grid.GetHeight())
                neighbourList.Add(GetNode(currentNode.x - 1, currentNode.y + 1));           
            //Esquerda - Baixo
            if (currentNode.y - 1 >= 0)            
                neighbourList.Add(GetNode(currentNode.x - 1, currentNode.y - 1));            
        }
        //Direta
        if (currentNode.x + 1 < grid.GetWidth())
        {
            neighbourList.Add(GetNode(currentNode.x + 1, currentNode.y));
            //Direta - Cima
            if (currentNode.y + 1 < grid.GetHeight())            
                neighbourList.Add(GetNode(currentNode.x + 1, currentNode.y + 1));            
            //Direta - Baixo
            if (currentNode.y - 1 >= 0)            
                neighbourList.Add(GetNode(currentNode.x + 1, currentNode.y - 1));            
        }
        //Cima
        if (currentNode.y + 1 < grid.GetHeight())
        {
            neighbourList.Add(GetNode(currentNode.x, currentNode.y + 1));
        }
        //Baixo
        if (currentNode.y - 1 >= 0)
        {
            neighbourList.Add(GetNode(currentNode.x, currentNode.y - 1));
        }

        return neighbourList;
    }

    public PathNode GetNode(int x, int y)
    {
        return grid.GetGridObject(x, y);
    }

    private List<PathNode> CalculatePath(PathNode endNode)
    {
        List<PathNode> path = new List<PathNode>();
        path.Add(endNode);
        PathNode currentNode = endNode;
        while(currentNode.cameFromNode != null)
        {
            path.Add(currentNode.cameFromNode);
            currentNode = currentNode.cameFromNode;
        }

        path.Reverse();
        return path;
    }

    //Faz o calculo da distancia de um node a outro
    private int CalculateDistanceCost(PathNode a, PathNode b)
    {
        int xDistance = Mathf.Abs(a.x - b.x);
        int yDistance = Mathf.Abs(a.y - b.y);
        int remaning = Mathf.Abs(xDistance - yDistance);
        return MOVE_DIAGONAL_COST * Mathf.Min(xDistance, yDistance) + MOVE_STRAIGHT_COST * remaning;
    }

    private PathNode LowestCostPathNode(List<PathNode> pathNodesList)
    {
        PathNode lowestFCostNode = pathNodesList[0];

        for (int i = 0; i < pathNodesList.Count; i++)
        {
            if(pathNodesList[i].fCost < lowestFCostNode.fCost)
            {
                lowestFCostNode = pathNodesList[i];
            }
        }

        return lowestFCostNode;
    }
}
