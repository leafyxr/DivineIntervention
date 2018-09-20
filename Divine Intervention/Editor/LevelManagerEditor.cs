using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(LevelManager))]
public class LevelManagerEditor : Editor {
    void onInspectorGUI()
    {
        var levelManager = target as LevelManager;
        levelManager.type = (LevelManager.LevelType)EditorGUILayout.EnumPopup("Type", levelManager.type);
        if (levelManager.type == LevelManager.LevelType.ReachGoal)
        {
            levelManager.test = EditorGUILayout.TextField("test", levelManager.test);
        }
        else if (levelManager.type == LevelManager.LevelType.ReachGoal)
        {

        }
        else if (levelManager.type == LevelManager.LevelType.ReachGoal)
        {

        }
        else if (levelManager.type == LevelManager.LevelType.ReachGoal)
        {

        }
    }

}
