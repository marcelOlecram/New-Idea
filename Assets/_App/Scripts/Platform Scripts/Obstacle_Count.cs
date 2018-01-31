using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle_Count : MonoBehaviour {

    #region Variables
    // public
    public bool counted = false;
    // private
    private string playerTag = "Player";
    private string destructorTag = "Destructor";
    private GameObject player;
    private GameObject destructor;
    // masters
    private PlatformMaster platformMaster;
    private PlayerMaster playerMaster;
    #endregion

    #region Unity Methods
    private void OnEnable()
    {
        SetInitialReferences();
        platformMaster.EventPlayerLandsObstacle += CountObstacle;
    }

    private void OnDisable()
    {
        platformMaster.EventPlayerLandsObstacle -= CountObstacle;
    }
    #endregion

    #region My Methods
    void SetInitialReferences()
    {
        platformMaster = GetComponent<PlatformMaster>();

        player = GameObject.FindGameObjectWithTag(playerTag);
        destructor = GameObject.FindGameObjectWithTag(destructorTag);
        playerMaster = player.GetComponent<PlayerMaster>();
    }

    // Cuenta el obstaculo si no lo fue hecho
    private void CountObstacle()
    {
        if (!counted)
        {
            counted = true;
            // jugador
            playerMaster.CallEventDecreaseScore();
            // destructor
            destructor.GetComponent<Destructor_Movement>().DecreaseSpeed();
            
        }
    }
    #endregion
}