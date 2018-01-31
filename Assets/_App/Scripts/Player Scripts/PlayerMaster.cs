using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMaster : MonoBehaviour {

    #region Delegados
    public delegate void PlayerEventHandler();
    public event PlayerEventHandler EventPlayerJumps;
    public event PlayerEventHandler EventPlayerLands;
    public event PlayerEventHandler EventIncreaseScore;
    public event PlayerEventHandler EventDecreaseScore;
    public event PlayerEventHandler EventGainLife;
    public event PlayerEventHandler EventLoseLife;          // lose life by destructor    
    #endregion

    #region My Methods
    public void CallEventPlayerJumps()
    {
        if (EventPlayerJumps != null)
        {
            EventPlayerJumps();
        }
    }

    public void CallEventPlayerLands()
    {
        if (EventPlayerLands != null)
        {
            EventPlayerLands();
        }
    }

    public void CallEventIncreaseScore()
    {
        if (EventIncreaseScore != null)
        {
            EventIncreaseScore();
        }
    }

    public void CallEventDecreaseScore()
    {
        if (EventDecreaseScore != null)
        {
            EventDecreaseScore();
        }
    }

    public void CallEventGainLife()
    {
        if (EventGainLife != null)
        {
            EventGainLife();
        }
    }

    public void CallEventLoseLife()
    {
        if (EventLoseLife != null)
        {
            EventLoseLife();
        }
    }
    #endregion
}