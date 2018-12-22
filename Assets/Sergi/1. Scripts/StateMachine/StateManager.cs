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
    public float gameTimer;
    public int seconds = 0;

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
        Invoke("Init", 0.5f);
    }

    private void Init()
    {
        Debug.Log("Starting State Machine");
        GetSeconds += getSeconds;
        PenaltySeconds += penaltySeconds;
        stateMachine = new StateMachine<StateManager>(this);
        stateMachine.ChangeState(InitState.Instance);
        seconds = stateMachine.currentState.seconds;
        gameTimer = Time.time;
        active = true;
        //test = new Action<Source<Testing>>(TestFunction);
        //EventManager.StartListening("test", TestFunction);
    }
    //Change state to new state
    public void ChangeState(State<StateManager> _state)
    {
        changeState = _state;
    }
    //Update and count the timer
    private void Update()
    {
        if (!active)
        {
            return;
        }
        //if (Time.time > gameTimer + 1 && stateMachine.currentState != InitState.Instance)
        //{
        //    gameTimer = Time.time;
        //    stateMachine.currentState.seconds--;
        //    seconds = stateMachine.currentState.seconds;
        //}
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
