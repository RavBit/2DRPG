using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace EnemyBehaviour
{
    [CreateAssetMenu(menuName = "2DRPG/AI/State")]
    public class State : ScriptableObject
    {
        protected Enemy controller;
        public string Name;
        public Action[] Actions;

        public void StoreController(Enemy controller)
        {
            this.controller = controller;
            Debug.Log("Set Controller");
            DoActions(controller);
        }


        private void DoActions(Enemy controller)
        {
            for (int i = 0; i < Actions.Length; i++)
            {
                Actions[i].Behaviour(controller);
            }
        }
    }
}