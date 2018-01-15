using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Score : MonoBehaviour {

    #region Variables
    // public
    public int scorePlatform;
    // private
    [SerializeField]
    private Text scorePlatformText;
	#endregion
	
	#region Unity Methods
	#endregion
	
	#region My Methods
    public void IncreaseScore()
    {
        scorePlatform++;
        UpdateUI();
    }

    private void UpdateUI()
    {
        scorePlatformText.text = "Pl: " + scorePlatform;
    }

    public void DecreaseScore()
    {
        scorePlatform--;
        UpdateUI();
    }
	#endregion
}