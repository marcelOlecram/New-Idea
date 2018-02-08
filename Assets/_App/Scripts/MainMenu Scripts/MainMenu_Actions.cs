using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu_Actions : MonoBehaviour {

	#region Variables
	// public
	// private
	#endregion
	
	#region Unity Methods
	#endregion
	
	#region My Methods
    public void StartGame()
    {
        // llamar a la scene del juego revisar el numero en caso de mas scenas sean adicionadas
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ExitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }
	#endregion
}