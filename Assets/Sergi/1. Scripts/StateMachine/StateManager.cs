using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using StateMachine;
using System;
public class StateManager : MonoBehaviour
{
    public bool switchState = true;
    private bool active;
    public int seconds = 0;
    public static Action<State<StateManager>> _ChangeState;
    private State<StateManager> changeState;
    #region EVENTS & DELEGATES
    public delegate int GetNumber();
    public static event GetNumber GetSeconds;
    public delegate void AdjustNumber(int value);
    public static event AdjustNumber PenaltySeconds;

    public static int Get_Seconds()
    {
        return GetSeconds();
    }

    public static void Penalty_Seconds(int value)
    {
        PenaltySeconds(value);
    }

    #endregion
    public StateMachine<StateManager> stateMachine { get; set; }
    private void Start()
    {
        Init();
    }

    private void Init()
    {
        Debug.Log("Starting State Machine");
        _ChangeState = ChangeState;
        GetSeconds += getSeconds;
        PenaltySeconds += penaltySeconds;
        stateMachine = new StateMachine<StateManager>(this);
        stateMachine.ChangeState(InitState.Instance);
        seconds = stateMachine.currentState.seconds;
        active = true;
    }
    //Change state to new state
    public void ChangeState(State<StateManager> _state)
    {
        stateMachine.ChangeState(_state);
    }
    //Update and count the timer
    private void Update()
    {
        if (!active)
        {
            return;
        }
        stateMachine.Update();
    }


    int getSeconds()
    {
         return stateMachine.currentState.seconds;
    }

    void penaltySeconds(int value)
    {
        stateMachine.currentState.seconds -= value;
    }
}
