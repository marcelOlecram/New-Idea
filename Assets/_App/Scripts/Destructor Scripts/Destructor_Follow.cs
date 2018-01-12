using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructor_Follow : MonoBehaviour {

    #region Variables
    // public
    // private
    [SerializeField]
    private Transform playerTransform;
    private Transform myTransform;
	#endregion
	
	#region Unity Methods
	// Use this for initialization
	private void Start () {
        SetInitialReferences();
	}
	
	// Update is called once per frame
	private void Update () {
        myTransform.position = new Vector3(playerTransform.position.x, myTransform.position.y);
	}
    #endregion

    #region My Methods
    void SetInitialReferences()
    {
        myTransform = transform;
    }
	#endregion
}