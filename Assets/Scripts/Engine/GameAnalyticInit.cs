using UnityEngine;
using GameAnalyticsSDK;

public class GameAnalyticInit : MonoBehaviour, IGameAnalyticsATTListener
{
    void Start()
    {
        if(Application.platform == RuntimePlatform.IPhonePlayer)
        {
            GameAnalytics.RequestTrackingAuthorization(this);
        }
        else
        {
            GameAnalytics.Initialize();
        }
    }
    
    public static void LogGameStart(int level )
    {
        GameAnalytics.NewProgressionEvent(GAProgressionStatus.Start, "Level" + level);
      
    }

    public static void LogGameOver(int level, bool success , float score = 0  )
    {
        GameAnalytics.NewProgressionEvent(  success ? GAProgressionStatus.Complete : GAProgressionStatus.Fail  , "Level" + level);
     
    }


    public void GameAnalyticsATTListenerNotDetermined()
    {
        GameAnalytics.Initialize();
    }
    public void GameAnalyticsATTListenerRestricted()
    {
        GameAnalytics.Initialize();
    }
    public void GameAnalyticsATTListenerDenied()
    {
        GameAnalytics.Initialize();
    }
    public void GameAnalyticsATTListenerAuthorized()
    {
        GameAnalytics.Initialize();
    }
}
