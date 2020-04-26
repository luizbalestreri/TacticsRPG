using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DestinationSelect
{
    public static void WalkToDestination(Character selectedPlayer, Tile destinationTile){
        Tile playerTile = Map.position[(int)selectedPlayer.transform.position.x, (int)selectedPlayer.transform.position.y];
        selectedPlayer.GetComponent<Character>().Move(AStarSearch.Search(playerTile, destinationTile));
        playerTile.content = null;
        destinationTile.content = selectedPlayer;
        StateMachineController.currentState = States.characterWalking;
    }
}
