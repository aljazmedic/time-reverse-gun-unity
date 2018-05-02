using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(GrenadeThrower))]
public class GrenadeThrowerEditor : Editor
{

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        GrenadeThrower gt = (GrenadeThrower)target;
        GUILayout.BeginHorizontal();

        gt.throwForce = EditorGUILayout.Slider("Throw force", gt.throwForce, .1f, 500f);

        if (GUILayout.Button("Throw"))
        {
            gt.Throw();
        }
        GUILayout.EndHorizontal();
    }
}
