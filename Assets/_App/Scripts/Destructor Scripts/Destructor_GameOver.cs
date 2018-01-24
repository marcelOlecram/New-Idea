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
    private string playerTag= "Player";
    private PlayerMaster playerMaster;
    #endregion

    #region Unity Methods
    private void OnEnable()
    {
        SetInitialReferences();
    }
    // Use this for initialization
    private void Start () {
		if(playerMaster == null)
        {
            SetInitialReferences();
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (layersToDestroyOnEnter == (layersToDestroyOnEnter | (1 << collision.gameObject.layer)))
        {
            // Lose Life
            playerMaster.CallEventDestroyPlayer();
        }
    }
    #endregion

    #region My Methods
    private void SetInitialReferences()
    {
        playerMaster = GameObject.FindGameObjectWithTag(playerTag).GetComponent<PlayerMaster>();
    }
	#endregion
}