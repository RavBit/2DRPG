using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Timers;

namespace EnemyBehaviour
{
    [CreateAssetMenu(menuName = "2DRPG/AI/Actions/ExMinigame/Throw")]
    public class Throw : ExMinigame
    {
        private Attack controller;

        public PlayerController PlayerController;

        private Timer timer;
        private System.DateTime dateTime;

        public ProjectileProperties ProjectileProperties;
        private bool running;

        public override void Container(Attack controller)
        {
            this.controller = controller;
        }

        public override void Run()
        {
            EventManager.StartListening("Update", Running);
            timer = new System.Timers.Timer();
            PlayerController.Init();
            timer.Interval = (Time * 1000);
            timer.Start();
            dateTime = System.DateTime.Now;
            timer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            running = true;
            exMiniGame();
        }

        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            timer.Stop();
            Debug.Log("Stopping Timer");
            running = false;
            Stop();
        }

        public override void Running()
        {
            PlayerController.MoveKeyboard();
        }


        private void exMiniGame()
        {
            if (!running)
                return;
            Timer time = new System.Timers.Timer();
            time.Interval = (1000);
            time.Start();
            time.Elapsed += new ElapsedEventHandler(shootProjecttile);
        }

        private void shootProjecttile(object source, ElapsedEventArgs e)
        {
            exMiniGame();
        }

        public override void Stop()
        {
            EventManager.StopListening("Update", Running);
            controller.Stop();
        }
    }
}
