using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_SpriteChange : MonoBehaviour {

    #region Variables
    // public
    public Sprite dragableSprite;
    public Sprite blockedSprite;
    // private
    private SpriteRenderer spriteRenderer;
	#endregion
	
	#region Unity Methods
	// Use this for initialization
	private void Start () {
        SetInitialReferences();
	}

	#endregion
	
	#region My Methods
    void SetInitialReferences()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        ChangeToDragableSprite();
    }

    public void ChangeToBlockedSprite()
    {
        spriteRenderer.sprite = blockedSprite;
    }
    public void ChangeToDragableSprite()
    {
        spriteRenderer.sprite = dragableSprite;
    }
    #endregion
}