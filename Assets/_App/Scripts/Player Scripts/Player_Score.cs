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
    // Master
    private PlayerMaster playerMaster;
    #endregion

    #region Unity Methods
    private void OnEnable()
    {
        SetInitialReferences();

        playerMaster.EventIncreaseScore += IncreaseScore;
        playerMaster.EventDecreaseScore += DecreaseScore;
    }

    private void OnDisable()
    {
        playerMaster.EventIncreaseScore -= IncreaseScore;
        playerMaster.EventDecreaseScore -= DecreaseScore;
    }
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

    private void SetInitialReferences()
    {
        playerMaster = GetComponent<PlayerMaster>();
    }
	#endregion
}