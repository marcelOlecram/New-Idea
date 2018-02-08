using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructorMaster : MonoBehaviour {

    #region Delegados
    public delegate void DestrutorEventHandler();
    public event DestrutorEventHandler EventIncreaseSpeed;
    public event DestrutorEventHandler EventDecreaseSpeed;
    public event DestrutorEventHandler EventDestroy;
    #endregion

    #region Variables
    // public
    // private
    #endregion
	
	#region My Methods
    public void CallEventIncreaseSpeed()
    {
        if (EventIncreaseSpeed != null)
        {
            EventIncreaseSpeed();
        }
    }

    public void CallEventDecreaseSpeed()
    {
        if (EventDecreaseSpeed != null)
        {
            EventDecreaseSpeed();
        }
    }

    public void Call()
    {
        if (EventDestroy != null)
        {
            Debug.Log("Event Destroy");
            EventDestroy();
        }
    }
    #endregion
}