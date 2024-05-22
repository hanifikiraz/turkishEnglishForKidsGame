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
    
    public static Action<PairingButtons> OnPairingButtons;

    public static void CallPairingButtons(PairingButtons value)
    {
        OnPairingButtons?.Invoke(value);
    }
    
    public static Action<DoubleSideObject> OnDoubleSideObject;

    public static void CallDoubleSideObject(DoubleSideObject value)
    {
        OnDoubleSideObject?.Invoke(value);
    }
    
    public static Action<int> OnPlayerSetAnim;

    public static void CallPlayerSetAnim(int value)
    {
        OnPlayerSetAnim?.Invoke(value);
    }
    
    // Jump Level Controller

    public static Action OnPlayerJump;

    public static void CallPlayerJump()
    {
        OnPlayerJump?.Invoke();
    }

    public static Action OnJumpLevelDone;
    public static void CallJumpLevelDone()
    {
        OnJumpLevelDone?.Invoke();
    }

    public static Action<int> OnBasketMove;

    public static void CallBasketMove(int value)
    {
        OnBasketMove?.Invoke(value);
    }
    
    public static Action<int> OnTankMove;

    public static void CallTankMove(int value)
    {
        OnTankMove?.Invoke(value);
    }

    public static Action<float> OnSetFruitScore;

    public static void CallSetFruitScore(float value)
    {
        OnSetFruitScore?.Invoke(value);
    }

    public static Action OnMovingObjectBomb;

    public static void CallMovingObjectBomb()
    {
        OnMovingObjectBomb?.Invoke();
    }
    
    public static Action OnAAGameLevelEnd;

    public static void CallAAGameLevelEnd()
    {
        OnAAGameLevelEnd?.Invoke();
    }
    
    public static Action OnMaterialControlLetter;

    public static void CallMaterialControlLetter()
    {
        OnMaterialControlLetter?.Invoke();
    }
    
    public static Action OnLetterCompletedControl;

    public static void CallLetterCompletedControl()
    {
        OnLetterCompletedControl?.Invoke();
    }

    public static Action<int> OnGoAreaValue;

    public static void CallGoAreValue(int value)
    {
        OnGoAreaValue?.Invoke(value);
    }

    public static Action OnRecyleLevelEnd;

    public static void CallRecyleLevelEnd()
    {
        OnRecyleLevelEnd?.Invoke();
    }
}
