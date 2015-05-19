// Copyright (c) 2015 Bartłomiej Wołk (bartlomiejwolk@gmail.com)
// 
// This file is part of the CollisionFromRaycast extension for Unity.
// Licensed under the MIT license. See LICENSE file in the project root folder.

using UnityEngine;
using System.Collections;
using UnityEditor;
using OneDayGame;

namespace CollisionFromRaycastEx {

    [CustomEditor(typeof (CollisionFromRaycast))]
    public class CollisionFromRaycastEditor : Editor {

        #region SERIALIZED PROPERTIES
        private SerializedProperty raycastLength;
        private SerializedProperty drawRay;
        private SerializedProperty pauseGame;
        private SerializedProperty disableAfterCollision;
        private SerializedProperty collisionEvent;
        #endregion

        #region UNITY MESSAGES
        public void OnEnable() {
            raycastLength = serializedObject.FindProperty("raycastLength");
            drawRay = serializedObject.FindProperty("drawRay");
            pauseGame = serializedObject.FindProperty("pauseGame");
            disableAfterCollision =
                serializedObject.FindProperty("disableAfterCollision");
            collisionEvent = serializedObject.FindProperty("collisionEvent");
        }

        public override void OnInspectorGUI() {
            serializedObject.Update();

            DrawRaycastLengthField();
            DrawDrawRayToggle();
            DrawPauseGameToggle();
            DrawDisableAfterCollisionToggle();

            EditorGUILayout.Space();

            DrawEventsList();

            serializedObject.ApplyModifiedProperties();
        }

        private void DrawEventsList() {
            EditorGUILayout.PropertyField(
                collisionEvent,
                new GUIContent(
                    "Events",
                    "Actions to execute on collison."));
        }

        private void DrawDisableAfterCollisionToggle() {
            EditorGUILayout.PropertyField(
                disableAfterCollision,
                new GUIContent(
                    "Disable After Collision",
                    "If checked, this component will disable itself " +
                    "after first collison."));
        }

        private void DrawPauseGameToggle() {
            EditorGUILayout.PropertyField(
                pauseGame,
                new GUIContent(
                    "Pause Game",
                    "If checked, on collision the game will be paused."));
        }

        private void DrawDrawRayToggle() {
            EditorGUILayout.PropertyField(
                drawRay,
                new GUIContent(
                    "Draw Ray",
                    "Draw raycast ray gizmo."));
        }

        private void DrawRaycastLengthField() {
            EditorGUILayout.PropertyField(
                raycastLength,
                new GUIContent(
                    "Raycast Length",
                    "Length of the raycast."));
        }

        #endregion

    }

}
