using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class BaseState
{

    public abstract void EnterState(GameStateManager bot);

    public abstract void UpdateState(GameStateManager bot);

    public abstract void OnCollisonEnter(GameStateManager bot);


}