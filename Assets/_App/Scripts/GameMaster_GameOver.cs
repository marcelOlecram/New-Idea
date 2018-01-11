using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster_GameOver : MonoBehaviour {

    #region Variables
    // public
    public GameObject GameOverUI;
	// private
	#endregion
	
	#region Unity Methods
	// Use this for initialization
	private void Start () {
		
	}
	
	// Update is called once per frame
	private void Update () {
		
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
	#endregion
}