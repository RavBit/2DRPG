using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;
using System;
public class PrepareState : State<State_Manager>
{
    private static PrepareState _instance;
    private Action<EventParam> test;

    private PrepareState()
    {
        if (_instance != null)
        {
            return;
        }

        _instance = this;
    }

    public static PrepareState Instance {
        get {
            if (_instance == null)
            {
                new PrepareState();
            }
            return _instance;
        }

    }
    public override void EnterState(State_Manager _owner)
    {
        test = new Action<EventParam>(Test);
        Debug.Log("Entering Prepare State");
        EventManager.StartListening("Test", test);
        EventManager.TriggerEvent("Test", new EventParam());
    }

    public override void ExitState(State_Manager _owner)
    {
        Debug.Log("Exiting Prepare State");
    }

    public override void UpdateState(State_Manager _owner)
    {

           // _owner.stateMachine.ChangeState(PlayState.Instance);
    }

    public void Test(EventParam eventParam)
    {
        Debug.Log("TEST EVENT");
        if(eventParam.param2 == 0)
        {
            Debug.Log("Test");
        }
    }
}
