using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerIdleState : IState<Character>
{
    public void OnStart(Character player)
    {
        player.isMoving = false;
        player.ChangeAnim(Cache.ANIM_IDLE);
    }

    public void OnExecute(Character player)
    {
        Player clonePlayer = ((Player)player);

        if (player.m_Enemies.Count > 0)
        {
            player.currentState.ChangeState(new PlayerAttackState());

        }
        if (Vector3.Distance(clonePlayer.lookDirection, Vector3.zero) > 0.1f)
        {
            player.currentState.ChangeState(new PlayerRunState());
        }
    }

    public void OnExit(Character player)
    {
        
        player.isMoving = true;
    }
}
