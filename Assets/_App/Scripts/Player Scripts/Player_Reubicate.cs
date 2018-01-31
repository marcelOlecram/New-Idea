using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Reubicate : MonoBehaviour {

    #region Variables
    // public
    public float offset = 5f;
    // private

    // masters
    private PlayerMaster playerMaster;
    #endregion

    #region Unity Methods
    private void OnEnable()
    {
        SetInitialReferences();
        playerMaster.EventLoseLife += ReubicatePlayer;
    }

    private void OnDisable()
    {
        playerMaster.EventLoseLife -= ReubicatePlayer;
    }
	#endregion
	
	#region My Methods
    public void ReubicatePlayer()
    {
        Vector3 newPos = transform.position;
        newPos.x += offset;
        newPos.y += offset / 2f;
        transform.position = newPos;
    }
    private void SetInitialReferences()
    {
        playerMaster = GetComponent<PlayerMaster>();
    }
	#endregion
}