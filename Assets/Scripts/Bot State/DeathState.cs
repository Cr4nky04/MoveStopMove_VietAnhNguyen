using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathState : IState<Character>
{
    public void OnStart(Character character)
    {
        character.StartCoroutine(IDeath(character));
    }
    public void OnExecute(Character character)
    {

    }
    public void OnExit(Character character)
    {

    }

    public IEnumerator IDeath(Character character)
    {
        character.ChangeAnim(Cache.ANIM_DEAD);
        yield return Cache.GetWFS(1f);
        character.OnDespawn();
    }
}
