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
    private PlayerMaster playerMaster;
	#endregion
	
	#region Unity Methods
	// Use this for initialization
	private void Start () {
        SetInitialReferences();
	}
	
	// Update is called once per frame
	private void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(playerTag))
        {
            if (!counted)
            {
                // TODO posible llamada a evento. evento ContarPlataforma
                // TODO posible llamada a evento. evento IncrementarPuntaje
                // TODO temporal
                playerMaster.CallEventIncreaseScore();
                destructor.GetComponent<Destructor_Movement>().IncreaseSpeed();
                counted = true;
            }           
        }
    }
    #endregion

    #region My Methods
    void SetInitialReferences()
    {
        player = GameObject.FindGameObjectWithTag(playerTag);
        destructor = GameObject.FindGameObjectWithTag(destructorTag);

        playerMaster = player.GetComponent<PlayerMaster>();
    }
    #endregion
}