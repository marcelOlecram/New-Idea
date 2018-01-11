using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    #region Variables
    // public
    public float jumpForce;
    public float movementSpeed;
    public float gravityJumpMultiplier;
    public float gravityFallMultiplier;
    public bool isJumping = false;
    // private
    private Rigidbody2D rB;
    private Transform myTransform;
    #endregion

    #region Unity Methods
    // Use this for initialization
    void Start()
    {
        SetInitialReferences();
    }

    // Update is called once per frame
    void Update()
    {        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isJumping = false;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isJumping = true;
    }

    private void FixedUpdate()
    {
        CheckMovementInput();
    }
    #endregion

    #region My Methods
    void CheckMovementInput()
    {
        // efecto de salto
        if(rB.velocity.y < 0f)
        {
            rB.velocity += Vector2.up * Physics2D.gravity.y * (gravityFallMultiplier - 1f) * Time.deltaTime;
        }else if(rB.velocity.y >0f && !Input.GetKey(KeyCode.W))
        {
            rB.velocity += Vector2.up * Physics2D.gravity.y * (gravityJumpMultiplier - 1f) * Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.W) && !isJumping)
        {
            rB.velocity = Vector2.up * jumpForce;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {

        }
        if (Input.GetKey(KeyCode.A))
        {
            rB.velocity = new Vector2(-movementSpeed, rB.velocity.y);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rB.velocity = new Vector2(movementSpeed, rB.velocity.y);
        }
        // soltar teclas de avance
        if (Input.GetKeyUp(KeyCode.A))
        {
            rB.velocity = new Vector2(0f, rB.velocity.y);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            rB.velocity = new Vector2(0f, rB.velocity.y);
        }
    }

    void SetInitialReferences()
    {
        rB = GetComponent<Rigidbody2D>();
        myTransform = transform;
    }
    #endregion


}
