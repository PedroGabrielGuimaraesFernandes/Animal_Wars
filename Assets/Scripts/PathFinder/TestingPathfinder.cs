using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PedroG.UsefulFuncs;

public class TestingPathfinder : MonoBehaviour
{
    public bool showDebug = true;
    [Header("Largura dos grids")] public int width = 10;
    [Header("Altura dos grids")] public int height = 10;

    //[SerializeField]private Grid<PathNode> grid;
    private List<PathNode> openList;
    private List<PathNode> closedList;

    private Pathfinding pathfinding;

    [SerializeField] private int startX = 0;
    [SerializeField] private int startY = 0;

    [SerializeField]private PathfinderVisual pathfinderVisual;

    private void Start()
    {
        pathfinding = new Pathfinding(width, height, showDebug);

        pathfinderVisual.SetGrid(pathfinding.GetGrid());
    }

    private void Update()
    {
        Vector3 worldPos;
        worldPos = UsefulFunctions.GetMouseWorldPosition();
        if (Input.GetMouseButtonDown(0))
        {
            pathfinding.GetGrid().GetXY(worldPos, out int x, out int y);
            int targetX = (int)Mathf.Clamp(x, 0, pathfinding.GetGrid().GetWidth()-1);
            int targetY = (int)Mathf.Clamp(y, 0, pathfinding.GetGrid().GetHeight()-1);

            List<PathNode> path = pathfinding.FindPath(startX, startY, targetX, targetY);
            if (path != null)
            {
                for (int i = 0; i < path.Count - 1; i++)
                {
                    //PathNode node = path[i];
                    Debug.DrawLine(new Vector3(path[i].x, path[i].y) * 10 + Vector3.one * 5f, new Vector3(path[i + 1].x, path[i + 1].y) * 10 + Vector3.one * 5f, Color.red, 3,false);
                }
            }

        }
        if (Input.GetMouseButtonDown(1))
        {
            /*pathfinding.GetGrid().GetXY(worldPos, out int startX, out int startY);            
            this.startX = Mathf.Clamp(startX, 0, pathfinding.GetGrid().GetWidth());
            this.startY = Mathf.Clamp(startY, 0, pathfinding.GetGrid().GetHeight());*/
            pathfinding.GetGrid().GetXY(worldPos, out int x, out int y);
            pathfinding.GetNode(x, y).SetIsWalkable(!pathfinding.GetNode(x, y).isWalkable);

        }

    }
}
