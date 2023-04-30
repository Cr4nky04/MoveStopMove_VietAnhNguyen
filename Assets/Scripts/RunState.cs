using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class RunState : IState<Character>
{
    public void OnStart(Character bot)
    {
        bot.GetComponent<NavMeshAgent>().isStopped = false;
        bot.isMoving = true;
        
    }

    public void OnExecute(Character bot)
    {
        ((Bot)bot).MovingRandom();
        bot.ChangeAnim("Run");
        if(Vector3.Distance(bot.Transform.position, ((Bot)bot).destinationPosition)<0.1f)
        {
            bot.currentState.ChangeState(new IdleState());
        }
    }

    public void OnExit(Character bot)
    {

    }
}
