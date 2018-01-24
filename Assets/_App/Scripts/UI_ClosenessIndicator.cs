using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_ClosenessIndicator : MonoBehaviour {

    #region Variables
    // public
    public Transform player;
    public Transform destroyer;
    public float dimensionOffset;
    // private
    private float uiDistance;
    private float uiMaxDistance;
    private float distance;
    private float maxDistance;

    
    private Vector3 initialPos;

    [Header("UI")]
    // UI
    public GameObject playerIndicator;
    public GameObject destroyerIndicator;
	#endregion
	
	#region Unity Methods
	// Use this for initialization
	private void Start () {
		SetInitialReferences();
        CalculateDistance();

        Move();
    }

    private void LateUpdate()
    {
        CalculateDistance();
        Move();        
    }
    #endregion

    #region My Methods
    void CalculateDistance()
    {
        distance = Vector3.Distance(player.position, destroyer.position);
        uiDistance = uiMaxDistance * (distance / maxDistance);
        //Debug.Log("Distance" + distance);
        //Debug.Log("UIDistance" + uiDistance);
    }

    void SetInitialReferences()
    {
        uiMaxDistance = Vector3.Distance(playerIndicator.transform.position, destroyerIndicator.transform.position);
        //maxDistance = Vector3.Distance(player.position, destroyer.position);
        maxDistance = Mathf.Abs(player.position.x - destroyer.position.x);

        initialPos = destroyerIndicator.transform.position;
    }

    void Move()
    {
        if (uiMaxDistance >= uiDistance)
        {
            destroyerIndicator.transform.position = new Vector3((uiMaxDistance - uiDistance) + dimensionOffset, destroyerIndicator.transform.position.y, destroyerIndicator.transform.position.z);
        }
        else
        {
            destroyerIndicator.transform.position = initialPos + new Vector3(dimensionOffset, 0f, 0f) ; // evita que se salga del ui
        }
    }
	#endregion
}