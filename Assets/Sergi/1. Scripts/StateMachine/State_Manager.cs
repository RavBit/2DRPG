using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using StateMachine;
using System;
public class State_Manager : MonoBehaviour
{
    public bool switchState = true;
    public float gameTimer;
    public int seconds = 0;

    private State<State_Manager> changeState;


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
    public StateMachine<State_Manager> stateMachine { get; set; }
    private void Start()
    {
        Invoke("Init", 0.1f);
    }

    private void Init()
    {
        Debug.Log("Starting State Machine");
        GetSeconds += getSeconds;
        PenaltySeconds += penaltySeconds;
        stateMachine = new StateMachine<State_Manager>(this);
        stateMachine.ChangeState(PrepareState.Instance);
        seconds = stateMachine.currentState.seconds;
        gameTimer = Time.time;
    }
    //Change state to new state
    public void ChangeState(State<State_Manager> _state)
    {
        changeState = _state;
    }
    //Update and count the timer
    private void Update()
    {
        if (Time.time > gameTimer + 1 && stateMachine.currentState != EndState.Instance)
        {
            gameTimer = Time.time;
            stateMachine.currentState.seconds--;
            seconds = stateMachine.currentState.seconds;
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
    //Set roles

}
