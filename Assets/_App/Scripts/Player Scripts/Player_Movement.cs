using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour {
    #region Variables
    // public
    public float jumpForce;
    public float movementSpeed;
    public float gravityJumpMultiplier;
    public float gravityFallMultiplier;
    public bool isJumping = false;
    // private
    private Rigidbody2D rB;
    //private Transform myTransform;
    private bool jumpRequest = false;
    private bool movementRightRequest = false;
    private bool movementLeftRequest = false;
    private bool stopRequest = false;
    // masters
    private PlayerMaster playerMaster;
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
        CheckJumpInput();
        CheckMovementInput();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isJumping = false;
        playerMaster.CallEventPlayerLands();
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isJumping = true;
        playerMaster.CallEventPlayerJumps();
    }

    private void FixedUpdate()
    {
        Move();
        Jump();
        if (jumpRequest)
        {
            jumpRequest = false;
            rB.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
    #endregion

    #region My Methods
    private void CheckJumpInput()
    {
        if(!isJumping && (Input.GetKeyDown(KeyCode.W)|| Input.GetKeyDown(KeyCode.Space)))
        {
            jumpRequest = true;
        }
    }

    // Calcular los efectos de saltos en fisicas
    private void Jump()
    {
        if(rB.velocity.y < 0f)
        {
            rB.gravityScale = gravityFallMultiplier;
        }else if(rB.velocity.y > 0f)
        {
            rB.gravityScale = gravityFallMultiplier;
        }else
        {
            rB.gravityScale = 1f;
        }
    }
    // realizar los movimientos en fisicas
    private void Move()
    {
        // movimient a la izquierda
        if (movementLeftRequest)
        {             
            rB.velocity = new Vector2(-movementSpeed, rB.velocity.y);            
        }
        // movimiento a la derecha
        if (movementRightRequest)
        {            
            rB.velocity = new Vector2(movementSpeed, rB.velocity.y);
        }
        // stop
        if (stopRequest)
        {
            stopRequest = false;
            rB.velocity = new Vector2(0f, rB.velocity.y);
        }
    }

    private void CheckMovementInput()
    {
        // movimiento
        if (Input.GetKeyDown(KeyCode.A))
        {
            movementLeftRequest = true;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            movementRightRequest = true;
        }
        // detener movimiento
        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            movementLeftRequest = false;
            stopRequest = true;
        }
    }

    private void SetInitialReferences()
    {
        rB = GetComponent<Rigidbody2D>();
        //myTransform = transform;
        playerMaster = GetComponent<PlayerMaster>();
    }
    #endregion


}
