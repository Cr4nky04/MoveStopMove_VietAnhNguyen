using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class BotAttackState : IState<Character>
{
    public float CountDownResetAttackTime = 2f;
    public void OnStart(Character bot)
    {
        bot.GetComponent<NavMeshAgent>().isStopped = true;
        bot.isMoving = false;
        bot.StartCoroutine(bot.Attack());
    }

    public void OnExecute(Character bot)
    {
        
        CountDownResetAttackTime -= Time.deltaTime;
        if (CountDownResetAttackTime <= 0)
        {
            bot.currentState.ChangeState(new BotIdleState());
        }

        if (bot.CheckAnimationFinish())
        {
            bot.ChangeAnim("IsIdle");
        }
    }

    public void OnExit(Character bot)
    {
        bot.isAttacking = false;
    }
}
