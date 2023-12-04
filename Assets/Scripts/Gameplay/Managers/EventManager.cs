using UnityEngine.Events;

public static class EventManager
{
    public static event UnityAction OnGameStarted;
    public static event UnityAction OnGameFinished;
    public static event UnityAction OnGameSuccessed;
    public static event UnityAction OnGameFailed;
    
    public static event UnityAction OnLevelLoaded;
    
    public static event UnityAction OnCollectorSuccess;
    public static event UnityAction OnCollectorFailed;
    
    public static event UnityAction OnMovedToNextStart;
    
    public static event UnityAction OnHittedBallCollector;
    public static event UnityAction OnHittedLevelEnd;

    public static void InvokeGameStarted()
    {
        OnGameStarted?.Invoke();
    }
    
    public static void InvokeOnGameFinished()
    {
        OnGameFinished?.Invoke();
    }
    
    public static void InvokeOnGameSuccessed()
    {
        OnGameSuccessed?.Invoke();
    }
    
    public static void InvokeOnGameFailed()
    {
        OnGameFailed?.Invoke();
    }
    
    public static void InvokeOnLevelLoaded()
    {
        OnLevelLoaded?.Invoke();
    }
    
    public static void InvokeOnCollectorSuccess()
    {
        OnCollectorSuccess?.Invoke();
    }
    
    public static void InvokeOnCollectorFailed()
    {
        OnCollectorFailed?.Invoke();
    }
    
    public static void InvokeOnMovedToNextStart()
    {
        OnMovedToNextStart?.Invoke();
    }
    
    public static void InvokeOnHittedBallCollector()
    {
        OnHittedBallCollector?.Invoke();
    }
    
    public static void InvokeOnHittedLevelEnd()
    {
        OnHittedLevelEnd?.Invoke();
    }

    
    
}