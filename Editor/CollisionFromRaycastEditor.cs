using UnityEngine;
using System.Collections;
using UnityEditor;
using OneDayGame;

[CustomEditor(typeof(CollisionFromRaycast))]
public class CollisionFromRaycastEditor : Editor {

	private SerializedProperty raycastLength;
	private SerializedProperty drawRay; 
	private SerializedProperty pauseGame;
	private SerializedProperty disableAfterCollision;

	public void OnEnable() {
		raycastLength = serializedObject.FindProperty("raycastLength");
		drawRay = serializedObject.FindProperty("drawRay");
		pauseGame = serializedObject.FindProperty("pauseGame");
		disableAfterCollision = serializedObject.FindProperty("disableAfterCollision");
	}

	public override void OnInspectorGUI() {
		serializedObject.Update();
		
		EditorGUILayout.PropertyField(raycastLength);
		EditorGUILayout.PropertyField(drawRay);
		EditorGUILayout.PropertyField(pauseGame);
		EditorGUILayout.PropertyField(disableAfterCollision);

		serializedObject.ApplyModifiedProperties();
	}
}
