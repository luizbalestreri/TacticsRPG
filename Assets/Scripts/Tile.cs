using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Tile : MonoBehaviour
{

    //Referencias a outros scripts:
    public Character content;
    //Posição no mapa:
    public int x{get{return (int) transform.position.x;}}
    public int y{get{return (int) transform.position.y;}}
    //Custos para a*:
    public int fCost, gCost, hCost;
    //Referencia ao tile anterior, de onde ele veio
    public Tile parent = null;
    public bool visitedForAStarSearch = false, selectableForWalkableTilesSearch = false, isWalkable = false, mouseButtonPressed = false;
    public static Action<Tile, Character> onMouseEvent;
    public static Action<Tile, Character> onMouseOverEvent;
    public float mouseOverTime = 0;
    void Start(){
        this.name = "Tile x: " + x + " y: " + y;
        gCost = hCost = fCost = int.MaxValue;
        AStarSearch.ResetEvent += Reset;
    }

    public void Reset(){
        this.SetColor(Color.white);
        parent = null;
        visitedForAStarSearch = selectableForWalkableTilesSearch =  false;
        fCost = hCost = gCost = int.MaxValue;
    }

    void OnMouseUp() { 
        mouseOverTime = 0;
        mouseButtonPressed = false;
        onMouseEvent(this, content);
    }

    void OnMouseDown() {
        if(content != null){
            mouseButtonPressed = true;
        }
    }

    void OnMouseOver() {
        if (mouseButtonPressed){
            mouseOverTime += Time.deltaTime;
        }
        if (mouseOverTime >= 1.5f){
            Debug.Log(mouseOverTime);
                onMouseOverEvent(this, content);
        }    
    }

    public int UpdateFCost(Tile objective, Tile startPosition){
        UpdateHCost(startPosition);
        UpdateGCost(objective);
        fCost = hCost + gCost;
        return fCost;
    }
    public int UpdateGCost(Tile objective){
        gCost = (int)(
            Mathf.Abs(gameObject.transform.position.x - objective.transform.position.x) + 
            Mathf.Abs(gameObject.transform.position.y - objective.transform.position.y));
        return gCost;
    }

    public int UpdateHCost(Tile startPosition){
        hCost = (int)(
            Mathf.Abs(gameObject.transform.position.x - startPosition.transform.position.x) + 
            Mathf.Abs(gameObject.transform.position.y - startPosition.transform.position.y));  
        return hCost;
    }

    public void SetColor(Color color){
        this.GetComponent<SpriteRenderer>().color = color;
    }
    

}
