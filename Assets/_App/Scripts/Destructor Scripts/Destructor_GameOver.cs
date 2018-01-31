using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructor_GameOver : MonoBehaviour {

    #region Variables
    // public
    // private
    [SerializeField]
    private LayerMask layersToDestroyOnEnter;
    // masters
    private string gameMasterTag = "GameMaster";
    private GameMaster gameMaster;
    #endregion

    #region Unity Methods
    private void OnEnable()
    {
        SetInitialReferences();
    }
    // Use this for initialization
    private void Start () {
		if(gameMaster == null)
        {
            SetInitialReferences();
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (layersToDestroyOnEnter == (layersToDestroyOnEnter | (1 << collision.gameObject.layer)))
        {
            // Lose Life
            gameMaster.CallEventGameOver();
        }
    }
    #endregion

    #region My Methods
    private void SetInitialReferences()
    {
        gameMaster = GameObject.FindGameObjectWithTag(gameMasterTag).GetComponent<GameMaster>();
    }
	#endregion
}