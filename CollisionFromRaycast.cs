﻿using UnityEngine;
using System.Collections;
using UnityEngine.Events;

namespace CollisionFromRaycastEx {

    // todo move to file
    [System.Serializable]
    public class CollisionOccured : UnityEvent<RaycastHit> { }

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

        [SerializeField]
        private CollisionOccured collisionEvent;

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
            set { collision = value; }
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

        public CollisionOccured CollisionEvent {
            get { return collisionEvent; }
            set { collisionEvent = value; }
        }

        #endregion

        #region METHODS
        private void FixedUpdate() {
            ThrowRaycast();
            HandlePauseGameOption();
            HandleDrawRayOption();
            HandleDisableAfterCollisionOption();
        }

        // todo execute as callback in the ThrowRaycast()
        private void HandleDisableAfterCollisionOption() {
            if (!Application.isPlaying) return;
            if (!DisableAfterCollision) return;

            enabled = false;
        }

        private void HandleDrawRayOption() {
            if (!Application.isPlaying) return;
            if (!DrawRay) return;

            Debug.DrawRay(
                transform.position,
                transform.forward * raycastLength,
                Color.green);
        }

        private void HandlePauseGameOption() {
            if (!Application.isPlaying) return;

            if (!Collision) return;
            if (!PauseGame) return;

            Debug.Log("CollisionFromRaycast: stop on collision");
            Debug.Break();
        }

        /// <summary>
        /// Check for collision with another object.
        /// </summary>
        /// <returns></returns>
        private bool ThrowRaycast() {
            Collision = false;

            var coll = Physics.Raycast(
                transform.position,
                transform.forward,
                out hit,
                raycastLength,
                includeLayerMask);

            if (!coll) return false;

            HitObject = hit.collider.gameObject;
            Collision = true;
            CollisionEvent.Invoke(Hit);

            return true;
        }
        #endregion
    }
}
