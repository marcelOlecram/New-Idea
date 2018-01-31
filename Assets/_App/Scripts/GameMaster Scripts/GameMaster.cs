using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour {

    #region Delegados
    public delegate void GameEventHandler();
    public event GameEventHandler EventPauseGame;
    public event GameEventHandler EventContinueGame;
    public event GameEventHandler EventRestartGame;
    public event GameEventHandler EventGameOver;
    public event GameEventHandler EventGoToMainMenu;
    #endregion

    #region Variables
    public bool gameOver = false;
    public bool isPaused = false;
    #endregion

    #region My Methods
    public void CallEventPauseGame()
    {
        if (EventPauseGame != null)
        {
            isPaused = true;
            EventPauseGame();
        }
    }

    public void CallEventContinueGame()
    {
        if (EventContinueGame!=null)
        {
            isPaused = false;
            EventContinueGame();
        }
    }

    public void CallEventRestartGame()
    {
        if (EventRestartGame != null)
        {
            EventRestartGame();
        }
    }

    public void CallEventGameOver()
    {
        if (EventGameOver != null)
        {
            gameOver = true;
            EventGameOver();
        }
    }

    public void CallEventGoToMainMenu()
    {
        if (EventGoToMainMenu != null)
        {
            EventGoToMainMenu();
        }
    }
    #endregion
}