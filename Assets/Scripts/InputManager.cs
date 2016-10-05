using UnityEngine;
using System.Collections;

namespace GameProgramming2D {
	public class InputManager : MonoBehaviour {

		private void Update () {
			if (GameManager.Instance.Player == null) {
				return;
			}

			if (Input.GetKeyUp (KeyCode.P)) {
				// Pause game
				GameManager.Instance.Pauser.TogglePause ();
			}

			// If the jump button is pressed and the player is grounded then the player should jump.
			if (Input.GetButtonDown ("Jump")) {
				GameManager.Instance.Player.Jump = true;
			}

			if (Input.GetButtonDown ("Fire1")) {
				GameManager.Instance.Player.Gun.Fire ();
			}

			if (Input.GetButtonDown ("Fire2")) {
				GameManager.Instance.Player.LayBomb ();
			}


			var horizontal = Input.GetAxis ("Horizontal");
			if (GameManager.Instance.Player != null) {
				GameManager.Instance.Player.SetHorizontal (horizontal);
			}
		}

	}
}