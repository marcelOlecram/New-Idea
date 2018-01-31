using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster_References : MonoBehaviour {

    #region Variables
    // public
    public string playerTag;
    public static string _playerTag;

    public string destructorTag;
    public static string _destructorTag;

    public static GameObject _player;
	#endregion
	
	#region Unity Methods	
	private void OnEnable () {
		if(playerTag == "")
        {
            Debug.Log("Falta asignar el nombre del Tag del jugador. El juego no funcionara del todo");
        }

        if (destructorTag == "")
        {
            Debug.Log("Falta asignar el nombre del Tag del destructor. El juego no funcionara del todo");
        }

        _playerTag = playerTag;
        _destructorTag = destructorTag;

        _player = GameObject.FindGameObjectWithTag(_playerTag);
    }
	
	private void Start () {
        // asegurarse que exista una referencia al jugador
		if(_player == null)
        {
            _player = GameObject.FindGameObjectWithTag(_playerTag);
        }
	}
	#endregion
	
	#region My Methods
	#endregion
}