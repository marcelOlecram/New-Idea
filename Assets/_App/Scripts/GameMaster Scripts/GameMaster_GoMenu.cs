using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMaster_GoMenu : MonoBehaviour {

    #region Variables
    // public
    // private
    // masters
    private GameMaster gameMaster;
    #endregion

    #region Unity Methods
    private void OnEnable()
    {
        SetInitialReferences();
        gameMaster.EventGoToMainMenu += GoToMenu;
    }

    private void OnDisable()
    {
        gameMaster.EventGoToMainMenu -= GoToMenu;
    }
    #endregion

    #region My Methods
    public void GoToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void SetInitialReferences()
    {
        gameMaster = GetComponent<GameMaster>();
    }
	#endregion
}