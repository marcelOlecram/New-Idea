using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMaster : MonoBehaviour {

    #region Delegados
    public delegate void PlatformEventHandler();
    public event PlatformEventHandler EventPlayerLandsPlatform;
    public event PlatformEventHandler EventPlayerLandsObstacle;
    public event PlatformEventHandler EventPlayerLeavesPlatform;
    public event PlatformEventHandler EventPlatformDestroy;
    #endregion


    #region My Methods
    public void CallEventPlayerLandsPlatform()
    {
        if(EventPlayerLandsPlatform != null)
        {
            EventPlayerLandsPlatform();
        }
    }

    public void CallEventPlayerLandsObstacle()
    {
        if (EventPlayerLandsObstacle != null)
        {
            EventPlayerLandsObstacle();
        }
    }

    public void CallEventPlayerLeavesPlatform()
    {
        if (EventPlayerLeavesPlatform != null)
        {
            EventPlayerLeavesPlatform();
        }
    }

    public void CallEventPlatformDestroy()
    {
        if (EventPlatformDestroy != null)
        {
            EventPlatformDestroy();
        }
    }
    #endregion
}