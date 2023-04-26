using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    BaseState currentState;
    public IdleState IdleState = new IdleState();
    public RunState RunState = new RunState();
    public AttackState AttackState = new AttackState();

    private void Start()
    {
        currentState = IdleState;
        currentState.EnterState(this);
    }

    private void Update()
    {
        currentState.UpdateState(this);
    }
    public void SwitchState(BaseState state)
    {
        currentState = state;
        state.EnterState(this);
    }
}
