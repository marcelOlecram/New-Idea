using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Follow : MonoBehaviour {

    #region Variables
    // public 
    public Transform player;
    public float distanceDamp;
    public Vector3 offset;
    // private
    private Transform myTransform;
    private Vector3 velocity = Vector3.one;
    #endregion

    #region Unity Methods
    // Use this for initialization
    void Start()
    {
        SetInitialReferences();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //SmoothFollowPlayer();
    }

    private void FixedUpdate()
    {
        SmoothFollowPlayer();
    }
    #endregion
    #region My Methods
    void SetInitialReferences()
    {
        myTransform = transform;
    }

    void FollowPlayer()
    {
        myTransform.position = new Vector3(player.position.x, player.position.y, myTransform.position.z);
    }

    void SmoothFollowPlayer()
    {
        Vector3 toPosition = player.position + offset;
        Vector3 currentPosition = Vector3.SmoothDamp(myTransform.position, toPosition, ref velocity, distanceDamp);
        myTransform.position = currentPosition;
    }
    #endregion

}
