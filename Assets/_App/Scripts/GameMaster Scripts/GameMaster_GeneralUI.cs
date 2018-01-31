using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster_GeneralUI : MonoBehaviour {

    #region Variables
    // public
    public GameObject generalUI;    
    // masters
    private GameMaster gameMaster;
    #endregion

    #region Unity Methods
    private void OnEnable()
    {
        SetInitialReferences();
        gameMaster.EventPauseGame += DeactivateUI;
        gameMaster.EventContinueGame += ActivateUI;
        gameMaster.EventGameOver += DeactivateUI;
    }

    private void OnDisable()
    {
        gameMaster.EventPauseGame -= DeactivateUI;
        gameMaster.EventContinueGame -= ActivateUI;
        gameMaster.EventGameOver -= DeactivateUI;
    }
	#endregion
	
	#region My Methods
    private void SetInitialReferences()
    {
        gameMaster = GetComponent<GameMaster>();
    }

    private void ActivateUI()
    {
        generalUI.SetActive(true);
    }

    private void DeactivateUI()
    {
        generalUI.SetActive(false);
    }
	#endregion
}