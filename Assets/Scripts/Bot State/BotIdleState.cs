using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class BotIdleState : IState<Character>
{
    public void OnStart(Character bot)
    {
        bot.Stop();
        bot.isMoving = false;
        bot.ChangeAnim(Cache.ANIM_IDLE);
    }

    public void OnExecute(Character bot)
    {
        
        ((Bot)bot).SeekRandomPoint();
        if(bot.m_Enemies.Count > 0)
        {
            bot.currentState.ChangeState(new BotAttackState());
        }
        if(bot.m_Enemies.Count == 0)
        {
            bot.currentState.ChangeState(new BotRunState());
        }
        
    }

    public void OnExit(Character bot)
    {
        bot.GetComponent<NavMeshAgent>().isStopped = false;
        bot.isMoving = true;
    }
}
