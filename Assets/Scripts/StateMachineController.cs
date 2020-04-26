using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class StateMachineController : MonoBehaviour
{
    public Controller controller;
    [SerializeField]
   public static States currentState = new States();
    void Start(){
        Action SetActionSelectState = () => currentState = States.actionSelect;
        PlayerMovement.movementFinishedEvent += SetActionSelectState;
        Tile.onMouseEvent += TileSelected;
        Tile.onMouseOverEvent += TileMouseOver;
        controller = gameObject.GetComponent<Controller>();
        currentState = States.characterSelect;
    }

    public void TileMouseOver(Tile tile, Character content){
        AStarSearch.AttackRange(content);
    }
    public void TileSelected(Tile tile, Character content){
        if(content != null){
            if(content.CharacterType == CharacterEnum.Player){
                if(currentState == States.destinationSelect || currentState == States.characterSelect){
                    CharacterSelect.PlayerSelected(tile, content);
                }
            } else {
                if(currentState == States.destinationSelect || currentState == States.characterSelect){
                    //TODO enemy info action
                }
            }
        } else if (currentState == States.destinationSelect){
            if (tile.selectableForWalkableTilesSearch){
                DestinationSelect.WalkToDestination(CharacterSelect.selectedPlayer, tile);
            }
        } 
    }

}
