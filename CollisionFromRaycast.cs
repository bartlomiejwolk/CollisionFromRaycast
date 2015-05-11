using UnityEngine;
using System.Collections;

namespace OneDayGame {

	[ExecuteInEditMode]
	public class CollisionFromRaycast : MonoBehaviour {

		/// If collision happened.
		[SerializeField]
		private bool _collision = false;

		public bool Collision {
			get { return _collision; }
			private set {}
		}

		/// Raycast length.
		[SerializeField]
		private float _raycastLength = 1;
		public float RaycastLength {
			get { return _raycastLength; }
			set { _raycastLength = value; }
		}

		/// Contain info about collied object.
		protected RaycastHit _hit;
		public RaycastHit Hit {
			get { return _hit; }
			set { _hit = value; }
		}

		/// Layer on which collisions should be detected
		[SerializeField]
		private LayerMask _includeLayerMask;

		public LayerMask IncludeLayerMask {
			get { return _includeLayerMask; } 
			set { _includeLayerMask = value; }
		}

		/// Object that has been hit
		protected GameObject _hitObject;

		public GameObject HitObject {
			get { return _hitObject; }
			set { _hitObject = value; }
		}

		/// Draw raycast.
		[SerializeField]
		private bool _drawRay;

		// TODO Add doc
		public bool DrawRay {
			get { return _drawRay; }
			set { _drawRay = value; }
		}

		/// Pause game on collision.
		[SerializeField]
		private bool _pauseGame;

		// TODO
		public bool PauseGame {
			get { return _pauseGame; }
			set { _pauseGame = value; }
		}

		/// Disable component after collision.
		[SerializeField]
		private bool _disableAfterCollision;

		private void FixedUpdate() {
			// Don't execute in edit mode
			if (!Application.isPlaying) {
				return;
			}
			
			// TODO Rename to CheckForCollision()
			if (CollisionDetected()) {
				_collision = true;
				/// Disable component.
				if (_disableAfterCollision) {
					this.enabled = false;
				}
			}
			else {
				_collision = false;
			}
			
			// Break on collision if the option is set.
			if (_collision && _pauseGame) {
				Debug.Log("CollisionFromRaycast: stop on collision");
				Debug.Break();
			}

			if (_drawRay) {
				Debug.DrawRay(transform.position,
						transform.forward * _raycastLength, Color.green);
			}
		}

		/// Check for collision with another object.
		private bool CollisionDetected() {
			bool collision;

			collision = Physics.Raycast(
					transform.position,
					transform.forward,
					out _hit,
					_raycastLength,
					_includeLayerMask);
			if(collision) {
				_hitObject = _hit.collider.gameObject;
				return true;
			}
			return false;
		}
	}
}
