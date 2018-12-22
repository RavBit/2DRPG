using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BattleField : MonoBehaviour {
    [Header("Important Graphic Data:")]
    public UIBehaviour UIBehaviour;
    public EnemyContainer EnemyContainer;
    [Header("Enemy Data:")]
    [SerializeField]
    private Enemy enemy;

    #region ACTIONS AND FUNCTIONS
    private Action<EventParam> init;

    #endregion

    private void Start()
    {
        init = new Action<EventParam>(Init);
        EventManager.StartListening("Init", Init);
    }

    void Init(EventParam EV)
    {
        EnemyContainer.Init(enemy);
        enemy.Init();
        Debug.Log("Transfer enemy: " + enemy);

    }

    //TODO: ENEMY WILL BE SET FROM HERE FROM MAP
    public void SetEnemy(Enemy _enemy)
    {
        enemy = _enemy;
    }

    //public Enemy ReturnEnemy
    //{
    //    get {
    //        if (enemy == null)
    //        {
    //            Debug.LogError("Error in Battlefield: No Enemy Data found");
    //        }
    //        return enemy;
    //    }
    //}
}
