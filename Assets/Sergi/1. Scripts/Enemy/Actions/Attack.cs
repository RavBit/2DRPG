using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EnemyBehaviour
{
    [CreateAssetMenu(menuName = "2DRPG/AI/Actions/Attack")]
    public class Attack : Action
    {
        private Enemy controller;
        public BattleField BattleField;

        private GameObject battleFieldContainer;

        public List<ExMinigame> ExMinigames;

        private int exminigamecounter;

        public override void Behaviour(Enemy controller)
        {
            this.controller = controller;
            //TODO: ADD ACTION BEHAVIOUR
            chooseExMinigame();
        }

        private void chooseExMinigame()
        {
            battleFieldContainer = Instantiate(BattleField.gameObject) as GameObject;
            ExMinigames[exminigamecounter].Container(this);
            ExMinigames[exminigamecounter].Run();
        }

        
        public void Stop()
        {
            //StateManager._ChangeState(IdleState.Instance);
        }

    }

    [CreateAssetMenu(menuName = "2DRPG/AI/Actions/CustomAction")]
    public class CustomAction : Action
    {
        public string test;
        public override void Behaviour(Enemy controller)
        {
            throw new System.NotImplementedException();
        }

        private void DoThing()
        {

        }
    }
}