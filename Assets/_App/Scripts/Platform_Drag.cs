using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_Drag : MonoBehaviour {

    #region Variables
    // public    
    public bool canBeDragged = true;
    public bool isDragged = false;
    public string playerTag = "Player";
    // private
    [SerializeField]
    private Vector3 gOCenter;           // centro del objeto que se clickeo
    [SerializeField]
    private Vector3 touchPosition;      // en donde se clickeo
    private Vector3 offset;             // distancia desde donde se clickeo al centro del objeto
    [SerializeField]
    private Vector3 newGOCenter;        // posicion en donde se suelta el objeto
    #endregion

    #region Unity Methods
    // llamado cuando se haga click en el objeto
    private void OnMouseDown()
    {
        if (canBeDragged)
        {
            // calcular datos del clickeo
            gOCenter = gameObject.transform.position;
            touchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            offset = touchPosition - gOCenter;

            isDragged = true;
        }
    }
    // llamado mientras se arrastre un objeto
    private void OnMouseDrag()
    {
        if (canBeDragged)
        {
            // actualizar posicion del objeto
            if (isDragged)
            {
                touchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                newGOCenter = touchPosition - offset;
                gameObject.transform.position = new Vector3(newGOCenter.x, newGOCenter.y, gOCenter.z);
            }
        }
    }
    // llamado cuando se suelte el objeto
    private void OnMouseUp()
    {
        isDragged = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(playerTag))
        {
            BlockPlatform();
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(playerTag))
        {
            UnblockPlatform();
        }
    }
    #endregion

    #region My Methods
    public void BlockPlatform()
    {
        canBeDragged = false;
    }

    public void UnblockPlatform()
    {
        canBeDragged = true;
    }
    #endregion
}