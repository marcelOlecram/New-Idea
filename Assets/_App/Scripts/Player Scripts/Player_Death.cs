using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Death : MonoBehaviour {

    #region Variables
    // public
    public int lifes;
    // private
    [SerializeField]
    private Text lifeText;    
    // masters
    private PlayerMaster playerMaster;
    #endregion

    #region Unity Methods
    private void OnEnable()
    {
        SetInitialReferences();
        playerMaster.EventGainLife += IncreaseLife;
        playerMaster.EventLoseLife += DecreaseLife;
        playerMaster.EventDestroyPlayer += DestroyPlayer;
    }

    private void OnDisable()
    {
        playerMaster.EventGainLife -= IncreaseLife;
        playerMaster.EventLoseLife -= DecreaseLife;
        playerMaster.EventDestroyPlayer -= DestroyPlayer;
    }

    private void Start()
    {
        UpdateUI();
    }
    #endregion

    #region My Methods
    private void SetInitialReferences()
    {
        playerMaster = GetComponent<PlayerMaster>();
    }

    public void IncreaseLife()
    {
        lifes++;
        UpdateUI();
    }

    public void DecreaseLife()
    {
        lifes--;
        UpdateUI();
        if (lifes <= 0)
        {
            // trigger gameover
            playerMaster.CallEventDestroyPlayer();
        }
    }

    public void DestroyPlayer() {
        Destroy(gameObject);
    }

    private void UpdateUI()
    {
        lifeText.text = "V: " + lifes;
    }
	#endregion
}