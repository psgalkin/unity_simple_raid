using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationEvents : MonoBehaviour
{
    Character character;
    string characterName = "...";
    
    void Start()
    {
        character = GetComponentInParent<Character>();
        characterName = character.characterName;
        Debug.Log($"{characterName}");
    }


    void BatEnd()
    {
        Debug.Log($"{characterName}: end bat attack");
        character.SetState(Character.State.RunningFromEnemy);
    }

    void PistolEnd()
    {
        Debug.Log($"{characterName}: end pistol attack");
        character.SetState(Character.State.Idle);
    }
   
    void FistEnd()
    {
        Debug.Log($"{characterName}: end fist attack");
        character.SetState(Character.State.RunningFromEnemy);
    }


    void PistolAct()
    {
        Debug.Log($"{characterName}: pistol action");
        character.SetState(Character.State.ActPistol);
        //Character targetCh = character.target.GetComponent<Character>();
        //targetCh.SetState(Character.State.Hited);
    }

    void BatAct()
    {
        Debug.Log($"{characterName}: bat action");
        character.SetState(Character.State.ActBat);
        //Character targetCh = character.target.GetComponent<Character>();
        //targetCh.SetState(Character.State.Hited);
    }

    void FistAct()
    {
        Debug.Log($"{characterName}: fist action");
        character.SetState(Character.State.ActFist);
        //Character targetCh = character.target.GetComponent<Character>();
        //targetCh.SetState(Character.State.Hited);
    }


    void DeadEnd()
    {
        Debug.Log($"{characterName}: end dead animation");
        character.SetState(Character.State.Dead);
    }

}
