using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace EnemyBehaviour
{

    public abstract class Action : ScriptableObject
    {
        public abstract void Behaviour(Enemy controller);

    }
    public abstract class Minigame : ScriptableObject
    {
        [Header("Base attack per hit:")]
        [Range(0, 10)]
        public uint baseAttack;
        public abstract void Container(Cook _controller);
        public abstract void Run();
        public abstract void Stop();
        public abstract void Running();
    }
    public abstract class ExMinigame : ScriptableObject
    {
        [Header("Time attack lasts:")]
        [Range(0, 20)]
        public int Time;
        public abstract void Container(Attack _controller);
        public abstract void Run();
        public abstract void Stop();
        public abstract void Running();
    }
}