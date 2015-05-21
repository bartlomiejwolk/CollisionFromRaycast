﻿// Copyright (c) 2015 Bartłomiej Wołk (bartlomiejwolk@gmail.com)
// 
// This file is part of the CollisionFromRaycast extension for Unity. Licensed
// under the MIT license. See LICENSE file in the project root folder.

using UnityEngine;

namespace CollisionFromRaycastEx {

    [ExecuteInEditMode]
    public class CollisionFromRaycast : MonoBehaviour {
        #region CONSTANTS

        public const string Extension = "CollisionFromRaycast";
        public const string Version = "v0.1.0";

        #endregion CONSTANTS

        // todo move docs to properties todo convert docs to xml

        #region FIELDS

        /// <summary>
        /// Allows identify component in the scene file when reading it with
        /// text editor.
        /// </summary>
        [SerializeField]
        private string componentName = "CollisionFromRaycast";

        /// If collision happened.
        [SerializeField]
        private bool collision;

        /// Contain info about collied object.
        private RaycastHit hit;

        /// Layer on which collisions should be detected
        [SerializeField]
        private LayerMask includeLayerMask;

        #endregion FIELDS

        #region INSPECTOR FIELDS

        [SerializeField]
        private CollisionOccured collisionEvent;

        [SerializeField]
        private string description = "Description";

        /// Disable component after collision.
        [SerializeField]
        private bool disableAfterCollision;

        /// Draw raycast.
        [SerializeField]
        private bool drawRay;

        /// Pause game on collision.
        [SerializeField]
        private bool pauseGame;

        /// Raycast length.
        [SerializeField]
        private float raycastLength = 1;

        #endregion INSPECTOR FIELDS

        #region PROPERTIES

        public bool Collision {
            get { return collision; }
            set { collision = value; }
        }

        public CollisionOccured CollisionEvent {
            get { return collisionEvent; }
            set { collisionEvent = value; }
        }

        public string Description {
            get { return description; }
            set { description = value; }
        }

        /// Disable component after collision.
        public bool DisableAfterCollision {
            get { return disableAfterCollision; }
            set { disableAfterCollision = value; }
        }

        // TODO Add doc
        public bool DrawRay {
            get { return drawRay; }
            set { drawRay = value; }
        }

        public RaycastHit Hit {
            get { return hit; }
            set { hit = value; }
        }

        public GameObject HitObject { get; set; }

        public LayerMask IncludeLayerMask {
            get { return includeLayerMask; }
            set { includeLayerMask = value; }
        }

        // TODO
        public bool PauseGame {
            get { return pauseGame; }
            set { pauseGame = value; }
        }

        public float RaycastLength {
            get { return raycastLength; }
            set { raycastLength = value; }
        }

        #endregion PROPERTIES

        #region UNITY MESSAGES

        private void FixedUpdate() {
            ThrowRaycast();
            HandlePauseGameOption();
            HandleDrawRayOption();
            HandleDisableAfterCollisionOption();
        }

        #endregion UNITY MESSAGES

        #region METHODS

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
        ///     Check for collision with another object.
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

        #endregion METHODS
    }

}