using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster_StartGame : MonoBehaviour {

    #region Variables
    // public
    // private
    // masters
    private GameMaster gameMaster;
    #endregion

    #region Unity Methods
    private void Awake()
    {
        SetInitialReferences();
        gameMaster.CallEventStartGame();
    }
    #endregion

    #region My Methods
    private void SetInitialReferences()
    {
        gameMaster = GetComponent<GameMaster>();
    }
	#endregion
}