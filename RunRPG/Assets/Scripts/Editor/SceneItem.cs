using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

public class SceneItem : Editor {

    [MenuItem("#Open Scene/Main Menu")]
    public static void OpenMainMenu()
    {
        OpenScene("MainMenu");
    }

    [MenuItem("#Open Scene/Quickplay")]
    public static void OpenQuickplay()
    {
        OpenScene("QuickPlay");
    }

    [MenuItem("#Open Scene/Shop")]
    public static void OpenShop()
    {
        OpenScene("Shop");
    }
    [MenuItem("#Open Scene/Add Scene..")]
    public static void Help()
    {
        EditorUtility.DisplayDialog("Add Scene", "Add Scene by Adding a new menu item and static function on SceneItem.cs!","OK");
    }


    static void OpenScene(string name)
    {
        if (EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo())
        {
            
            EditorSceneManager.OpenScene("Assets/Scenes/GameScenes/" + name + ".unity");
        }
    }
}
