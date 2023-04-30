using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AttackState : IState<Character>
{
    public float CountDownResetAttackTime = 3f;
    public void OnStart(Character bot)
    {
        bot.StartCoroutine(bot.Attack());

    }

    public void OnExecute(Character bot)
    {
        
        CountDownResetAttackTime -= Time.deltaTime;
        if (CountDownResetAttackTime <= 0)
        {
            bot.isAttacking = false;
            bot.currentState.ChangeState(new IdleState());
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
