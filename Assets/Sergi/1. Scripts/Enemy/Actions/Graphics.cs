using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EnemyBehaviour
{
    [CreateAssetMenu(menuName = "2DRPG/AI/Actions/Graphics")]
    public class Graphics : Action
    {
        protected Enemy controller;
        [SerializeField]
        private UIBehaviour UIbehaviour;
        [SerializeField]
        private GraphicOptions graphicOptions;
        [SerializeField]
        private Sprite SpriteUsed;
        internal bool battleUIToggle;




        public override void Behaviour(Enemy controller)
        {
            this.controller = controller;
            graphicsBehaviour();
        }

        private bool returnValue()
        {
            return false;
        }

        private void graphicsBehaviour()
        {
            switch (graphicOptions)
            {
                case (GraphicOptions.Change_Image):
                    {
                        controller.UpdateSprite = SpriteUsed;
                        break;
                    }
            }
        }

    }

    enum GraphicOptions
    {
        Change_Image,
        Trigger_Effect
    }

}