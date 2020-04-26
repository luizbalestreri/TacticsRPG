using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour{

    public static Action movementFinishedEvent;
    public IEnumerator Movement(Tile destinationTile, float time){
        float duration = 0;
        Vector3 destination = new Vector3(destinationTile.x, destinationTile.y, 0);
        while(duration < time){
            gameObject.transform.position = Vector2.Lerp(gameObject.transform.position, destination, duration/time);
            duration += Time.deltaTime;
            yield return null;
        }
        gameObject.transform.position = destination;
        movementFinishedEvent();
        yield return null;
    }
    public IEnumerator MovementWay(List<Tile> way){
        foreach(var tile in way){
            yield return Movement(tile, 0.1f);
            tile.GetComponent<SpriteRenderer>().color = Color.white;
        }
    }
}
