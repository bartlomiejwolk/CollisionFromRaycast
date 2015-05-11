using UnityEngine;
using System.Collections;

namespace OneDayGame {

    [ExecuteInEditMode]
    public class CollisionFromRaycast : MonoBehaviour {

        // todo move docs to properties
        #region FIELDS
        /// If collision happened.
        [SerializeField]
        private bool collision;

        /// Contain info about collied object.
        private RaycastHit hit;

        /// Layer on which collisions should be detected
        [SerializeField]
        private LayerMask includeLayerMask;

        #endregion

        #region INSPECTOR FIELDS
        /// Disable component after collision.
        [SerializeField]
        private bool disableAfterCollision;

        /// Pause game on collision.
        [SerializeField]
        private bool pauseGame;

        /// Draw raycast.
        [SerializeField]
        private bool drawRay;

        /// Raycast length.
        [SerializeField]
        private float raycastLength = 1;

        #endregion

        #region PROPERTIES
        public LayerMask IncludeLayerMask {
            get { return includeLayerMask; }
            set { includeLayerMask = value; }
        }

        public RaycastHit Hit {
            get { return hit; }
            set { hit = value; }
        }

        public GameObject HitObject { get; set; }

        // TODO Add doc
        public bool DrawRay {
            get { return drawRay; }
            set { drawRay = value; }
        }

        // TODO
        public bool PauseGame {
            get { return pauseGame; }
            set { pauseGame = value; }
        }

        public bool Collision {
            get { return collision; }
        }

        public float RaycastLength {
            get { return raycastLength; }
            set { raycastLength = value; }
        }

        /// Disable component after collision.
        public bool DisableAfterCollision {
            get { return disableAfterCollision; }
            set { disableAfterCollision = value; }
        }

        #endregion

        #region METHODS
        private void FixedUpdate() {
            // Don't execute in edit mode
            if (!Application.isPlaying) {
                return;
            }
            
            // TODO Rename to CheckForCollision()
            if (CollisionDetected()) {
                collision = true;
                /// Disable component.
                if (DisableAfterCollision) {
                    this.enabled = false;
                }
            }
            else {
                collision = false;
            }
            
            // Break on collision if the option is set.
            if (Collision && PauseGame) {
                Debug.Log("CollisionFromRaycast: stop on collision");
                Debug.Break();
            }

            if (drawRay) {
                Debug.DrawRay(transform.position,
                        transform.forward * raycastLength, Color.green);
            }
        }

        /// <summary>
        /// Check for collision with another object.
        /// </summary>
        /// <returns></returns>
        private bool CollisionDetected() {
            var coll = Physics.Raycast(
                transform.position,
                transform.forward,
                out hit,
                raycastLength,
                includeLayerMask);

            if (!coll) return false;

            HitObject = hit.collider.gameObject;

            return true;
        }
        #endregion
    }
}
