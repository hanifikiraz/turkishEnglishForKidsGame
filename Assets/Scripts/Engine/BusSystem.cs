using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class BusSystem
{
    //Main actions
    public static Action OnNewLevelStart;

    public static void CallNewLevelStart()
    {
        OnNewLevelStart?.Invoke();
    }

    public static Action<bool> OnLevelDone;

    public static void CallLevelDone(bool status)
    {
        OnLevelDone?.Invoke(status);
    }

    public static Action OnNewLevelLoad;

    public static void CallNewLevelLoad()
    {
        OnNewLevelLoad?.Invoke();
    }

    public static Action<int> OnAddCoin;

    public static void CallAddCoin(int value)
    {
        OnAddCoin?.Invoke(value);
    }

    public static Action OnSetCoins;

    public static void CallSetCoins()
    {
        OnSetCoins?.Invoke();
    }

    public static Action<bool> OnSoundChange;

    public static void CallSoundChange(bool value)
    {
        OnSoundChange.Invoke(value);
    }

    public static Action<bool> OnVibrationChange;

    public static void CallVibrationChange(bool value)
    {
        OnVibrationChange.Invoke(value);
    }


    //Gameplay actions
    public static Action<bool> OnWrongAnswer;

    public static void CallWrongAnswer(bool value)
    {
        OnWrongAnswer?.Invoke(value);
    }
    public static Action<int> OnPlayerSetAnim;

    public static void CallPlayerSetAnim(int value)
    {
        OnPlayerSetAnim?.Invoke(value);
    }
}
