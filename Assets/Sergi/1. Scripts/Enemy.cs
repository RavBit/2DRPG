using UnityEngine;
//using EnemyData = EnemyStates;
using StateMachine;
using System;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "Enemy", menuName = "2DRPG/Create Enemy", order = 1)]
[System.Serializable]
public class Enemy : BaseCharacter
{
    [SerializeField]
    private Sprite EnemySprite;
    public Sprite[] BodyParts;

    public int seconds;
    public List<Dialog> Dialogs = new List<Dialog>();

    public StateMachine<Enemy> stateMachine { get; set; }

    public Enemy()
    {
    }
    public Sprite GetSprite()
    {
        return EnemySprite;
    }
    public void Init()
    {
        stateMachine = new StateMachine<Enemy>(this);
        stateMachine.ChangeState(TestState.Instance);
    }
}