using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Zoom : MonoBehaviour {

    #region Variables
    // public
    public float zooming;
    public float minZoom;
    public float maxZoom;
    // private
    private Camera myCamera;
	#endregion
	
	#region Unity Methods
	// Use this for initialization
	private void Start () {
        SetInitialReferences();        
	}
	
	// Update is called once per frame
	private void Update () {
        CheckForZoomInput();
	}
    #endregion

    #region My Methods
    void CheckForZoomInput()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            myCamera.orthographicSize -= zooming * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.E))
        {
            myCamera.orthographicSize += zooming * Time.deltaTime;
        }

        ClampZoom();
    }

    void SetInitialReferences()
    {
        myCamera = Camera.main;
        zooming = myCamera.orthographicSize;
    }

    void ClampZoom()
    {
        myCamera.orthographicSize = Mathf.Clamp(myCamera.orthographicSize, minZoom, maxZoom);
    }
    #endregion
}