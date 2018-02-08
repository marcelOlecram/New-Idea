using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructor_Destroy : MonoBehaviour {

    #region Variables
    // public
    // private
    [SerializeField]
    private LayerMask layersToDestroyOnExit;
    [SerializeField]
    private LayerMask layersToDestroyOnEnter;
    // masters
    private string playerTag = "Player";
    private PlayerMaster playerMaster;
    #endregion

    #region Unity Methods
    private void OnEnable()
    {
        SetInitialReferences();        
    }

    private void Start()
    {
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
            playerMaster.CallEventLoseLife();
        }

        if(layersToDestroyOnExit == (layersToDestroyOnExit | (1<< collision.gameObject.layer))){
            collision.gameObject.GetComponent<PlatformMaster>().CallEventBlockPlatform();       
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        //Debug.Log(collision.name + " hited");
        if(layersToDestroyOnExit == (layersToDestroyOnExit | (1 << collision.gameObject.layer)))
        {
            // Destroy
            Destroy(collision.gameObject);
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