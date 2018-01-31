using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_Count : MonoBehaviour {

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
    // Use this for initialization
    private void OnEnable()
    {
        SetInitialReferences();
        platformMaster.EventPlayerLandsPlatform += CountPlatform;
    }

    private void OnDisable()
    {
        platformMaster.EventPlayerLandsPlatform -= CountPlatform;
    }
    #endregion

    #region My Methods
    void SetInitialReferences()
    {
        player = GameObject.FindGameObjectWithTag(playerTag);
        destructor = GameObject.FindGameObjectWithTag(destructorTag);

        playerMaster = player.GetComponent<PlayerMaster>();

        platformMaster = GetComponent<PlatformMaster>();
    }

    // Cuenta la plataforma si es que no fue contada, aplica acciones correspondientes con el Player y el Destructor
    private void CountPlatform()
    {
        if (!counted)
        {
            counted = true;
            // jugador
            playerMaster.CallEventIncreaseScore();
            // destructor
            destructor.GetComponent<Destructor_Movement>().IncreaseSpeed();
        }
    }
    #endregion
}