using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

public class SetMainScene : EditorWindow
{
    /// <summary>
    /// OnGUI is called for rendering and handling GUI events.
    /// This function can be called multiple times per frame (one call per event).
    /// </summary>
    private void OnGUI()
    {
        EditorSceneManager.playModeStartScene = (SceneAsset)EditorGUILayout.ObjectField(new GUIContent("Start Scene"), EditorSceneManager.playModeStartScene, typeof(SceneAsset), false);

        Rect newRectPos = this.position;
        newRectPos.size = new Vector2(400, 200);
        this.position = newRectPos;

        // Or set the start Scene from code
        // var scenePath = "Assets/Scenes/MainMenu.unity";
        // if (GUILayout.Button("Set start Scene: " + scenePath))
        //     SetPlayModeStartScene(scenePath);
    }

    // void SetPlayModeStartScene(string scenePath)
    // {
    //     SceneAsset myWantedStartScene = AssetDatabase.LoadAssetAtPath<SceneAsset>(scenePath);
    //     if (myWantedStartScene != null)
    //         EditorSceneManager.playModeStartScene = myWantedStartScene;
    //     else
    //         Debug.Log("Could not find Scene " + scenePath);
    // }

    [MenuItem("ValkTools/Set Main Scene")]
    private static void Open()
    {
        var inspWndType = typeof(SceneView);
        var window = EditorWindow.GetWindow<SetMainScene>(inspWndType);
    }
}