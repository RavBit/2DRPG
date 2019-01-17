using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace EnemyBehaviour
{
    [CreateAssetMenu(menuName = "2DRPG/AI/Actions/Cook")]
    public class Cook : Action
    {
        private Enemy controller;
        [SerializeField]
        public List<Minigame> Minigames;

        //[HideInInspector]
        public int minigamecounter = 0;

        public override void Behaviour(Enemy controller)
        {
            this.controller = controller;
            //TODO: ADD ACTION BEHAVIOUR
            chooseMiniGame();
        }

        private void chooseMiniGame()
        {
            controller.UpdateSpriteFX(EnemyController.VisualUpdate.TransparentFX, 0);
            Minigames[minigamecounter].Container(this);
            Minigames[minigamecounter].Run();
        }

        public void CalculateDamage(int damage)
        {
            controller.UpdateSpriteFX(EnemyController.VisualUpdate.TransparentFX, 1);
            controller.Stats.UpdateStats(Cat.HP, -damage);
            StateManager._ChangeState(AttackState.Instance);
        }
    }
}