using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Map{
    
    public static int width;
    public static int height;
    public static Tile[,] position;
    public static int CalculateDistance(Vector2Int start, Vector2Int end){
        int distance = Mathf.Abs(start.x - end.x) + Mathf.Abs(start.y - end.y);
        return distance;
    }
}
