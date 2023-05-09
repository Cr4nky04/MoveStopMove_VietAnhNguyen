using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class BotRunState : IState<Character>
{
    public void OnStart(Character bot)
    {
        bot.GetComponent<NavMeshAgent>().isStopped = false;
        bot.isMoving = true;
        bot.ChangeAnim(Cache.AnimName("IsRun"));
    }

    public void OnExecute(Character bot)
    {
        ((Bot)bot).MovingRandom();
        if(Vector3.Distance(bot.Transform.position, ((Bot)bot).destinationPosition)<0.5f)
        {
            bot.currentState.ChangeState(new BotIdleState());
        }
        if(bot.m_Enemies.Count > 0)
        {
            bot.currentState.ChangeState(new BotAttackState());
        }
    }

    public void OnExit(Character bot)
    {

    }
}
