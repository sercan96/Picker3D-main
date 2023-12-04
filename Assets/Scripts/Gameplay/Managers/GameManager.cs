using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public void StartGame()
    {
        EventManager.InvokeGameStarted();
    }
    public void GameSuccessed()
    {
        EventManager.InvokeOnGameSuccessed();
        EventManager.InvokeOnGameFinished();
    }
    public void GameFailed()
    {
        EventManager.InvokeOnGameFailed();
        EventManager.InvokeOnGameFinished();
    }
    private void OnEnable()
    {
        EventManager.OnCollectorFailed += GameFailed;
        EventManager.OnMovedToNextStart += GameSuccessed;
    }
    private void OnDisable()
    {
        EventManager.OnCollectorFailed += GameFailed;
        EventManager.OnMovedToNextStart -= GameSuccessed;
    }
}
