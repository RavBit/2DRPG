using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;
using System;
public class IdleState : State<StateManager>
{
    private static IdleState _instance;

    private IdleState()
    {
        if (_instance != null)
        {
            return;
        }

        _instance = this;
    }

    public static IdleState Instance {
        get {
            if (_instance == null)
            {
                new IdleState();
            }
            return _instance;
        }

    }
    public override void EnterState(StateManager _owner)
    {
        EventManager.TriggerEvent("ToggleBattleUI");
        Enemy.UpdateState("Idle");
        Debug.Log("Entering Idle State");
    }

    public override void ExitState(StateManager _owner)
    {
        EventManager.TriggerEvent("ToggleBattleUI");
        Debug.Log("Exiting Idle State");
    }

    public override void UpdateState(StateManager _owner)
    {
        //_owner.stateMachine.ChangeState(PlayState.Instance);
    }
}
