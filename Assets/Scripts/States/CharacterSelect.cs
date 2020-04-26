using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CharacterSelect
{
    public static Character selectedPlayer;

    public static void PlayerSelected(Tile PlayerTile, Character player){
        selectedPlayer = player;
        AStarSearch.FindSelectableTiles(player);
        StateMachineController.currentState = States.destinationSelect;
    }
}
