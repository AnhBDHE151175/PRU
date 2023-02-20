using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class EventManager
{
    static Ball invoker;
    static UnityAction<int> listener;

    public static void AddEventInvoker(Ball script)
    {
        invoker = script;
        if (listener != null)
        {
            invoker.AddedEventListener(listener);
        }
    }

    public static void AddEventListener(UnityAction<int> handler)
    {
        listener = handler;
        if (invoker != null)
        {
            invoker.AddedEventListener(listener);
        }
    }
}


