using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class NoneState : IState<Character>
{
    public void OnStart(Character character)
    {
        character.ChangeAnim(Cache.AnimName("IsIdle"));
    }

    public void OnExecute(Character character)
    {
        
    }

    public void OnExit(Character character)
    {

    }
}

