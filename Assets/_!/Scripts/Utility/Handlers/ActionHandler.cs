using System;
using System.Collections.Generic;
using UnityEngine;

public static class ActionKey
{
    public const string GameStateChangeKey = "GameStateChangeKey";
    public const string CoinUpdateKey = "CoinUpdateKey";
    public const string LevelUpdateKey = "LevelUpdateKey";
    public const string GameLevelStateChangedKey = "GameLevelStateChangedKey";
    public const string MoveItemKey = "MoveItemKey";
    public const string CompleteGameKey = "CompleteGameKey";
    public const string OnFruitCollisionKey = "OnFruitCollisionKey";
}

public static class ActionHandler<T>
{
    private static readonly Dictionary<string, Action<T>> Actions = new Dictionary<string, Action<T>>();
    
    public static void Register(string myActionKey, Action<T> myAction)
    {
        if (!Actions.ContainsKey(myActionKey))
        {
            Actions[myActionKey] = myAction;
            Debug.Log($"Action key {myActionKey} registered");
        }
        else
        {
            Actions[myActionKey] += myAction;
            Debug.Log($"Action key {myActionKey} added");
        }
    }

    public static void Unregister(string myActionKey, Action<T> myAction)
    {
        if (!Actions.ContainsKey(myActionKey))
        {
            Debug.LogWarning($"There is no action with key: {myActionKey}");
        }
        else
        {
            Actions[myActionKey] -= myAction;
            Debug.Log($"Action with key {myActionKey} unregistered");
        }
    }
    
    public static void Raise(string myActionKey, T actionArgs)
    {
        if (Actions.TryGetValue(myActionKey, out var @action))
        {
            @action?.Invoke(actionArgs);
            Debug.Log($"Action {myActionKey} raised");
        }
        else
        {
            Debug.LogWarning($"There is no listener found with key {myActionKey}");
        }
    }
}

public static class ActionHandler
{
    private static readonly Dictionary<string, Action> NonGenericActions = new Dictionary<string, Action>();

    public static void Register(string myActionKey, Action myAction)
    {
        if (!NonGenericActions.ContainsKey(myActionKey))
        {
            NonGenericActions[myActionKey] = myAction;
            Debug.Log($"Action key {myActionKey} registered");
        }
        else
        {
            NonGenericActions[myActionKey] += myAction;
            Debug.Log($"Action key {myActionKey} added");
        }
    }

    public static void Unregister(string myActionKey, Action myAction)
    {
        if (!NonGenericActions.ContainsKey(myActionKey))
        {
            Debug.LogWarning($"There is no action with key: {myActionKey}");
        }
        else
        {
            NonGenericActions[myActionKey] -= myAction;
            Debug.Log($"Action with key {myActionKey} unregistered");
        }
    }

    public static void Raise(string myActionKey)
    {
        if (NonGenericActions.TryGetValue(myActionKey, out var @action))
        {
            @action?.Invoke();
            Debug.Log($"Action {myActionKey} raised");
        }
        else
        {
            Debug.LogWarning($"There is no listener found with key {myActionKey}");
        }
    }
}