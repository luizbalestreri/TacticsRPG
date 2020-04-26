using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Character character;
    void Start()
    {
        character = gameObject.GetComponent<Character>();
        character.CharacterType = CharacterEnum.Player;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
