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
    // masters
    private PlatformMaster platformMaster;
    #endregion

    #region Unity Methods
    private void OnEnable()
    {
        SetInitialReferences();
        platformMaster.EventPlayerLandsPlatform += ChangeToBlockedSprite;
        platformMaster.EventPlayerLeavesPlatform += ChangeToDragableSprite;

        platformMaster.EventBlockPlatform += ChangeToBlockedSprite;
        platformMaster.EventUnblockPlatform += ChangeToDragableSprite;
    }

    private void OnDisable()
    {
        platformMaster.EventPlayerLandsPlatform -= ChangeToBlockedSprite;
        platformMaster.EventPlayerLeavesPlatform -= ChangeToDragableSprite;

        platformMaster.EventBlockPlatform -= ChangeToBlockedSprite;
        platformMaster.EventUnblockPlatform -= ChangeToDragableSprite;
    }

	#endregion
	
	#region My Methods
    void SetInitialReferences()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        ChangeToDragableSprite();

        platformMaster = GetComponent<PlatformMaster>();
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