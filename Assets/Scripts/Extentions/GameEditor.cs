//using UnityEditor;

//[CustomEditor(typeof(Needed))]
//[CanEditMultipleObjects]
//class GameEditor : Editor
//{
//    SerializedProperty SerializedProperty;
//    private SerializedProperty lookAtPoint;

//    private void OnEnable()
//    {
//        lookAtPoint = serializedObject.FindProperty("target");
//    }

//    public override void OnInspectorGUI()
//    {
//        serializedObject.Update();
//        EditorGUILayout.PropertyField(lookAtPoint);
//        serializedObject.ApplyModifiedProperties();
//        EditorGUILayout.LabelField("(Text)");
//    }
//}

