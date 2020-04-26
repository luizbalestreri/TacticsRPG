using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AStarSearch
{
    public static Action ResetEvent;

    public static void FindSelectableTiles(Character character) {
        ResetEvent();
        Queue<Tile> process = new Queue<Tile>();
        Tile characterTile = Map.position[character.x, character.y];

        process.Enqueue(characterTile);
        characterTile.visitedForAStarSearch = true;
        characterTile.SetColor(Color.blue);
        while (process.Count > 0) {
            Tile t = process.Dequeue();
            t.selectableForWalkableTilesSearch = true; 

            if (t.UpdateHCost(characterTile) < character.movementSpeed) {
                
                foreach (Tile tile in GetNeighbours(t)) {
                    if (!tile.visitedForAStarSearch && tile.isWalkable) {
                        //tile.parent = t;
                        tile.visitedForAStarSearch = true;
                        tile.SetColor(Color.blue);
                        process.Enqueue(tile);
                    } else if(tile.content != null){
                        if(tile.content.CharacterType == CharacterEnum.Enemy){
                            //tile.parent = t;
                            tile.visitedForAStarSearch = true;
                            tile.selectableForWalkableTilesSearch = true;
                            tile.SetColor(Color.cyan);
                        }
                    }
                }
            }
        }
    }

    public static List<Tile> Search(Tile originTile, Tile destinyTile){
        foreach(Tile t in Map.position){
                t.parent = null;
                t.SetColor(Color.white);
        }
        List<Tile> path = new List<Tile>();
        Tile currentTile;
        List<Tile> openList = new List<Tile>{originTile};
        HashSet<Tile> closedSet = new HashSet<Tile>();
        while(openList.Count > 0){
                    currentTile = openList[0];
                    foreach(Tile t in openList){
                        t.UpdateFCost(originTile, destinyTile);
                        if (t.fCost < currentTile.fCost || t.fCost == currentTile.fCost && t.hCost < currentTile.hCost){
                            currentTile = t;
                        }
                    }
                
                    openList.Remove(currentTile);
                    closedSet.Add(currentTile);
                    
                    if(currentTile == destinyTile){
                        return (CalculatePath(destinyTile));
                    }

                    foreach(Tile t in GetNeighbours(currentTile)){
                        if(!closedSet.Contains(t) && t.isWalkable){
                            int tFCost = t.UpdateFCost(originTile, destinyTile);
                            if(currentTile.fCost < tFCost || !openList.Contains(t)){
                                t.parent = currentTile;
                                openList.Add(t);
                            }
                        }
                    }      
                }
        Debug.Log("empty");
        return path;
    }

    public static void AttackRange(Character character){
                ResetEvent();
        Queue<Tile> process = new Queue<Tile>();
        Tile characterTile = Map.position[character.x, character.y];

        process.Enqueue(characterTile);
        characterTile.visitedForAStarSearch = true;
        characterTile.SetColor(Color.blue);
        while (process.Count > 0) {
            Tile t = process.Dequeue();
            t.selectableForWalkableTilesSearch = true; 

            if (t.UpdateHCost(characterTile) < (character.movementSpeed + 1)) {
                
                foreach (Tile tile in GetNeighbours(t)) {
                    
                    if (!tile.visitedForAStarSearch && tile.isWalkable) {
                        tile.parent = t;
                        tile.visitedForAStarSearch = true;
                        tile.SetColor(Color.red);
                        process.Enqueue(tile);
                    } 
                }
            }
        }
    }

    public static List<Tile> CalculatePath(Tile objective){
            List<Tile> path = new List<Tile>();
            while(objective.parent != null){
                path.Add(objective);
                objective.SetColor(Color.red);
                objective = objective.parent;
            }
            path.Reverse();
            return path;
    }

    public static List<Tile> GetNeighbours(Tile tile){
        int x = tile.x;
        int y = tile.y;
        List<Tile> tiles = new List<Tile>();
        if(x < Map.width - 1){
            tiles.Add(Map.position[x + 1, y]);
        }
        if(y < Map.height - 1){
            tiles.Add(Map.position[x, y + 1]);
        }
        if(x > 0){
            tiles.Add(Map.position[x - 1, y]);
        }
        if(y > 0){
            tiles.Add(Map.position[x, y - 1]);
        }
        return tiles;
    }

}
