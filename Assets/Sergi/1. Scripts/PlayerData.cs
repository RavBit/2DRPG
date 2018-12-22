using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class PlayerData : MonoBehaviour, BaseStats{
    [SerializeField]
    protected int health = 100;

    public Action<EventParam> test;

    private void Start()
    {
    }

    public void AdjustHealth(int health)
    {
        this.health = this.health - health;
    }
    //public void TestDebug(EventParam test)
    //{
    //    Debug.Log("EVENT 2 CALLED " + test);
    //}

}