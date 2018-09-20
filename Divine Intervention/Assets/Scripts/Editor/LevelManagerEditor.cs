using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

[CustomEditor(typeof(LevelManager))]
public class LevelManagerEditor : Editor {
    public override void OnInspectorGUI()
    {
        var levelManager = target as LevelManager;
        levelManager.TaskText = (Text)EditorGUILayout.ObjectField("Text Task:", levelManager.TaskText, typeof(Text), true);
        levelManager.InfoText = (Text)EditorGUILayout.ObjectField("Text Info:", levelManager.InfoText, typeof(Text), true);
        levelManager.startMenu = (GameObject)EditorGUILayout.ObjectField("Start Menu:", levelManager.startMenu, typeof(GameObject), true);
        levelManager.label = (Text)EditorGUILayout.ObjectField("Text Label:", levelManager.label, typeof(Text), true);
        levelManager.Number = (Text)EditorGUILayout.ObjectField("Number Label:", levelManager.Number, typeof(Text), true);
        levelManager.type = (LevelManager.LevelType)EditorGUILayout.EnumPopup("Type", levelManager.type);
        if (levelManager.type == LevelManager.LevelType.ReachGoal)
        {
            levelManager.TargetArea = (GameObject)EditorGUILayout.ObjectField("Goal:", levelManager.TargetArea, typeof(GameObject), true);
        }
        else if (levelManager.type == LevelManager.LevelType.KillEnemies)
        {
            levelManager.MaxEnemies = EditorGUILayout.IntField("Goal:", levelManager.MaxEnemies);
        }
        else if (levelManager.type == LevelManager.LevelType.TimeTrial)
        {
            levelManager.Timelimit = EditorGUILayout.FloatField("Time Limit:", levelManager.Timelimit);
        }
        else if (levelManager.type == LevelManager.LevelType.Survival)
        {

        }
    }

}
