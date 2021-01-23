using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

[CustomEditor(typeof(HealthData))]
public class HealthDataEditor : Editor
{
    private HealthData targetObject;

    void OnEnable()
    {
        targetObject = (HealthData)this.target;
    }
    
    // Implement this function to make a custom inspector.
    public override void OnInspectorGUI()
    {
        // Using Begin/End ChangeCheck is a good practice to avoid changing assets on disk that weren't edited.
        EditorGUI.BeginChangeCheck();

        //// Use the editor auto-layout system to make your life easy
        EditorGUILayout.BeginVertical();

        // Re-enable further controls
        GUI.enabled = true;
        targetObject.healthValue = EditorGUILayout.IntField("healthValue", targetObject.healthValue);
        EditorGUILayout.EndVertical();

        // If anything has changed, mark the object dirty so it's saved to disk
        if (EditorGUI.EndChangeCheck())
            EditorUtility.SetDirty(target);

        if (targetObject.healthValue == 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}