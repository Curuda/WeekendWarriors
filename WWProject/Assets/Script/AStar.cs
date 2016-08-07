using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class AStar
{
    public static List<Vector2> FindPath(TileScript[,] _tileArray, Vector2 _position, Vector2 _target)
    {
        SortedList<int, AStarNode> closedList = new SortedList<int, AStarNode>();
        SortedList<int, AStarNode> openList = new SortedList<int, AStarNode>();

        openList.Add(GetManhattanDistance(_position, _target), new AStarNode());

        while (openList.Count != 0)
        {
            Debug.Log("hi");
        }

        return new List<Vector2>();
    }

    public static int GetManhattanDistance(Vector2 _start, Vector2 _target)
    {
        int result = Mathf.RoundToInt(Mathf.Abs(_target.x - _start.x + _target.y - _start.y));
        return result;
    }
}

public class AStarNode
{
    public AStarNode parent;
    public Vector2 position;

    public AStarNode()
    {

    }
}

