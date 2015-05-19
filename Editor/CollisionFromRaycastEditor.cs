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
                    "Unity Events"));
        }

        private void DrawDisableAfterCollisionToggle() {
            EditorGUILayout.PropertyField(disableAfterCollision);
        }

        private void DrawPauseGameToggle() {
            EditorGUILayout.PropertyField(pauseGame);
        }

        private void DrawDrawRayToggle() {
            EditorGUILayout.PropertyField(drawRay);
        }

        private void DrawRaycastLengthField() {
            EditorGUILayout.PropertyField(raycastLength);
        }

        #endregion

    }

}
