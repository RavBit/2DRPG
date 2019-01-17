using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;
using System;
public class AttackState : State<StateManager>
{
    private static AttackState _instance;

    private AttackState()
    {
        if (_instance != null)
        {
            return;
        }

        _instance = this;
    }

    public static AttackState Instance {
        get {
            if (_instance == null)
            {
                new AttackState();
            }
            return _instance;
        }

    }
    public override void EnterState(StateManager _owner)
    {
        Enemy.UpdateState("Attack");
        Debug.Log("Entering Attack State");
    }

    public override void ExitState(StateManager _owner)
    {
        Debug.Log("Exiting Attack State");
    }

    public override void UpdateState(StateManager _owner)
    {

    }
}
