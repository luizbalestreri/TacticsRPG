using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public GameObject playerUnitTemplate, enemyUnitTemplate, tileTemplate;
    public Vector3[] playerList, enemyList, obstacleList;
    public int height, width;
    List<Tile> way;
    void Awake(){
        Map.height = height; Map.width = width;
        Map.position = new Tile[width, height];
    }
    void Start(){ 
        for(int i = 0; i < Map.height; i++){
            for(int j = 0; j < Map.width; j++){
                Map.position[i,j] = Instantiate(tileTemplate, new Vector3(i, j, 0), Quaternion.identity).GetComponent<Tile>();
                Map.position[i,j].isWalkable = true;
            }
        }
        foreach(Vector3 playerPosition in playerList){
            Tile t = Map.position[(int)playerPosition.x, (int)playerPosition.y];
            t.content = Instantiate(playerUnitTemplate, playerPosition, Quaternion.identity).GetComponent<Character>();  
        }
        foreach(Vector3 enemyPosition in enemyList){
            Tile t = Map.position[(int)enemyPosition.x, (int)enemyPosition.y];
            t.content = Instantiate(enemyUnitTemplate, enemyPosition, Quaternion.identity).GetComponent<Character>();  
        }
        foreach(Vector3 obstacle in obstacleList){
            Tile t = Map.position[(int)obstacle.x, (int)obstacle.y];  
            t.SetColor(Color.grey);
        }
    }
}