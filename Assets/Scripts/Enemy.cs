using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Character character;
    void Start()
    {
        character = gameObject.GetComponent<Character>();
        character.CharacterType = CharacterEnum.Enemy;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
