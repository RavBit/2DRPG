using System.Collections.Generic;
using UnityEngine;
using System;
using DG.Tweening;
public class UIBehaviour : MonoBehaviour {
    private Enemy EnemyContainer;

    internal bool idleToggle = false;
    #region ACTIONS AND FUNCTIONS
    private Action<EventParam> init;


    #endregion
    #region UI OBJECTS
    public GameObject BattleUI;
    #endregion
    private void Start()
    {
        EventManager.StartListening("ToggleBattleUI", ToggleBattleUI);
    }

    private UIBehaviour GetUIBehaviour()
    {
        return this;
    }

    private void test()
    {

    }


    public void ToggleBattleUI()
    {
        idleToggle = !idleToggle;
        int x = (idleToggle == true) ? -390 : -695;
        BattleUI.transform.DOLocalMoveY(x, 2);
    }
    
    public void IdleAction(int _action)
    {
        idleActions id = (idleActions)_action;
        switch(id)
        {
            case (idleActions.Cook):
                {
                    EventManager.TriggerEvent("Cook");
                    StateManager._ChangeState(CookState.Instance);
                    break;
                }
            case (idleActions.Interact):
                {
                    EventManager.TriggerEvent("Interact");
                    break;
                }
            case (idleActions.Item):
                {
                    EventManager.TriggerEvent("Item");
                    break;
                }
        }
    }

    enum idleActions
    {
        Cook,           //0
        Item,           //1
        Interact        //2
    }
}
