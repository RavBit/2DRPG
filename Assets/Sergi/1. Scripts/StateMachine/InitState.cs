﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;
using System;
public class InitState : State<StateManager>
{
    private static InitState _instance;
    private Action<EventParam> test;

    private InitState()
    {
        if (_instance != null)
        {
            return;
        }

        _instance = this;
    }

    public static InitState Instance {
        get {
            if (_instance == null)
            {
                new InitState();
            }
            return _instance;
        }

    }
    public override void EnterState(StateManager _owner)
    {
        Enemy.UpdateState("Init");
        seconds = 1;
        Debug.Log("Entering Init State");
    }

    public override void ExitState(StateManager _owner)
    {
        Debug.Log("Exiting Init State");
    }

    public override void UpdateState(StateManager _owner)
    {
        seconds--;
        if (seconds == 0)
        {
            _owner.stateMachine.ChangeState(IdleState.Instance);
        }
    }
}
