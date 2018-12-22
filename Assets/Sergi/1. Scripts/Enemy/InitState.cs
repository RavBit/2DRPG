using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;
using System;

    public class TestState : State<Enemy>
    {
        private static TestState _instance;

        public EnemyContainer EnemyContainer;

        private TestState()
        {
        }

        public static TestState Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new TestState();
                }
                return _instance;
            }

        }
        public override void EnterState(Enemy _owner)
        {
            Debug.Log("Entering ENEMY INIT State");
        EventParam ev = new EventParam();
        EventManager.TriggerEvent("EnemyInit", ev);
    }

        public override void ExitState(Enemy _owner)
        {
            Debug.Log("Exiting ENEMY INIT State");
        }

        public override void UpdateState(Enemy _owner)
        {
            //_owner.stateMachine.ChangeState(PlayState.Instance);
        }
    }
