using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class IdleState : IState<Character>
{
    public void OnStart(Character bot)
    {
        bot.GetComponent<NavMeshAgent>().isStopped=true;
        bot.isMoving = false;
    }

    public void OnExecute(Character bot)
    {
        bot.ChangeAnim("IsIdle");
        ((Bot)bot).SeekRandomPoint();
        if(bot.m_Enemies.Count > 0)
        {
            bot.currentState.ChangeState(new AttackState());
        }
    }

    public void OnExit(Character bot)
    {
        bot.GetComponent<NavMeshAgent>().isStopped = false;
        bot.isMoving = true;
    }
}
