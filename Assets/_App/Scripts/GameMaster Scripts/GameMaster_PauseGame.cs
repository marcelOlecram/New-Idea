using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster_PauseGame : MonoBehaviour {

    #region Variables
    // public
    public GameObject PauseGameUI;
    // private
    private bool isPaused = false;
    // masters
    private GameMaster gameMaster;
    #endregion

    #region Unity Methods
    private void OnEnable()
    {
        SetInitialReferences();
        gameMaster.EventPauseGame += PauseGame;
        gameMaster.EventContinueGame += ContinueGame;

        gameMaster.EventStartGame += ContinueGame;
    }

    private void OnDisable()
    {
        gameMaster.EventPauseGame -= PauseGame;
        gameMaster.EventContinueGame -= ContinueGame;

        gameMaster.EventStartGame -= ContinueGame;
    }

    private void Update()
    {
        CheckPauseInput();
    }
    #endregion

    #region My Methods
    private void SetInitialReferences()
    {
        gameMaster = GetComponent<GameMaster>();
    }

    private void PauseGame()
    {
        // pause time flow
        Time.timeScale = 0f;
        // UI
        PauseGameUI.SetActive(true);
    }

    private void ContinueGame()
    {
        // continue time flow
        Time.timeScale = 1f;
        // UI
        PauseGameUI.SetActive(false);
    }

    private void CheckPauseInput()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                gameMaster.CallEventContinueGame();
            }
            else
            {
                gameMaster.CallEventPauseGame();
            }
            isPaused = !isPaused;
        }
    }
    #endregion
}