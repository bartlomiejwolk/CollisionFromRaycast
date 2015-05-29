// Copyright (c) 2015 Bartlomiej Wolk (bartlomiejwolk@gmail.com)
// 
// This file is part of the CollisionFromRaycast extension for Unity. Licensed
// under the MIT license. See LICENSE file in the project root folder.

using UnityEditor;
using UnityEngine;

namespace CollisionFromRaycastEx {

    [CustomEditor(typeof (CollisionFromRaycast))]
    public class CollisionFromRaycastEditor : Editor {
        #region SERIALIZED PROPERTIES

        private SerializedProperty collisionEvent;
        private SerializedProperty description;
        private SerializedProperty disableAfterCollision;
        private SerializedProperty drawRay;
        private SerializedProperty pauseGame;
        private SerializedProperty raycastLength;
        private SerializedProperty layerMask;

        #endregion SERIALIZED PROPERTIES

        #region UNITY MESSAGES

        public void OnEnable() {
            raycastLength = serializedObject.FindProperty("raycastLength");
            drawRay = serializedObject.FindProperty("drawRay");
            pauseGame = serializedObject.FindProperty("pauseGame");
            disableAfterCollision =
                serializedObject.FindProperty("disableAfterCollision");
            collisionEvent = serializedObject.FindProperty("collisionEvent");
            description = serializedObject.FindProperty("description");
            layerMask = serializedObject.FindProperty("layerMask");
        }

        public override void OnInspectorGUI() {
            serializedObject.Update();

            DrawVersionLabel();
            DrawDescriptionTextArea();

            EditorGUILayout.Space();

            DrawRaycastLengthField();
            DrawIncludeLayerMaskDropdown();
            DrawDrawRayToggle();
            DrawPauseGameToggle();
            DrawDisableAfterCollisionToggle();

            EditorGUILayout.Space();

            DrawEventsList();

            serializedObject.ApplyModifiedProperties();
        }

        private void DrawIncludeLayerMaskDropdown() {
            EditorGUILayout.PropertyField(
                layerMask,
                new GUIContent(
                    "Layer Mask",
                    "Specified layers will be detected by the raycast."));
        }

        #endregion UNITY MESSAGES

        #region INSPECTOR CONTROLS

        private void DrawDescriptionTextArea() {
            description.stringValue = EditorGUILayout.TextArea(
                description.stringValue);
        }

        private void DrawDisableAfterCollisionToggle() {
            EditorGUILayout.PropertyField(
                disableAfterCollision,
                new GUIContent(
                    "Disable After Collision",
                    "If checked, this component will disable itself " +
                    "after first collison."));
        }

        private void DrawDrawRayToggle() {
            EditorGUILayout.PropertyField(
                drawRay,
                new GUIContent(
                    "Draw Ray",
                    "Draw raycast ray gizmo."));
        }

        private void DrawEventsList() {
            EditorGUILayout.PropertyField(
                collisionEvent,
                new GUIContent(
                    "Events",
                    "Actions to execute on collison."));
        }

        private void DrawPauseGameToggle() {
            EditorGUILayout.PropertyField(
                pauseGame,
                new GUIContent(
                    "Pause Game",
                    "If checked, on collision the game will be paused."));
        }

        private void DrawRaycastLengthField() {
            EditorGUILayout.PropertyField(
                raycastLength,
                new GUIContent(
                    "Raycast Length",
                    "Length of the raycast."));
        }

        private void DrawVersionLabel() {
            EditorGUILayout.LabelField(
                string.Format(
                    "{0} ({1})",
                    CollisionFromRaycast.Version,
                    CollisionFromRaycast.Extension));
        }

        #endregion INSPECTOR CONTROLS

        #region METHODS

        [MenuItem("Component/CollisionFromRaycast")]
        private static void AddEntryToComponentMenu() {
            if (Selection.activeGameObject != null) {
                Selection.activeGameObject.AddComponent(
                    typeof (CollisionFromRaycast));
            }
        }

        #endregion METHODS
    }

}