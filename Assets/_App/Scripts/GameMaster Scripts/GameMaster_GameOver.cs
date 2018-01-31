using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster_GameOver : MonoBehaviour {

    #region Variables
    // public
    public GameObject GameOverUI;
    // private
    // masters
    private GameMaster gameMaster;
    #endregion

    #region Unity Methods

    private void OnEnable()
    {
        SetInitialReferences();
        gameMaster.EventGameOver += GameOver;
    }

    private void OnDisable()
    {
        gameMaster.EventGameOver -= GameOver;
    }
	#endregion
	
	#region My Methods
    public void GameOver()
    {
        // stop time flow
        Time.timeScale = 0f;
        // UI
        GameOverUI.SetActive(true);        
    }

    private void SetInitialReferences()
    {
        gameMaster = GetComponent<GameMaster>();        
    }
	#endregion
}