using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyContainer : MonoBehaviour {
    #region ACTIONS AND FUNCTIONS
    public Enemy enemy;
    private Action<EventParam> EnemyInit;

    #endregion
    #region UI OBJECTS
    public SpriteRenderer SpriteRenderer;
    #endregion
    private void Start()
    {
        EnemyInit = new Action<EventParam>(Draw);
        EventManager.StartListening("EnemyInit", EnemyInit);
    }

    public void Init(Enemy enemy)
    {
        this.enemy = enemy;  
    }

    private void Draw(EventParam ev)
    {
        Debug.Log("Sprite: " + enemy.GetSprite());
        SpriteRenderer.sprite = enemy.GetSprite();
    }
}
