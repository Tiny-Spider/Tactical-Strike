using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StructureManager : MonoBehaviour {
    private static List<Structure> structures;

    void Start() {
        Structure[] structures = Resources.LoadAll<Structure>("Structures");

        if (structures.Length <= 0) {
            Debug.LogError("No structures were loaded!");
        }

        StructureManager.structures = new List<Structure>(structures);
    }

    public static List<Structure> GetStructures() {
        return structures;
    }

    public static Structure GetStructure(string techName) {
        foreach (Structure structure in structures) {
            if (structure.techName == techName) {
                return structure;
            }
        }

        Debug.LogError("Structure not found by techName! techName: \"" + techName + "\"");
        return null;
    }
}
