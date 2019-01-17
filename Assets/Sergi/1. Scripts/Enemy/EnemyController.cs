using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using EnemyBehaviour;
using DG.Tweening;

public class EnemyController : MonoBehaviour {
    #region ACTIONS AND FUNCTIONS
    public Enemy Enemy;
    #endregion
    #region UI OBJECTS
    public SpriteRenderer SpriteRenderer;
    #endregion
    private void Start()
    {
        Enemy.Init(this);
    }

    public void UpdateEnemy(VisualUpdate update, float value = 0, float duration = 0.1f)
    {
        switch(update)
        {
            case (VisualUpdate.Sprite):
                {
                    UpdateEnemy();
                    break;
                }
            case (VisualUpdate.TransparentFX):
                {
                    SpriteRenderer.DOFade(value, duration);
                    break;
                }
        }
    }

    private void UpdateEnemy()
    {
        SpriteRenderer.sprite = Enemy.UpdateSprite;
    }

    public enum VisualUpdate
    {
        Sprite,
        TransparentFX,
        Shake
    }
}

