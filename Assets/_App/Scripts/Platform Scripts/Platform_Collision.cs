using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_Collision : MonoBehaviour {

    #region Variables
    // public
    // private
    private string playerTag = "Player";
    private string platformTag = "Platform";
    private string obstacleTag = "Obstacle";
    // masters
    private PlatformMaster platformMaster;
	#endregion
	
	#region Unity Methods	
	private void OnEnable () {
        SetInitialReferences();
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(playerTag))
        {
            if (gameObject.CompareTag(platformTag))
            {
                platformMaster.CallEventPlayerLandsPlatform();
                return;
            }
            if (gameObject.CompareTag(obstacleTag))
            {
                platformMaster.CallEventPlayerLandsObstacle();
                return;
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(playerTag))
        {
            if (gameObject.CompareTag(platformTag))
            {
                platformMaster.CallEventPlayerLeavesPlatform();
                return;
            }            
        }
    }
    #endregion

    #region My Methods
    private void SetInitialReferences()
    {
        platformMaster = GetComponent<PlatformMaster>();
    }
	#endregion
}