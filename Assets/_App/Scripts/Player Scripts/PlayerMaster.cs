using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMaster : MonoBehaviour {

    #region Delegados
    public delegate void GeneralEventHandler();
    public event GeneralEventHandler EventDestroyPlayer;
    public event GeneralEventHandler EventIncreaseScore;
    public event GeneralEventHandler EventDecreaseScore;
    public event GeneralEventHandler EventGainLife;
    public event GeneralEventHandler EventLoseLife;    
    public event GeneralEventHandler EventPlayerJump;       // manejar animaciones sonidos cada cuando se salte
    #endregion
	
	#region My Methods
    public void CallEventDestroyPlayer()
    {
        if (EventDestroyPlayer != null)
        {
            EventDestroyPlayer();
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

    public void CallEventPlayerJump()
    {
        if (EventPlayerJump!=null)
        {
            EventPlayerJump();
        }
    }
    #endregion
}