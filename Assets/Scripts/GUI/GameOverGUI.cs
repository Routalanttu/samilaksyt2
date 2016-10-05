using UnityEngine;
using System.Collections;
using GameProgramming2D.State;

namespace GameProgramming2D.GUI {
	public class GameOverGUI : MonoBehaviour {

		public void RestartPress () {
			GameManager.Instance.StateManager.PerformTransition (TransitionType.GameOverToGame);
		}

		public void MainMenuPress () {
			GameManager.Instance.StateManager.PerformTransition (TransitionType.GameOverToMenu);
		}
	}
}