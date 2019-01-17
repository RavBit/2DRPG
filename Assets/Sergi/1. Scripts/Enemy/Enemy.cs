using UnityEngine;
using EnemyBehaviour;
using StateMachine;
using System;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "Enemy", menuName = "2DRPG/Create Enemy", order = 1)]
[System.Serializable]
public class Enemy : ScriptableObject
{
    #region ENEMYBEHAVIOUR
    [SerializeField]
    private EnemyBehaviour.State _currentState;
    public List<EnemyBehaviour.State> States;
    #endregion
    #region ACTIONS
    public static Action<Cat, int> UpdateStats;

    #endregion
    protected EnemyController Controller;
    [Space(5)]
    [Header("Stats Enemy:")]
    public Stats Stats;
    [Space(5)]
    [Header("Visuals:")]
    [Tooltip("Idle sprite of the enemy")]
    [SerializeField]
    private Sprite _sprite;
    [Tooltip("Bodyparts that will get detached from the enemy")]
    public Sprite[] BodyParts;
    public static System.Action<string> UpdateState;


    public void Init(EnemyController _enemycontroller)
    {
        Controller = _enemycontroller;
        Controller.UpdateEnemy(EnemyController.VisualUpdate.Sprite);
        UpdateState = ChangeState;
        UpdateStats = Stats.UpdateStats;
    }

    public void ChangeState(string _name)
    {
        foreach(State state in States)
        {
            if(state.Name == _name)
            {
                _currentState = state;
                _currentState.StoreController(this);
                
                return;
            }
        }
        Debug.LogError("[ERROR] No state with the name '" + _name + "' exists!");
    }

    public Sprite UpdateSprite
    {
        set
        {
            _sprite = value;
            Controller.UpdateEnemy(EnemyController.VisualUpdate.Sprite);
        }
        get
        {
            return _sprite;
        }
        
    }

    public void UpdateSpriteFX(EnemyController.VisualUpdate effect, float value)
    {
        Controller.UpdateEnemy(effect, value);
    }
}

[System.Serializable]
public class Stats
{
    [SerializeField]
    [Header("Hitpoints of the enemy:")]
    [Range(0, 100)]
    private int hp;
    [SerializeField]
    [Header("Attack points of the enemy:")]
    [Range(0, 100)]
    private int attack;
    [SerializeField]
    [Header("Defense points of the enemy:")]
    [Range(0, 100)]
    private int defense;

    public void UpdateStats(Cat stat, int value)
    {
        switch (stat)
        {
            case (Cat.HP):
                {
                    hp += value;
                    break;
                }
        }

    }
}

public enum Cat
{
    HP,
    ATTACK,
    DEFENSE
}