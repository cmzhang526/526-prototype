using System;
using System.Collections;
using UnityEditor;
using UnityEngine;
using Unity.EditorCoroutines.Editor;

/*[CustomEditor(typeof(TestClass))]
public class SceneStartupManagerEditor : Editor
{
    private SerializedProperty _scenesToLoad;
    private SerializedProperty _testList;
    private bool loadSceneButtonClicked = false;
    private bool cleanSceneButtonClicked = false;

    private void OnEnable()
    {
        _scenesToLoad = serializedObject.FindProperty(nameof(_scenesToLoad));
        _testList = serializedObject.FindProperty(nameof(_testList));
    }

    public override void OnInspectorGUI()
    {
        TestClass component = (TestClass)target;

        {
            GUILayout.BeginHorizontal();

            if (GUILayout.Button(loadSceneButtonClicked ? "Loaded scenes!" : "Load Scenes", GUILayout.Width(200.0f)))
            {
                loadSceneButtonClicked = true;
                component.Editor_LoadSceneOnStartup();
                EditorCoroutineUtility.StartCoroutine(DoActionAfterWaiting(1.0f,
                    () => { loadSceneButtonClicked = false; }), this);
            }

            if (GUILayout.Button(cleanSceneButtonClicked ? "Cleaned scenes!" : "Clean Scenes", GUILayout.Width(200.0f)))
            {
                cleanSceneButtonClicked = true;
                component.Editor_CleanScenesToLoad();
                EditorCoroutineUtility.StartCoroutine(DoActionAfterWaiting(1.0f,
                    () => { cleanSceneButtonClicked = false; }), this);
            }
            GUILayout.EndHorizontal();
        }

        EditorGUILayout.PropertyField(_scenesToLoad, includeChildren = true);
        EditorGUILayout.PropertyField(_testList);
    }

    IEnumerator DoActionAfterWaiting(float seconds, Action action)
    {
        yield return new EditorWaitForSeconds(seconds);
        action();
    }
}*/
