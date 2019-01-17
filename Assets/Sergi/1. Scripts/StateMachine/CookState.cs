using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;
using System;
public class CookState : State<StateManager>
{
    private static CookState _instance;

    private CookState()
    {
        if (_instance != null)
        {
            return;
        }

        _instance = this;
    }

    public static CookState Instance {
        get {
            if (_instance == null)
            {
                new CookState();
            }
            return _instance;
        }

    }
    public override void EnterState(StateManager _owner)
    {
        Enemy.UpdateState("Cook");
        Debug.Log("Entering Cook State");
    }

    public override void ExitState(StateManager _owner)
    {
        Debug.Log("Exiting Cook State");
    }

    public override void UpdateState(StateManager _owner)
    {

    }
}
