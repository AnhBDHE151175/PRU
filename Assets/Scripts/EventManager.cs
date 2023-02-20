using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class EventManager
{
    static Paddle invoker;
    static UnityAction<int> listener;

    public static void AddEventInvoker(Paddle script)
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
