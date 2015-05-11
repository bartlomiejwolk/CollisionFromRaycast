using UnityEngine;
using System.Collections;

namespace OneDayGame {

    [ExecuteInEditMode]
    public class CollisionFromRaycast : MonoBehaviour {

        #region FIELDS
        /// If collision happened.
        [SerializeField]
        private bool collision;

        public bool Collision {
            get { return collision; }
        }

        /// Raycast length.
        [SerializeField]
        private float raycastLength = 1;
        public float RaycastLength {
            get { return raycastLength; }
            set { raycastLength = value; }
        }

        /// Contain info about collied object.
        protected RaycastHit hit;
        public RaycastHit Hit {
            get { return hit; }
            set { hit = value; }
        }

        /// Layer on which collisions should be detected
        [SerializeField]
        private LayerMask includeLayerMask;

        public LayerMask IncludeLayerMask {
            get { return includeLayerMask; } 
            set { includeLayerMask = value; }
        }

        /// Object that has been hit
        protected GameObject hitObject;

        public GameObject HitObject {
            get { return hitObject; }
            set { hitObject = value; }
        }

        /// Draw raycast.
        [SerializeField]
        private bool drawRay;

        // TODO Add doc
        public bool DrawRay {
            get { return drawRay; }
            set { drawRay = value; }
        }

        /// Pause game on collision.
        [SerializeField]
        private bool pauseGame;

        // TODO
        public bool PauseGame {
            get { return pauseGame; }
            set { pauseGame = value; }
        }

        /// Disable component after collision.
        [SerializeField]
        private bool disableAfterCollision;

        #endregion

        #region INSPECTOR FIELDS
        #endregion

        #region PROPERTIES
        #endregion

        private void FixedUpdate() {
            // Don't execute in edit mode
            if (!Application.isPlaying) {
                return;
            }
            
            // TODO Rename to CheckForCollision()
            if (CollisionDetected()) {
                collision = true;
                /// Disable component.
                if (disableAfterCollision) {
                    this.enabled = false;
                }
            }
            else {
                collision = false;
            }
            
            // Break on collision if the option is set.
            if (collision && pauseGame) {
                Debug.Log("CollisionFromRaycast: stop on collision");
                Debug.Break();
            }

            if (drawRay) {
                Debug.DrawRay(transform.position,
                        transform.forward * raycastLength, Color.green);
            }
        }

        /// Check for collision with another object.
        private bool CollisionDetected() {
            bool collision;

            collision = Physics.Raycast(
                    transform.position,
                    transform.forward,
                    out hit,
                    raycastLength,
                    includeLayerMask);
            if(collision) {
                hitObject = hit.collider.gameObject;
                return true;
            }
            return false;
        }
    }
}
