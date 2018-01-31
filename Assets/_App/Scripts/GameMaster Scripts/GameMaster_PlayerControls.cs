using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster_PlayerControls : MonoBehaviour {

    #region Variables
    // public
    public Player_Movement playerMovementScript;
    // private
    // masters
    private GameMaster gameMaster;
    #endregion

    #region Unity Methods
    private void OnEnable()
    {
        SetInitialReferences();
        gameMaster.EventPauseGame += DeactivateControls;
        gameMaster.EventContinueGame += ActivateControls;
        gameMaster.EventGameOver += DeactivateControls;
    }

    private void OnDisable()
    {
        gameMaster.EventPauseGame -= DeactivateControls;
        gameMaster.EventContinueGame -= ActivateControls;
        gameMaster.EventGameOver -= DeactivateControls;
    }
	#endregion
	
	#region My Methods
    private void SetInitialReferences()
    {
        gameMaster = GetComponent<GameMaster>();
    }

    private void ActivateControls()
    {
        playerMovementScript.enabled = true;
    }

    private void DeactivateControls()
    {
        playerMovementScript.enabled = false;
    }
    #endregion
}