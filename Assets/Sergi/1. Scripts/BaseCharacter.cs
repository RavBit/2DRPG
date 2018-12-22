using UnityEngine;
using System.Collections.Generic;
using StateMachine;

public abstract class BaseCharacter : ScriptableObject, BaseStats
{
    public void AdjustHealth(int amount)
    {
        throw new System.NotImplementedException();
    }
}


[System.Serializable]
public class Dialog
{
    public DialogType Type;
    public string text;

}
[CreateAssetMenu(fileName = "Boss", menuName = "2DRPG/Create Boss", order = 1)]
public class Boss : BaseCharacter
{

}


interface BaseStats
{
    void AdjustHealth(int amount);
}

public enum DialogType
{
    Neutral,
    Cook,
    Item,
    Interact,
    Fight
}