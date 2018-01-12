using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructor_Destroy : MonoBehaviour {

    #region Variables
    // public
    // private
    [SerializeField]
    private LayerMask layersToDestroyOnExit;
    [SerializeField]
    private LayerMask layersToDestroyOnEnter;
    [SerializeField]
    private GameObject GameOverUI;
    #endregion

    #region Unity Methods
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (layersToDestroyOnEnter == (layersToDestroyOnEnter | (1 << collision.gameObject.layer)))
        {
            // Destroy
            // TODO posible llamada a evento, event Destroy Player
            Destroy(collision.gameObject);
            // TODO posible llamada a evento, event GAME OVER
            // TODO temporal hasta los delegados/eventos
            GameOverUI.GetComponent<GameMaster_GameOver>().GameOver();
        }

        if(layersToDestroyOnExit == (layersToDestroyOnExit | (1<< collision.gameObject.layer))){
            // TODO posible llamada a evento. event BlockPlatform
            // TODO temporal
            if(collision.gameObject.GetComponent<Platform_SpriteChange>() != null)
            {
                collision.gameObject.GetComponent<Platform_SpriteChange>().ChangeToBlockedSprite();
            }
            collision.gameObject.GetComponent<Platform_Drag>().BlockPlatform();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        //Debug.Log(collision.name + " hited");
        if(layersToDestroyOnExit == (layersToDestroyOnExit | (1 << collision.gameObject.layer)))
        {
            // Destroy
            // TODO posible llamada a evento, event Destroy Platform
            Destroy(collision.gameObject);
        }
        
    }
    #endregion
}