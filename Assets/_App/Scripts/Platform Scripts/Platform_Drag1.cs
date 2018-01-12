using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_Drag1 : MonoBehaviour {

    #region Variables
    // public
    public GameObject gameObjectToDrag;
    public Vector3 gOCenter;
    public Vector3 touchPosition;
    public Vector3 offset;
    public Vector3 newGOCenter;

    public bool draggingMode = false;
    // private
    private RaycastHit hit;
    #endregion

    #region Unity Methods
    // Use this for initialization
    private void Start () {
		
	}
	
	// Update is called once per frame
	private void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.Log(ray.origin);
            Debug.Log(ray.direction);
            Debug.DrawRay(ray.origin, ray.direction, Color.blue, 2f);            
            if (Physics.Raycast(ray, out hit))
            {
                gameObjectToDrag = hit.collider.gameObject;
                gOCenter = gameObjectToDrag.transform.position;
                touchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                offset = touchPosition - gOCenter;
                draggingMode = true;
            }
        }

        if (Input.GetMouseButton(0))
        {
            if (draggingMode)
            {
                touchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                newGOCenter = touchPosition - offset;
                gameObjectToDrag.transform.position = new Vector3(newGOCenter.x, newGOCenter.y, gOCenter.z);
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            draggingMode = false;
        }
    }
	#endregion
	
	#region My Methods
	#endregion
}