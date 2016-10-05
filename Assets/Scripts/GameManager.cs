﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using GameProgramming2D.State;

namespace GameProgramming2D {
	public class GameManager : MonoBehaviour {

		private static GameManager _instance;

		private InputManager _inputManager;
		private Pauser _pauser;
		private PlayerControl _playerControl;

		public static GameManager Instance {
			get {
				if (_instance == null) {
					_instance = FindObjectOfType<GameManager> ();
				}
				return _instance;
			}
		}

		public PlayerControl Player {
			get { 
				if (_playerControl == null) {
					_playerControl = FindObjectOfType<PlayerControl> ();
				}
				return _playerControl; }
		}


		public GameStateManager StateManager {
			get;
			private set;
		}

		private void Awake () {
			if (_instance == null) {
				DontDestroyOnLoad (gameObject);
				_instance = this;
				Init ();
			} else if (_instance != this) {
				Destroy (this);
			}
		}

		private void Init () {
			// Luotiin uus nifti luokka GetComponentin ja AddComponentin tilalle:
			// Extensions.cs
			_pauser = gameObject.GetOrAddComponent<Pauser> ();
			_inputManager = gameObject.GetOrAddComponent<InputManager> ();
			_playerControl = FindObjectOfType<PlayerControl> ();

			InitGameStateManager ();
		}
			
		private void InitGameStateManager() {
			StateManager = new GameStateManager (new MenuState ());
			StateManager.AddState (new GameState ());
			StateManager.AddState (new GameOverState ());
		}

		public Pauser Pauser {
			get { return _pauser; }
		}





		public void Reload () {
			SceneManager.LoadScene (SceneManager.GetActiveScene().name);
		}




	}
}
