using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerAttackState : IState<Character>
{
    public float CountDownResetAttackTime = 2f;
    public void OnStart(Character player)
    {
        player.isMoving = false;
        player.m_Enemies[0].TargetRing.ActiveTargetRing();
        player.StartCoroutine(player.Attack());

        Player clonePlayer = ((Player)player);

        CountDownResetAttackTime = clonePlayer.AttackSpeed;
    }

    public void OnExecute(Character player)
    {
        Player clonePlayer = ((Player)player);
        CountDownResetAttackTime -= Time.deltaTime;
        if (CountDownResetAttackTime <= 0)
        {
            player.currentState.ChangeState(new PlayerIdleState());
        }

        if (player.CheckAnimationFinish())
        {
            player.ChangeAnim(Cache.ANIM_IDLE);
        }
        if (Vector3.Distance(clonePlayer.lookDirection, Vector3.zero) > 0.1f)
        {
            player.currentState.ChangeState(new PlayerRunState());
        }
    }

    public void OnExit(Character player)
    {
        player.isAttacking = false;
    }
}
