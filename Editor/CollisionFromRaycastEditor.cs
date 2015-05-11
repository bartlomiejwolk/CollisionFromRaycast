using UnityEngine;
using System.Collections;
using UnityEditor;
using OneDayGame;

[CustomEditor(typeof(CollisionFromRaycast))]
public class CollisionFromRaycastEditor : Editor {

	private SerializedProperty _raycastLength;
	private SerializedProperty _drawRay; 
	private SerializedProperty _pauseGame;
	private SerializedProperty _disableAfterCollision;

	public void OnEnable() {
		_raycastLength = serializedObject.FindProperty("_raycastLength");
		_drawRay = serializedObject.FindProperty("_drawRay");
		_pauseGame = serializedObject.FindProperty("_pauseGame");
		_disableAfterCollision = serializedObject.FindProperty("_disableAfterCollision");
	}

	public override void OnInspectorGUI() {
		base.OnInspectorGUI();
		//CollisionFromRaycast script = (CollisionFromRaycast)target;
		serializedObject.Update();
		
		EditorGUILayout.PropertyField(_raycastLength);
		EditorGUILayout.PropertyField(_drawRay);
		EditorGUILayout.PropertyField(_pauseGame);
		EditorGUILayout.PropertyField(_disableAfterCollision);

		serializedObject.ApplyModifiedProperties();
	}
}
