using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(PrefabSpawner))]
public class PrefabSpawnerEditor : Editor {
    
     public override void OnInspectorGUI() {
         PrefabSpawner prefabSpawner = (PrefabSpawner)target;

         DrawDefaultInspector();

         if (GUILayout.Button("Generate")) {
             prefabSpawner.GeneratePrefabs();
         }
    }
 }
