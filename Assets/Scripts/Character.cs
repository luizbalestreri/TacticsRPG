using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public int x{get{return (int)gameObject.transform.position.x;}}
    public int y{get{return (int)gameObject.transform.position.y;}}
    public int movementSpeed, hp, attackPower;
    public List<Tile> attackOption;
    public bool hasMoved = false;
    public CharacterEnum CharacterType;
    PlayerMovement playerMovement;
    
    void Start(){
        playerMovement = this.gameObject.GetComponent<PlayerMovement>();
    }

    public void Move(List<Tile> way){
        if(playerMovement != null){
        Debug.Log("move nao é null");
        StartCoroutine(playerMovement.MovementWay(way));
        }
    }
}
