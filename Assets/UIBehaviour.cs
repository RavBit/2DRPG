using System.Collections.Generic;
using UnityEngine;
using System;
using DG.Tweening;
public class UIBehaviour : MonoBehaviour {
    private Enemy EnemyContainer;

    #region ACTIONS AND FUNCTIONS
    private Action<EventParam> init;

    #endregion
    #region UI OBJECTS
    public GameObject BattleUI;
    #endregion
    private void Start()
    {
        init = new Action<EventParam>(Init);
        EventManager.StartListening("Init", Init);
    }

    void Init(EventParam EV)
    {
        Debug.Log("Initing UI");
        ToggleBattleUI(true);

    }


    private void ToggleBattleUI(bool toggle)
    {
        BattleUI.transform.DOLocalMoveY(-390, 2);
    }
}
