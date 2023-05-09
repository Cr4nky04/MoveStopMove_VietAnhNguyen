using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerRunState : IState<Character>
{
    public void OnStart(Character player)
    {
        player.isMoving = true;
        player.ChangeAnim(Cache.AnimName("IsRun"));
    }

    public void OnExecute(Character player)
    {
        Player clonePlayer = ((Player)player);
        clonePlayer.Moving();
        if (Vector3.Distance(clonePlayer.lookDirection, Vector3.zero) < 0.1f)
        {
            clonePlayer.currentState.ChangeState(new PlayerIdleState());
        }
    }

    public void OnExit(Character bot)
    {

    }
}
