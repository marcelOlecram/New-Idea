using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructor_Movement : MonoBehaviour {

    #region Variables
    // public
    public float speed;
    public float acceleration;
    public float deacceleration;
    // private
    private string playerTag = "Player";
    private Transform myTransform;
    [SerializeField]
    private Vector3 direction;
    [SerializeField]
    private Transform playerTransform;
    #endregion

    #region Unity Methods
    // Use this for initialization
    private void Start () {
        SetInitialReferences();
	}
	
	// Update is called once per frame
	private void Update () {
        Move();
	}

    private void LateUpdate()
    {
        myTransform.position =new Vector3(myTransform.position.x, playerTransform.position.y, myTransform.position.z);
    }
    #endregion

    #region My Methods
    void SetInitialReferences()
    {
        myTransform = transform;
    }
    void Move()
    {
        myTransform.position += direction * speed * Time.deltaTime;
    }

    public void IncreaseSpeed()
    {
        speed += acceleration;
    }

    public void DecreaseSpeed()
    {
        speed -= deacceleration;
    }
	#endregion
}