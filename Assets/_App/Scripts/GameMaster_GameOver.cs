using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster_GameOver : MonoBehaviour {

    #region Variables
    // public
    public GameObject GameOverUI;
    // private
    // masters
    private string playerTag = "Player";
    private PlayerMaster playerMaster;
    #endregion

    #region Unity Methods

    private void OnEnable()
    {
        SetInitialReferences();
        playerMaster.EventDestroyPlayer += GameOver;
    }

    private void OnDisable()
    {
        playerMaster.EventDestroyPlayer -= GameOver;
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
        playerMaster = GameObject.FindGameObjectWithTag(playerTag).GetComponent<PlayerMaster>();
    }
	#endregion
}