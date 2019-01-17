using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Timers;

namespace EnemyBehaviour
{
    [CreateAssetMenu(menuName = "2DRPG/AI/Actions/Minigame/Pick")]
    public class Pick : Minigame
    {
        private Cook controller;
        [Header("Time for player to complete attack:")]
        [SerializeField]
        private uint time;
        [Header("Input current attack:")]
        public List<KeyCode> sequence;
        [Header("Current sequence number:")]
        [SerializeField]
        private int sequencenumber;

        [Header("Prefab from detachable object:")]
        [SerializeField]
        private DetachObject detachable;
        public DetachObject detachableContainer;

        private Timer timer;
        private System.DateTime dateTime;
        [SerializeField]
        private int currentDamage = 0;

        public override void Container(Cook controller)
        {
            this.controller = controller;
        }

        public override void Run()
        {
            EventManager.StartListening("Update", Running);
            GameObject _dc = Instantiate(detachable.gameObject, null) as GameObject;
            detachableContainer = _dc.GetComponent<DetachObject>();
            timer = new System.Timers.Timer();
            timer.Interval = (time * 1000);
            timer.Start();
            dateTime = System.DateTime.Now;
            timer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            sequencenumber = 0;
        }

        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            timer.Stop();
            Debug.Log("Stopping Timer");
            Stop();
        }

        public override void Running()
        {
            detachableContainer.TextCommands.UpdateText("PRESS: " + sequence[sequencenumber].ToString());
            System.TimeSpan ts = System.DateTime.Now - dateTime;
            Debug.Log("Countdown: " + Mathf.Round(10 - ts.Seconds));
            if (Input.GetKeyDown(sequence[sequencenumber]))
            {
                Debug.Log("Sequence count: " + (baseAttack * (sequence.Count)));
                if (++sequencenumber == sequence.Count || (baseAttack * (sequence.Count) <= currentDamage))
                {
                    if (baseAttack * (sequence.Count) == currentDamage)
                    {
                        sequencenumber = 0;
                        //controller.minigamecounter++;
                    } 
                    timer.Stop();
                    Stop();
                    return;
                }
                currentDamage += (int)baseAttack;
                detachableContainer.UpdateDamage();
            }
        }
        public override void Stop()
        {
            controller.CalculateDamage(((int)(baseAttack * sequencenumber)));
            sequencenumber = 0;
            Destroy(detachableContainer.gameObject);
            EventManager.StopListening("Update", Running);
        }
    }
}