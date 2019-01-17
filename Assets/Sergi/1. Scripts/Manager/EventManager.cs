using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace System
{
    public delegate void Action();
}

public class EventManager : MonoBehaviour
{

    private Dictionary<string, Action<System.Object>> eventArgDictionary;
    private Dictionary<string, Action> eventDictionary;
    private Dictionary<string, UnityEvent> UeventDictionairy;

    //private Dictionary<string, Event> eventsDictionairy;

    private static EventManager eventManager;

    public static EventManager instance
    {
        get
        {
            if (!eventManager)
            {
                eventManager = FindObjectOfType(typeof(EventManager)) as EventManager;

                if (!eventManager)
                {
                    Debug.LogError("There needs to be one active EventManger script on a GameObject in your scene.");
                }
                else
                {
                    eventManager.Init();
                }
            }
            return eventManager;
        }
    }

    void Init()
    {
        if (eventArgDictionary == null)
        {
            eventArgDictionary = new Dictionary<string, Action<System.Object>>();
        }
        if (UeventDictionairy == null)
        {
            UeventDictionairy = new Dictionary<string, UnityEvent>();
        }
        if(eventDictionary == null)
        {
            eventDictionary = new Dictionary<string, Action>();
        }
    }

    public static void StartListening(string eventName, Action<System.Object> listener)
    {
        Action<System.Object> thisEvent;
        if (instance.eventArgDictionary.TryGetValue(eventName, out thisEvent))
        {
            //Add more event to the existing one
            thisEvent += listener;

            //Update the Dictionary
            instance.eventArgDictionary[eventName] = thisEvent;
        }
        else
        {
            //Add event to the Dictionary for the first time
            thisEvent += listener;
            instance.eventArgDictionary.Add(eventName, thisEvent);
        }
    }
    public static void StartListening(string eventName, Action listener)
    {
        Action thisEvent;
        if (instance.eventDictionary.TryGetValue(eventName, out thisEvent))
        {
            //Add more event to the existing one
            thisEvent += listener;

            //Update the Dictionary
            instance.eventDictionary[eventName] = thisEvent;
        }
        else
        {
            //Add event to the Dictionary for the first time
            thisEvent += listener;
            instance.eventDictionary.Add(eventName, thisEvent);
        }
    }

    public static void UStartListening(string eventName, UnityAction listener)
    {
        UnityEvent thisEvent;
        if (instance.UeventDictionairy.TryGetValue(eventName, out thisEvent))
        {
            //Add more event to the existing one
            thisEvent.AddListener(listener);

            //Update the Dictionary
            instance.UeventDictionairy[eventName] = thisEvent;
        }
        else
        {
            //Add event to the Dictionary for the first time
            thisEvent = new UnityEvent();
            thisEvent.AddListener(listener);
            instance.UeventDictionairy.Add(eventName, thisEvent);
        }
    }

    //public static void StopListening(string eventName, Action<EventParam> listener)
    //{
    //    if (eventManager == null) return;
    //    Action<EventParam> thisEvent;
    //    if (instance.eventArgDictionary.TryGetValue(eventName, out thisEvent))
    //    {
    //        //Remove event from the existing one
    //        thisEvent -= listener;

    //        //Update the Dictionary
    //        instance.eventArgDictionary[eventName] = thisEvent;
    //    }
    //}

    public static void StopListening(string eventName, Action listener)
    {
        if (eventManager == null) return;
        Action thisEvent;
        if (instance.eventDictionary.TryGetValue(eventName, out thisEvent))
        {
            //Remove event from the existing one
            thisEvent -= listener;

            //Update the Dictionary
            instance.eventDictionary[eventName] = thisEvent;
        }
    }

    public static void TriggerEvent(string eventName, System.Object eventParam)
    {
        Action<System.Object> thisEvent = null;
        if (instance.eventArgDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.Invoke(eventParam);
            // OR USE  instance.eventArgDictionary[eventName](eventParam);
        }
    }

    public static void TriggerEvent(string eventName)
    {
        Action thisEvent = null;
        if (instance.eventDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.Invoke();
            
        }
    }

    public static Action GetEvent(string eventName)
    {
        Action thisEvent = null;
        if (instance.eventDictionary.TryGetValue(eventName, out thisEvent))
        {
            return thisEvent;
            // OR USE  instance.eventArgDictionary[eventName](eventParam);
        }
        return null;
    }
    public static void UTriggerEvent(string eventName)
    {
        UnityEvent thisEvent = null;
        if (instance.UeventDictionairy.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.Invoke();
        }
    }

}

//Re-usable structure/ Can be a class to. Add all parameters you need inside it
public class EventParam
{

}


/*public class EventParamBase
{
    //public int? GetIntParam() { return null; }
    //public float? GetFloatParam() { return null; }
    //public string? GetStringParam() { return null; }
}


public class IntEventParam : EventParamBase
{
    private int value;

    public IntEventParam(int value) {
        this.value = value;
    }

    public override int? GetIntParam()
    {
        return value;
    }

}

public class Data1
{
    int test;
}*/
