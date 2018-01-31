using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMaster_RestartLevel : MonoBehaviour {

    #region Variables
    // masters
    private GameMaster gameMaster;
    #endregion

    #region Unity Methods
    private void OnEnable()
    {
        SetInitialReferences();
        gameMaster.EventRestartGame += RestartGame;
    }

    private void OnDisable()
    {
        gameMaster.EventRestartGame -= RestartGame;
    }
	#endregion
	
	#region My Methods
    private void SetInitialReferences()
    {
        gameMaster = GetComponent<GameMaster>();
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
	#endregion
}